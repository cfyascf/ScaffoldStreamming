namespace App.Service;

using System.Diagnostics;
using App.Data.Payloads;
using App.Models;
using System.Text;
using App.Exceptions;
using App.Interfaces.Repositories;

public class VideoService(IVideoRepository videoRepo, IContentRepository contentRepo)
{
    public async Task<byte[]> GetContentById(Guid id)
    {
        var content = await contentRepo.GetById(id) 
            ?? throw new GlobalException("Resource not found.", 404);

        return content.Data;
    }
    
    public async Task<Guid> UploadVideo(VideoUploadPayload payload)
    {
        var videoPath = WriteFile(payload);
        ConvertToM38u(videoPath);
        var header = await SaveIntoDb(videoPath, payload);

        return header.Id;
    }

    private string WriteFile(VideoUploadPayload payload)
    {
        var fTitle = payload.Title.Replace(" ", "_");
        // ..makes file open to stream and
        // turns it into memory stream..
        var ors = payload.Video.OpenReadStream();
        var ms = new MemoryStream();
        ors.CopyTo(ms);

        // ..gets the file bytes..
        var bytes = ms.GetBuffer();

        // ..creates a temporary directory 
        // and saves the file in it..
        var uploadingDir = Directory.CreateTempSubdirectory(fTitle);
        var videoPath = Path.Combine(uploadingDir.FullName, fTitle+ ".mp4");
        File.WriteAllBytes(videoPath, bytes);

        return videoPath;
    }

    private async void ConvertToM38u(string videoPath)
    {
        var command = BuildFfmpegCommand(videoPath);

		var startInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = command,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(startInfo);   
        var error = await process!.StandardError.ReadToEndAsync();
        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            Console.WriteLine("Error processing .m3u8 in command terminal.");
            return;
        }

    }

    private string BuildFfmpegCommand(string fileName)
    {
        var output = Path.GetDirectoryName(fileName) + "\\output.m3u8";

        return $"-i {fileName} " +
               "-profile:v baseline " +
               "-level 3.0 " +
               "-s 960x540 " +
               "-start_number 0 " +
               "-hls_time 10 " +
               "-hls_list_size 0 " +
               "-f hls " +
                $"{output}";
    }

    private async Task<Content> SaveIntoDb(string filePath, VideoUploadPayload payload)
    {
        var test = Video.CreateEntity(payload.Title, payload.Description);
        var video = await videoRepo.Create(test);

        // ..catch the header file (.m3u8) and .ts files..
        var files = Directory.GetFiles(Path.GetDirectoryName(filePath)!);
        var header = files.FirstOrDefault(f => f.EndsWith(".m3u8"))
            ?? throw new ArgumentNullException();

        var contentFiles = files.Where(f => f.EndsWith(".ts"))
            ?? throw new ArgumentNullException();
            
        var dict = new Dictionary<string, Guid>();

        // ..saves all .ts files as content table and saves
        // its names and ids..
        foreach(var file in contentFiles)
        {
            var content = await contentRepo.Create(
                Content.CreateEntity(File.ReadAllBytes(file), video, false)
            );

            dict.Add(Path.GetFileName(file), content.Id);
        }

        // ..saves header after processed..
        var fHeader = ProcessHeader(header, dict);
        var headerContent = await contentRepo.Create(
            Content.CreateEntity(Encoding.UTF8.GetBytes(fHeader), video, true)
        );

        return headerContent;
    }

    private string ProcessHeader(string header, Dictionary<string, Guid> dict)
    {
        var lines = File.ReadAllLines(header);
        StringBuilder sb = new();

        // ..replaces files names in header file for
        // files ids, so they can be requested by id by
        // the frontend..
        foreach(var line in lines)
        {
            if(dict.TryGetValue(line, out var id))
            {
                sb.Append(id + "\n");
                continue;
            }

            sb.Append(line + "\n");
        }

        return sb.ToString();
    }
}
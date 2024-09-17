using System.Diagnostics;
using App.Data.Payloads;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Service;

public class VideoService
{
    private readonly string Dir = "src\\Uploads";
    private readonly string ConvertingProg = "ffmpeg -i inputVideo.mp4 -profile:v baseline -level 3.0 -s 960x540 -start_number 0 -hls_time 10 -hls_list_size 0 -f hls outputVideo.m3u8";
    private readonly ContentRepository ctx = new();
    public async Task<IActionResult> UploadVideo(VideoUploadPayload payload)
    {
        var videoPath = WriteFile(payload);
        ConvertToM38u(videoPath);
    }

    private string WriteFile(VideoUploadPayload payload)
    {
        // ..makes file open to stream and
        // turns it into memory stream..
        var ors = payload.video.OpenReadStream();
        var ms = new MemoryStream();
        ors.CopyTo(ms);

        // ..gets the file bytes..
        var bytes = ms.GetBuffer();

        // ..creates a temporary directory 
        // and saves the file in it..
        var uploadingDir = Directory.CreateTempSubdirectory(Path.Combine(Dir, payload.name));
        var videoPath = Path.Combine(uploadingDir.FullName, "video.mp4");
        File.WriteAllBytes(videoPath, bytes);

        return videoPath;
    }

    private void ConvertToM38u(string videoPath)
    {
        using Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c " + BuildFfmpegCommand(Path.GetFileName(videoPath)),
				CreateNoWindow = true
			}
		};

        process.Start();
        process.WaitForExit();
    }

    private string BuildFfmpegCommand(string fileName)
    {
        return $"ffmpeg -i \"{fileName.Replace("\"", "\\\"")}\" " +
               "-profile:v baseline " +
               "-level 3.0 " +
               "-s 960x540 " +
               "-start_number 0 " +
               "-hls_time 10 " +
               "-hls_list_size 0 " +
               "-f hls " +
               $"\"{fileName.Replace("\"", "\\\"")}\"";
    }

    private void SaveIntoDb(string fileName)
    {
        var files = Directory.GetFiles(Path.GetDirectoryName(fileName)!);
        var header = files.FirstOrDefault(f => f.EndsWith(".m3u8"));
        var contentFiles = files.Where(f => f.EndsWith(".ts"));
        var dict = new Dictionary<string, Guid>();

        foreach(var file in contentFiles)
        {

        }
    }
}
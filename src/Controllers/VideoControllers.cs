namespace App.Controllers;

using App.Data.Payloads;
using App.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("video")]
public class VideoController : ControllerBase
{
    private readonly VideoService service;

    public VideoController(VideoService videoService)
        => service = videoService;

    [HttpPost("upload")]
    public async Task<ActionResult> UploadVideo([FromForm] VideoUploadPayload payload)
    {
        try 
        {
            var M3u8Header = await service.UploadVideo(payload);
            return Created("/video/upload", M3u8Header);
        }
        catch(Exception e) 
        {
            Console.WriteLine(e);
            return null;
        }

    }

    [HttpGet("play/{id}")]
    public async Task<ActionResult> PlayVideo(Guid id)
    {
        var content = await service.GetContentById(id);
        return Ok(content);
    }
}

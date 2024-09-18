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

    [HttpGet("upload")]
    public async Task<ActionResult> UploadVideo(VideoUploadPayload payload)
    {
        var M3u8Header = await service.UploadVideo(payload);
        return Created("/video/upload", M3u8Header);
    }

    [HttpGet("play/{id}")]
    public async Task<ActionResult> PlayVideo(Guid id)
    {
        var content = await service.GetContentById(id);
        return Ok(content);
    }
}

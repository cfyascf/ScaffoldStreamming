namespace App.Controllers;

using App.Data.Payloads;
using App.Data.Responses;
using App.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("video")]
public class VideoController(VideoService service) : ControllerBase
{

    [HttpPost("upload")]
    public async Task<ActionResult> UploadVideo([FromForm] VideoUploadPayload payload)
    {
        var response = await service.UploadVideo(payload);
        return Created("/video/upload", 
            new DefaultResponse<Guid>("Video uploaded successfully!", response)
        );
    }

    [HttpGet("play/{id}")]
    public async Task<ActionResult> PlayVideo(Guid id)
    {
        var content = await service.GetContentById(id);
        return File(content, "application/octet-stream");
    }
}

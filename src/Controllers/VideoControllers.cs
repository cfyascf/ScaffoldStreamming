using Microsoft.AspNetCore.Mvc;

namespace ScaffoldStreamming.Controllers;

[ApiController]
[Route("video")]
public class VideoController : ControllerBase
{

    [HttpGet("{id}")]
    public async IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

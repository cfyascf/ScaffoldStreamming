namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class VideoRepository(ApplicationContext ctx) : IVideoRepository 
{
    public async Task<Video> Create(Video video)
    {
        await ctx.AddAsync(video);
        await ctx.SaveChangesAsync();

        return video;
    }
}

namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class VideoRepository : IVideoRepository
{
    private readonly ApplicationContext ctx;

    public VideoRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Video> Create(Video video)
    {
        await ctx.AddAsync(video);
        await ctx.SaveChangesAsync();

        return video;
    }
}

namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationContext ctx;

    public LikeRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Like> Create(Like like)
    {
        await ctx.AddAsync(like);
        await ctx.SaveChangesAsync();

        return like;
    }
}

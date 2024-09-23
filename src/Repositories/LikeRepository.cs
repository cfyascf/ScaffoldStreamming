namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class LikeRepository(ApplicationContext ctx) : ILikeRepository
{
    public async Task<Like> Create(Like like)
    {
        await ctx.AddAsync(like);
        await ctx.SaveChangesAsync();

        return like;
    }
}

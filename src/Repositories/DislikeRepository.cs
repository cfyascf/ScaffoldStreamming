namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class DislikeRepository : IDislikeRepository
{
    private readonly ApplicationContext ctx;

    public DislikeRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Dislike> Create(Dislike dislike)
    {
        await ctx.AddAsync(dislike);
        await ctx.SaveChangesAsync();

        return dislike;
    }
}

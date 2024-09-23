namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class DislikeRepository(ApplicationContext ctx) : IDislikeRepository
{

    public async Task<Dislike> Create(Dislike dislike)
    {
        await ctx.AddAsync(dislike);
        await ctx.SaveChangesAsync();

        return dislike;
    }
}

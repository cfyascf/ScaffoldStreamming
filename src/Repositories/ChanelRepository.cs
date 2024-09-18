namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class ChanelRepository : IChanelRepository
{
    private readonly ApplicationContext ctx;

    public ChanelRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Chanel> Create(Chanel chanel)
    {
        await ctx.AddAsync(chanel);
        await ctx.SaveChangesAsync();

        return chanel;
    }
}

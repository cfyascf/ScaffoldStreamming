namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class ChanelRepository(ApplicationContext ctx) : IChanelRepository
{
    public async Task<Chanel> Create(Chanel chanel)
    {
        await ctx.AddAsync(chanel);
        await ctx.SaveChangesAsync();

        return chanel;
    }
}

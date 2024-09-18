namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class UserDataRepository : IUserDataRepository
{
    private readonly ApplicationContext ctx;

    public UserDataRepository(ApplicationContext context)
        => ctx = context;

    public async Task<UserData> Create(UserData user)
    {
        await ctx.AddAsync(user);
        await ctx.SaveChangesAsync();

        return user;
    }
}

namespace App.Repositories;

using System;
using App.Interfaces.Repositories;
using App.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository(ApplicationContext ctx) : IUserRepository
{
    public async Task<UserData> Create(UserData user)
    {
        await ctx.AddAsync(user);
        await ctx.SaveChangesAsync();

        return user;
    }

    public async Task<UserData> GetByEmail(string email)
    {
        return await ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UserData> GetById(Guid id)
    {
        return await ctx.Users.FindAsync(id);
    }
}

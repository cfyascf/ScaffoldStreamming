namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class SubscriptionRepository(ApplicationContext ctx) : ISubscriptionRepository
{
    public async Task<Subscription> Create(Subscription subscription)
    {
        await ctx.AddAsync(subscription);
        await ctx.SaveChangesAsync();

        return subscription;
    }
}

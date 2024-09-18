namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationContext ctx;

    public SubscriptionRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Subscription> Create(Subscription subscription)
    {
        await ctx.AddAsync(subscription);
        await ctx.SaveChangesAsync();

        return subscription;
    }
}

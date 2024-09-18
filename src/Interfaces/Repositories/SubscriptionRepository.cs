namespace App.Interfaces.Repositories;

using App.Models;

public interface ISubscriptionRepository
{
    public Task<Subscription> Create(Subscription subscription);
}

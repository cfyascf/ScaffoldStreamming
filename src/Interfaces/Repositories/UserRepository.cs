namespace App.Interfaces.Repositories;

using App.Models;

public interface IUserRepository
{
    public Task<UserData> Create(UserData user);
    public Task<UserData> GetByEmail(string email);
    public Task<UserData> GetById(Guid id);
}

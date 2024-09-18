namespace App.Interfaces.Repositories;

using App.Models;

public interface IUserDataRepository
{
    public Task<UserData> Create(UserData user);
}

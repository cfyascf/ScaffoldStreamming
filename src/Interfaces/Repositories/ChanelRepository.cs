namespace App.Interfaces.Repositories;

using App.Models;

public interface IChanelRepository
{
    public Task<Chanel> Create(Chanel chanel);
}

namespace App.Interfaces.Repositories;

using App.Models;

public interface ILikeRepository
{
    public Task<Like> Create(Like like);
}

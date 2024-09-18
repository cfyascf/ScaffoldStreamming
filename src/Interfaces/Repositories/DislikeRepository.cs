namespace App.Interfaces.Repositories;

using App.Models;

public interface IDislikeRepository
{
    public Task<Dislike> Create(Dislike dislike);
}

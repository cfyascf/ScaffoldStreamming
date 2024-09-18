namespace App.Interfaces.Repositories;

using App.Models;

public interface ICommentRepository
{
    public Task<Comment> Create(Comment comment);
}

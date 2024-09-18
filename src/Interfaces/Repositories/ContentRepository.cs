namespace App.Interfaces.Repositories;

using App.Models;

public interface IContentRepository
{
    public Task<Content> Create(Content content);
    public Task<Content> GetById(Guid id);
}
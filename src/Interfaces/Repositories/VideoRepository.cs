namespace App.Interfaces.Repositories;

using App.Models;

public interface IVideoRepository
{
    public Task<Video> Create(Video video);
}
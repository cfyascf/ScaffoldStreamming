namespace App.Interfaces.Repositories;

using App.Models;

public interface IPlaylistRepository
{
    public Task<Playlist> Create(Playlist playlist);
}

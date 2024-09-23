namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class PlaylistRepository(ApplicationContext ctx) : IPlaylistRepository
{
    public async Task<Playlist> Create(Playlist playlist)
    {
        await ctx.AddAsync(playlist);
        await ctx.SaveChangesAsync();

        return playlist;
    }
}

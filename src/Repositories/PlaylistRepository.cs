namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly ApplicationContext ctx;

    public PlaylistRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Playlist> Create(Playlist playlist)
    {
        await ctx.AddAsync(playlist);
        await ctx.SaveChangesAsync();

        return playlist;
    }
}

namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Playlist
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required UserData User { get; set; }
    public List<PlaylistVideo>? Videos { get; set; } = new();

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Playlist>(playlist => {
            playlist.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static Playlist CreateEntity(UserData user, string name)
    {
        var playlist = new Playlist
        {
            Name = name,
            User = user
        };

        user.Playlists!.Add(playlist);

        return playlist;
    }    
}
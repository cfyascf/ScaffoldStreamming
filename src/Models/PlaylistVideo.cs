namespace App.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class PlaylistVideo
{
    public Guid Id { get; set; }
    public required Playlist Playlist { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<PlaylistVideo>(pv => 
        {
            pv.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static PlaylistVideo CreateEntity(Playlist playlist, Video video)
    {
        var playlistVideo = new PlaylistVideo
        {
            Playlist = playlist,
            Video = video
        };

        playlist.Videos!.Add(playlistVideo);
        video.Playlists!.Add(playlistVideo);

        return playlistVideo;
    }

}
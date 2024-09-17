using Microsoft.EntityFrameworkCore;

public class Playlist
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required UserData User { get; set; }
    public ICollection<PlaylistVideo>? Videos { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Playlist>(playlist => {
            playlist.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }
}
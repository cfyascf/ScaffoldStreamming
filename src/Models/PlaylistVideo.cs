using Microsoft.EntityFrameworkCore;

public class PlaylistVideo
{
    public required Guid Id { get; set; }
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
}
namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Video
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public ICollection<PlaylistVideo>? Playlists { get; set; }
    public ICollection<Like>? Likes { get; set; }
    public ICollection<Dislike>? Dislikes { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Content>? Contents { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Video>(video => 
        {
            video.Property(v => v.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static Video CreateEntity(string title, string description)
    {
        var video = new Video
        {
            Title = title,
            Description = description
        };

        return video;
    }
}
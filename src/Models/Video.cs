namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Video
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<PlaylistVideo>? Playlists { get; set; } = new();
    public List<Like>? Likes { get; set; } = new();
    public List<Dislike>? Dislikes { get; set; } = new();
    public List<Comment>? Comments { get; set; } = new();
    public List<Content>? Contents { get; set; } = new();

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
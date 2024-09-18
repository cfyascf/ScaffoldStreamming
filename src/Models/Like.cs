namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Like
{
    public Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Like>(like => {
            like.Property(l => l.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static Like CreateEntity(UserData user, Video video)
    {
        var like = new Like {
            User = user,
            Video = video
        };

        user.Likes!.Add(like);
        video.Likes!.Add(like);

        return like;
    }
}
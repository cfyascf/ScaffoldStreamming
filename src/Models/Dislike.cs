namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Dislike
{
    public Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Dislike>(dislike => {
            dislike.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static Dislike CreateEntity(UserData user, Video video)
    {
        var dislike = new Dislike {
            User = user,
            Video = video
        };

        user.Dislikes!.Add(dislike);
        video.Dislikes!.Add(dislike);

        return dislike;
    }
}
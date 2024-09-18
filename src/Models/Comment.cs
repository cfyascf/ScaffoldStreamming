namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Comment
{
    public Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Comment>(comment => {
            comment.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }

    public static Comment CreateEntity(UserData user, Video video)
    {
        var comment = new Comment {
            User = user,
            Video = video
        };

        user.Comments!.Add(comment);
        video.Comments!.Add(comment);

        return comment;
    }
}
using Microsoft.EntityFrameworkCore;

public class Comment
{
    public required Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Comment>(comment => {
            comment.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }
}
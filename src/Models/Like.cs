using Microsoft.EntityFrameworkCore;

public class Like
{
    public required Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Like>(like => {
            like.Property(l => l.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }
}
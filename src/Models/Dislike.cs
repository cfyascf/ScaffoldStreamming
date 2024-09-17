using Microsoft.EntityFrameworkCore;

public class Dislike
{
    public required Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Video Video { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Dislike>(dislike => {
            dislike.Property(d => d.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }
}
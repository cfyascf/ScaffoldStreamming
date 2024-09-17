using Microsoft.EntityFrameworkCore;

public class Chanel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required UserData User { get; set; }
    public ICollection<Subscription>? Subscriptions { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Chanel>(chanel =>
        {
            chanel.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
            
            chanel.HasMany(c => c.Subscriptions)
                .WithOne(s => s.Chanel)
                .OnDelete(DeleteBehavior.Cascade);

            chanel.HasOne(c => c.User)
                .WithMany(s => s.Chanels)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class Subscription
{
    public required Guid Id { get; set; }
    public required UserData User { get; set; }
    public required Chanel Chanel { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Subscription>(sub => 
        {
            sub.Property(s => s.Id)
                .HasDefaultValueSql("NEWID()");
            
            sub.HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .OnDelete(DeleteBehavior.NoAction);
                
            sub.HasOne(s => s.Chanel)
                .WithMany(c => c.Subscriptions)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
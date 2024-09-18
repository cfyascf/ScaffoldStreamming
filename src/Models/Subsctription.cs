namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class Subscription
{
    public Guid Id { get; set; }
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

    public static Subscription CreateEntity(UserData user, Chanel chanel)
    {
        var subscription = new Subscription
        {
            User = user,
            Chanel = chanel
        };

        user.Subscriptions!.Add(subscription);
        chanel.Subscriptions!.Add(subscription);

        return subscription;
    }

}
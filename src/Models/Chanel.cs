namespace App.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Chanel
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Introduction { get; set; }
    public DateTime CreatedAt { get; set; }
    public required UserData User { get; set; }
    public List<Subscription>? Subscriptions { get; set; } = new();

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

            chanel.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        });
    }

    public static Chanel CreateEntity(string name, string introduction, UserData user)
    {
        var chanel = new Chanel {
            Name = name,
            Introduction = introduction,
            User = user
        };

        user.Chanels!.Add(chanel);

        return chanel;
    }
}
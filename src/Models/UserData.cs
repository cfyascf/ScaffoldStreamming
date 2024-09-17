using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class UserData
{
    public required Guid Id { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Password { get; set; }
    public required int Role { get; set; }
    public ICollection<Chanel>? Chanels { get; set; }
    public ICollection<Subscription>? Subscriptions { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<UserData>(user => 
        {
            user.Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

            user.Property(u => u.Fullname)
                .HasMaxLength(50);

            user.Property(u => u.Role)
                .HasDefaultValue(1);

            user.HasMany(u => u.Subscriptions)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);
                
            user.HasMany(c => c.Chanels)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
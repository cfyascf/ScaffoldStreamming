namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class UserData
{
    public Guid Id { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Password { get; set; }
    public required int Role { get; set; }
    public List<Chanel>? Chanels { get; set; } = new();
    public List<Subscription>? Subscriptions { get; set; } = new();
    public List<Comment>? Comments { get; set; } = new();
    public List<Dislike>? Dislikes { get; set; } = new();
    public List<Like>? Likes { get; set; } = new();
    public List<Playlist>? Playlists { get; set; } = new();

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
                
            user.HasMany(u => u.Chanels)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);

            user.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);

            user.HasMany(u => u.Dislikes)
                .WithOne(d => d.User)
                .OnDelete(DeleteBehavior.Cascade);

            user.HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .OnDelete(DeleteBehavior.Cascade);

            user.HasMany(u => u.Playlists)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public static UserData CreateEntity(string fullname, string email, DateTime birthDate, string password, int role = 1)
    {
        var user = new UserData
        {
            Fullname = fullname,
            Email = email,
            BirthDate = birthDate,
            Password = password,
            Role = role
        };

        return user;
    }

}
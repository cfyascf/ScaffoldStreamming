namespace App.Models;

using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<UserData> Users { get; set; }
    public DbSet<Chanel> Chanels { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<PlaylistVideo> PlaylistVideos { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Dislike>  Dislikes { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=SJP-C-00002\\SQLEXPRESS01;Initial Catalog=scaffoldstreammingdb;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        UserData.BuildEntity(modelBuilder);
        Chanel.BuildEntity(modelBuilder);
        Subscription.BuildEntity(modelBuilder);
        Playlist.BuildEntity(modelBuilder);
        PlaylistVideo.BuildEntity(modelBuilder);
        Video.BuildEntity(modelBuilder);
        Content.BuildEntity(modelBuilder);
        Comment.BuildEntity(modelBuilder);
        Like.BuildEntity(modelBuilder);
    
        Dislike.BuildEntity(modelBuilder);
    }
}
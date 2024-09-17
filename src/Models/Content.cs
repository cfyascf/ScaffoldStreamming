using Microsoft.EntityFrameworkCore;

public class Content
{
    public required Guid Id { get; set; }
    public required byte[] Data { get; set; }
    public required Video Video { get; set; }
    public required bool IsHeader { get; set; }

    public static void BuildEntity(ModelBuilder model)
    {
        model.Entity<Content>(content => {
            content.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
        });
    }
}
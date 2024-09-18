namespace App.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Content
{
    [Key]
    public Guid Id { get; set; }
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

    public static Content CreateEntity(byte[] data, Video video, bool IsHeader)
    {
        var content = new Content {
            Data = data,
            Video = video,
            IsHeader = IsHeader
        };

        video.Contents!.Add(content);

        return content;
    }
}

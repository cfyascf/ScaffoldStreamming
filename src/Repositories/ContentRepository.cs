namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class ContentRepository(ApplicationContext ctx) : IContentRepository
{

    public async Task<Content> Create(Content content)
    {
        await ctx.AddAsync(content);
        await ctx.SaveChangesAsync();

        return content;
    }

    public async Task<Content> GetById(Guid id)
    {
        return await ctx.Contents.FindAsync(id);
    }
}
namespace App.Repositories;

public class ContentRepository
{
    private readonly AppContext ctx;

    public ContentRepository(AppContext context)
        => ctx = context;

    public async Task<Content> Create(Content content)
    {
        await ctx.AddAsync(content);
        await ctx.SaveChangesAsync();

        return content;
    }
}
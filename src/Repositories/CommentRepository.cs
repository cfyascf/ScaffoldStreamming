namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationContext ctx;

    public CommentRepository(ApplicationContext context)
        => ctx = context;

    public async Task<Comment> Create(Comment comment)
    {
        await ctx.AddAsync(comment);
        await ctx.SaveChangesAsync();

        return comment;
    }
}

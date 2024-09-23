namespace App.Repositories;

using App.Interfaces.Repositories;
using App.Models;

public class CommentRepository(ApplicationContext ctx) : ICommentRepository
{

    public async Task<Comment> Create(Comment comment)
    {
        await ctx.AddAsync(comment);
        await ctx.SaveChangesAsync();

        return comment;
    }
}

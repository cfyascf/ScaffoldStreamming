using App.Models;

public class UnitOfWork(ApplicationContext _ctx)
{
    public async Task SaveChanges()
    {
        await _ctx.SaveChangesAsync();
    }
}
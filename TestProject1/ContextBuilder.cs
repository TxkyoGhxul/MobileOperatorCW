using Microsoft.EntityFrameworkCore;
using Persistence;
using Web.Middlewares;

namespace TestProject1;
public class ContextBuilder : IDisposable
{
    private readonly ApplicationDbContext _context;

    public ContextBuilder()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.EnsureCreated();

        DbInitializer.Initialize(context);

        _context = context;
    }

    public ApplicationDbContext GetContext() => _context;

    public void Dispose() => _context.Dispose();
}

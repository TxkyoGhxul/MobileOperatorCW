using Microsoft.EntityFrameworkCore;
using Persistence;
using Web.Middlewares;

namespace TestProject1;

public class UnitTest1
{
    private readonly ApplicationDbContext _context;

    public UnitTest1()
    {
        var builder = new ContextBuilder();
        _context = builder.GetContext();
    }

    [Fact]
    public void Test1()
    {
        Assert.True(_context.Users.Count() > 5);
    }
}
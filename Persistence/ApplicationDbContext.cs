using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Call> Calls { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<InternetTraffic> InternetTraffics { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<SMS> SMSs { get; set; } = null!;
    public DbSet<Tariff> Tariffs { get; set; } = null!;
    public DbSet<TariffType> TariffTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}

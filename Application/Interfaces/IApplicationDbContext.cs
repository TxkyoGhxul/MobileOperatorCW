using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Call> Calls { get; set; }
    DbSet<Contract> Contracts { get; set; }
    DbSet<Employee> Employees { get; set; }
    DbSet<InternetTraffic> InternetTraffics { get; set; }
    DbSet<Position> Positions { get; set; }
    DbSet<SMS> SMSs { get; set; }
    DbSet<Tariff> Tariffs { get; set; }
    DbSet<TariffType> TariffTypes { get; set; }
    DbSet<User> Users { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

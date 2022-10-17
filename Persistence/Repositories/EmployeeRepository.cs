using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class EmployeeRepository : BaseEFRepository<Employee>
{
    public override IQueryable<Employee> Items =>
        base.Items.Include(empl => empl.Contracts).Include(empl => empl.Position);

    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
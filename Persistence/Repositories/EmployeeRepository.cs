using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class EmployeeRepository : BaseEFRepository<Employee>
{
    public override IQueryable<Employee> ItemsForDetails =>
        base.ItemsForDetails.Include(empl => empl.Contracts).Include(empl => empl.Position);

    public override IQueryable<Employee> AllItems =>
        base.AllItems.Include(empl => empl.Contracts).Include(empl => empl.Position);

    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
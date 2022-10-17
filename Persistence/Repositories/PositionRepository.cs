using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class PositionRepository : BaseEFRepository<Position>
{
    public override IQueryable<Position> Items => base.Items.Include(pos => pos.Employees);

    public PositionRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

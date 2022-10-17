using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class InternetTrafficRepository : BaseEFRepository<InternetTraffic>
{
    public override IQueryable<InternetTraffic> Items => base.Items.Include(x => x.Contract);

    public InternetTrafficRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
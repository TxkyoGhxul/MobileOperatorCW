using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class InternetTrafficRepository : BaseEFRepository<InternetTraffic>
{
    public override IQueryable<InternetTraffic> AllItems => base.AllItems.Include(x => x.Contract);
    public override IQueryable<InternetTraffic> ItemsForDetails => base.ItemsForDetails.Include(x => x.Contract);

    public InternetTrafficRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
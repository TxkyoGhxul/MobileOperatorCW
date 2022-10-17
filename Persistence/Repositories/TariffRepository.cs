using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class TariffRepository : BaseEFRepository<Tariff>
{
    public override IQueryable<Tariff> Items => 
        base.Items.Include(x => x.TariffType).Include(x => x.Contracts);

    public TariffRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

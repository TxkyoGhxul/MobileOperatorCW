using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class TariffRepository : BaseEFRepository<Tariff>
{
    public override IQueryable<Tariff> AllItems =>
        base.AllItems.Include(x => x.TariffType);

    public override IQueryable<Tariff> ItemsForDetails =>
        base.ItemsForDetails.Include(x => x.TariffType).Include(x => x.Contracts);

    public TariffRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class TariffTypeRepository : BaseEFRepository<TariffType>
{
    public override IQueryable<TariffType> ItemsForDetails => base.ItemsForDetails.Include(x => x.Tariffs);

    public TariffTypeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

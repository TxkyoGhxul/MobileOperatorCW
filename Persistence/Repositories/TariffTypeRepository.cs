using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class TariffTypeRepository : BaseEFRepository<TariffType>
{
    public override IQueryable<TariffType> Items => base.Items.Include(x => x.Tariffs);

    public TariffTypeRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

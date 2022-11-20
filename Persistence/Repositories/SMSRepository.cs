using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class SMSRepository : BaseEFRepository<SMS>
{
    public override IQueryable<SMS> AllItems => base.AllItems.Include(x => x.Contract);
    public override IQueryable<SMS> ItemsForDetails => base.ItemsForDetails.Include(x => x.Contract);

    public SMSRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

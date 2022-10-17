using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class SMSRepository : BaseEFRepository<SMS>
{
    public override IQueryable<SMS> Items => base.Items.Include(x => x.Contract);

    public SMSRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

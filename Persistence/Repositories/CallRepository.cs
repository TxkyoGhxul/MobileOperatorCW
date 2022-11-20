using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class CallRepository : BaseEFRepository<Call>
{
    public override IQueryable<Call> AllItems => base.AllItems.Include(x => x.Contract);
    public override IQueryable<Call> ItemsForDetails => base.ItemsForDetails.Include(x => x.Contract);

    public CallRepository(ApplicationDbContext context) : base(context) { }
}

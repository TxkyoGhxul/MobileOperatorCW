using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class CallRepository : BaseEFRepository<Call>
{
    public override IQueryable<Call> Items => base.Items.Include(x => x.Contract);

    public CallRepository(ApplicationDbContext context) : base(context) { }
}

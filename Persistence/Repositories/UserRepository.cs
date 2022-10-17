using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class UserRepository : BaseEFRepository<User>
{
    public override IQueryable<User> Items => base.Items.Include(x => x.Contracts);

    public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

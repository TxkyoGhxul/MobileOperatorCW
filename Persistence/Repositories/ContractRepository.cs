using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class ContractRepository : BaseEFRepository<Contract>
{
    public override IQueryable<Contract> ItemsForDetails =>
        base.ItemsForDetails
            .Include(contract => contract.User)
            .Include(contract => contract.Employee)
            .Include(contract => contract.Tariff)
            .Include(contract => contract.Calls)
            .Include(contract => contract.InternetTraffics)
            .Include(contract => contract.SMSs);

    public override IQueryable<Contract> AllItems =>
        base.AllItems
            .Include(contract => contract.User)
            .Include(contract => contract.Employee)
            .Include(contract => contract.Tariff);

    public ContractRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

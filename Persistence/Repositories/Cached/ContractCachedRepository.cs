using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class ContractCachedRepository : BaseCachedRepository<Contract>
{
    public ContractCachedRepository(IFullRepository<Contract> repository, IMemoryCache cache) :
        base(repository, cache, "contracts")
    {
    }
}

using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class SMSCachedRepository : BaseCachedRepository<SMS>
{
    public SMSCachedRepository(IFullRepository<SMS> repository, IMemoryCache cache) :
        base(repository, cache, "SMSs")
    {
    }
}

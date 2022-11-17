using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class InternetTrafficCachedRepository : BaseCachedRepository<InternetTraffic>
{
    public InternetTrafficCachedRepository(IFullRepository<InternetTraffic> repository, IMemoryCache cache) :
        base(repository, cache, "internetTraffics")
    {
    }
}

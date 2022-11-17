using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class CallCachedRepository : BaseCachedRepository<Call>
{
    public CallCachedRepository(IFullRepository<Call> repository, IMemoryCache cache) :
        base(repository, cache, "calls")
    {
    }
}

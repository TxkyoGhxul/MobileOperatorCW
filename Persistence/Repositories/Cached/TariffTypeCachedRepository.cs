using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class TariffTypeCachedRepository : BaseCachedRepository<TariffType>
{
    public TariffTypeCachedRepository(IFullRepository<TariffType> repository, IMemoryCache cache) :
        base(repository, cache, "tariffTypes")
    {
    }
}

using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class TariffCachedRepository : BaseCachedRepository<Tariff>
{
    public TariffCachedRepository(IFullRepository<Tariff> repository, IMemoryCache cache) :
        base(repository, cache, "tariffs")
    {
    }
}

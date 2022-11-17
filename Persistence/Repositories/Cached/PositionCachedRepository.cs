using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class PositionCachedRepository : BaseCachedRepository<Position>
{
    public PositionCachedRepository(IFullRepository<Position> repository, IMemoryCache cache) :
        base(repository, cache, "positions")
    {
    }
}

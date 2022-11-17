using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class UserCachedRepository : BaseCachedRepository<User>
{
    public UserCachedRepository(IFullRepository<User> repository, IMemoryCache cache) :
        base(repository, cache, "users")
    {
    }
}

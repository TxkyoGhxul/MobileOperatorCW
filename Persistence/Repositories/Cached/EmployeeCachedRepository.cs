using Application.Interfaces;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Persistence.Repositories.Base;

namespace Persistence.Repositories.Cached;
public class EmployeeCachedRepository : BaseCachedRepository<Employee>
{
    public EmployeeCachedRepository(IFullRepository<Employee> repository, IMemoryCache cache) :
        base(repository, cache, "employees")
    {
    }
}

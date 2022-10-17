using Domain.Base;

namespace Application.Interfaces;
public interface IFullRepository<T> : IRepositoryDataKeeper<T>, IRepository<T>,
    IAsyncRepository<T> where T : class, IEntity<Guid>, new()
{

}

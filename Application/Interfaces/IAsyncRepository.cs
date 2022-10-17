using Domain.Base;

namespace Application.Interfaces;
public interface IAsyncRepository<T> where T : class, IEntity<Guid>, new()
{
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> InsertAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> SelectAllAsync(CancellationToken cancellationToken = default);
    Task<T> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default);
}

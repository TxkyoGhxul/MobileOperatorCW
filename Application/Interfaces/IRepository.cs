using Domain.Base;

namespace Application.Interfaces;
public interface IRepository<T> where T : class, IEntity<Guid>, new()
{
    void Update(T entity);
    void Delete(Guid id);
    Guid Insert(T entity);
    List<T> SelectAll();
    T SelectById(Guid id);
}

namespace Application.Interfaces;
public interface IRepositoryDataKeeper<T> where T : class
{
    IQueryable<T> AllItems { get; }
}

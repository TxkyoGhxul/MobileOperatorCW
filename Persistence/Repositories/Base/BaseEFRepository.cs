using Application.Interfaces;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Base;
public class BaseEFRepository<T> : IFullRepository<T> where T : class, IEntity<Guid>, new()
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _set;

    protected BaseEFRepository(ApplicationDbContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public virtual IQueryable<T> Items => _set;

    public void Delete(Guid id)
    {
        _context.Remove(new T { Id = id });
        _context.SaveChanges();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _context.Remove(new T { Id = id });
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public Guid Insert(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();

        return entity.Id;
    }

    public async Task<Guid> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return entity.Id;
    }

    public List<T> SelectAll() => Items.ToList();

    public async Task<List<T>> SelectAllAsync(CancellationToken cancellationToken = default)
    {
        Thread.Sleep(2000);
        return await Items.ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public T SelectById(Guid id) => Items.FirstOrDefault(x => x.Id.Equals(id));

    public async Task<T> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Items.FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

    public void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}

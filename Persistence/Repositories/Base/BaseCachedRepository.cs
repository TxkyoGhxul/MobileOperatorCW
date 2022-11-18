using Application.Interfaces;
using Domain.Base;
using Microsoft.Extensions.Caching.Memory;

namespace Persistence.Repositories.Base;
public abstract class BaseCachedRepository<T> : IFullRepository<T> where T : class, IEntity<Guid>, new()
{
    protected readonly string CACHE_KEY;

    protected readonly IFullRepository<T> _repository;
    protected readonly IMemoryCache _cache;

    protected BaseCachedRepository(IFullRepository<T> repository, IMemoryCache cache, string cacheKey)
    {
        _repository = repository;
        _cache = cache;
        CACHE_KEY = cacheKey;
    }

    public IQueryable<T> Items => _repository.Items;

    public virtual void Delete(Guid id)
    {
        _repository.Delete(id);

        RemoveIfContainsKeys(id);
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(id, cancellationToken);

        RemoveIfContainsKeys(id);
    }

    public virtual Guid Insert(T entity)
    {
        var id = _repository.Insert(entity);

        RemoveIfContainsKeys(entity.Id, true, false);

        return id;
    }

    public virtual async Task<Guid> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        var id = await _repository.InsertAsync(entity, cancellationToken);

        RemoveIfContainsKeys(entity.Id, true, false);

        return id;
    }

    public virtual List<T> SelectAll()
    {
        if (!_cache.TryGetValue(CACHE_KEY, out List<T> entities))
        {
            entities = _repository.SelectAll();

            _cache.Set(CACHE_KEY, entities, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
            });
        }

        return entities;
    }

    public virtual async Task<List<T>> SelectAllAsync(CancellationToken cancellationToken = default)
    {
        if (!_cache.TryGetValue(CACHE_KEY, out List<T> entities))
        {
            entities = await _repository.SelectAllAsync(cancellationToken);

            _cache.Set(CACHE_KEY, entities, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
            });
        }

        return entities;
    }

    public virtual T SelectById(Guid id)
    {
        if (!_cache.TryGetValue(id, out T entity))
        {
            entity = _repository.SelectById(id);

            _cache.Set(id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
            });
        }

        return entity;
    }

    public virtual async Task<T> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (!_cache.TryGetValue(id, out T entity))
        {
            entity = await _repository.SelectByIdAsync(id, cancellationToken);

            _cache.Set(id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
            });
        }

        return entity;
    }

    public virtual void Update(T entity)
    {
        RemoveIfContainsKeys(entity.Id);

        _cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
        });

        _repository.Update(entity);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        RemoveIfContainsKeys(entity.Id);

        _cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(262)
        });

        await _repository.UpdateAsync(entity, cancellationToken);
    }

    protected virtual void RemoveIfContainsKeys(Guid entityId, bool checkAll = true, bool checkSingle = true)
    {
        if (checkSingle)
        {
            if (_cache.TryGetValue(entityId, out _))
                _cache.Remove(entityId);
        }

        if (checkAll)
        {
            if (_cache.TryGetValue(CACHE_KEY, out _))
                _cache.Remove(CACHE_KEY);
        }
    }
}

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Repositories;

namespace POS.Infrastructure.DAL.Repositories;

internal class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        Context = context;
        _dbSet = Context.Set<T>();
    }

    public async Task<IEnumerable<T>> FindAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate,
                                      params Expression<Func<T, object>>[] includes)
    {
        return await FindAll(includes).SingleOrDefaultAsync(predicate);
    }

    public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> items = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                items = items.Include(include);
            }
        }
        return items;
    }

    public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate,
                                         params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> items = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                items = items.Include(include);
            }
        }
        return _dbSet.Where(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }

    public Task<bool> AllAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.AllAsync(predicate);
    }
}



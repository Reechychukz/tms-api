using Application.Contracts.Persistence;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : AuditableEntity
    {
        protected readonly AppDbContext _dbcontext;

        public RepositoryBase(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbcontext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbcontext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
    }
}

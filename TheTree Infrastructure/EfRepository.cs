using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    /// <summary>
    ///     "There's some repetition here - couldn't we have some the sync methods call the async?"
    ///     https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IAsyncRepository<T> /*IRepository<T>*/ where T : BaseEntity
    {
        //private readonly ILogger<EfRepository<T>> _logger;
        protected readonly ProjectContext _dbContext;

        public EfRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetAsync(ISpecification<T> spec)
        {
            T entity = null;
            try
            {
                IQueryable<T> specified = ApplySpecification(spec);
                entity = await specified.FirstAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entity;
        }

        public T Get(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefault();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IReadOnlyList<T> ListAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> ListFilterAsync(ISpecification<T> spec)
        {
            return await ApplySpecificationFilter(spec).ToListAsync();
        }

        public DbSet<T> GetContext()
        {
            return _dbContext.Set<T>();
        }

        public IReadOnlyList<T> List(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public virtual IReadOnlyList<T> Query(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(predicate);
            return query.ToList();
        }

        public async Task<IReadOnlyList<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public virtual async Task<T> QueryAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<T> ApplySpecificationFilter(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQueryFilter(_dbContext.Set<T>(), spec);
        }
    }
}
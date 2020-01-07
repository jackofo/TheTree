using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _context;

        //private EfRepository<T> _repository;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(ProjectContext context)
        {
            _context = context;
        }

        public IAsyncRepository<T> RepositoryAsync<T>() where T : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IAsyncRepository<T>;
            }

            IAsyncRepository<T> repo = new EfRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Clear()
        {
            repositories.Clear();
        }

        //public IRepository<T> Repository<T>() where T : BaseEntity
        //{
        //    if (repositories.Keys.Contains(typeof(T)))
        //    {
        //        return repositories[typeof(T)] as IRepository<T>;
        //    }

        //    IRepository<T> repo = new EfRepository<T>(_context);
        //    repositories.Add(typeof(T), repo);
        //    return repo;
        //}

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
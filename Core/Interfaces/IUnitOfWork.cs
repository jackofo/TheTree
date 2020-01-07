using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAsyncRepository<T> RepositoryAsync<T>() where T : BaseEntity;
        //IRepository<T> Repository { get; }

        void Save();
        void Clear();
        Task SaveAsync();
    }
}
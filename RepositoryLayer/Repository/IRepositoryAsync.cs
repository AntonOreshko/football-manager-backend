using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Interfaces;

namespace RepositoryLayer.Repository
{
    public interface IRepositoryAsync<T> where T : IDatabaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(long id);

        Task<T> GetWithRelationsAsync(long id);

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task SaveChangesAsync();
    }
}

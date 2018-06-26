using System.Collections.Generic;
using DomainModels.Interfaces;

namespace RepositoryLayer.Repository
{
    public interface IRepository<T> where T : IDatabaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(long id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Remove(T entity);

        void Clear();

        void SaveChanges();
    }
}

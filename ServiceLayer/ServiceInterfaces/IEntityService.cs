using System.Collections.Generic;
using DomainModels.Interfaces;
using RepositoryLayer.Repository;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IEntityService<T> where T : IDatabaseEntity
    {
        IRepository<T> Repository { get; set; }

        IEnumerable<T> GetAll();

        T Get(long id);

        T GetWithRelations(long id);

        void Insert(T entity);

        void Update(T entity);

        void Clear();

        void SaveChanges();
    }
}

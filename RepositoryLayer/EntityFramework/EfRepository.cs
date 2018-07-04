using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfRepository<T> : IRepository<T>, IRepositoryAsync<T> where T : class, IDatabaseEntity
    {
        protected readonly FootballManagerContext Context;

        protected readonly DbSet<T> Entities;

        public EfRepository(FootballManagerContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return Entities.SingleOrDefault(s => s.Id == id);
        }

        public virtual T GetWithRelations(long id)
        {
            return Entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            Entities.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            Entities.RemoveRange(entities);
        }

        public void Clear()
        {
            Context.RemoveRange(Entities);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(long id)
        {
            return Entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task<T> GetWithRelationsAsync(long id)
        {
            return Entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Entities.AddAsync(entity);
        }

        public Task InsertRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            return Entities.AddRangeAsync(entities);
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.Repository;

namespace RepositoryLayer.EntityFramework
{
    public class EfRepository<T> : IRepository<T> where T : class, IDatabaseEntity
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

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Remove(entity);
        }

        public void Clear()
        {
            Context.RemoveRange(Entities);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}

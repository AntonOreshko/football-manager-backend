﻿using System.Collections.Generic;
using BusinessLayer.ServiceInterfaces;
using DomainModels.Interfaces;
using RepositoryLayer.Repository;

namespace BusinessLayer.Services
{
    public class EntityService<T> : IEntityService<T> where T : IDatabaseEntity
    {
        public IRepository<T> Repository { get; set; }

        public EntityService(IRepository<T> repository)
        {
            Repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T Get(long id)
        {
            return Repository.Get(id);
        }

        public void Insert(T entity)
        {
            Repository.Insert(entity);
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }

        public void SaveChanges()
        {
            Repository.SaveChanges();
        }
    }
}
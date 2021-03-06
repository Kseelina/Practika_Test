﻿//using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Interfaces;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        // Инкапсуляция, мы их создаём, а не берём извне
        protected DbContext _dbContext;
        protected readonly IDbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual T Read(Guid Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }

        public virtual IEnumerable<T> Readall()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

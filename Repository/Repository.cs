using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
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

        public virtual T Read(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

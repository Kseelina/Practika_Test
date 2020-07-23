//using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Interfaces;

namespace Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        


        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Read(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Readall()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

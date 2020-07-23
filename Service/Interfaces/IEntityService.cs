using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
   public interface IEntityServices<T> : IService where T : EntityBase
    {
        void Create(T entity);
        T Read(Guid Id);
        IEnumerable<T> Readall();
        void Update(T entity);
        void Delete(T entity);
    }
}

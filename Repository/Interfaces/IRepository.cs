using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{/// <summary>
 /// В репозитории будут участвовать только те классы, которые наследуются EntityBase
 /// </summary>
 /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: EntityBase
    {
        void Create(T entity);
        T Read(Guid Id);
        IEnumerable<T> Readall();
        void Update(T entity);
        void Delete(T entity);
        void Save(); 


    }
}

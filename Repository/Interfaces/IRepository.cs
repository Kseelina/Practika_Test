using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{/// <summary>
/// Хранилище
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        void Create(T entity);
        T Read(Guid id); // вернёт объект который нам нужен (зависит от ИД)
        IEnumerable<T> ReadAll(); // IEnumerable - универсальное перечисление
        void Update(T entity);
        void Delete(T entity);
    }
}

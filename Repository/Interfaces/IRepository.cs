using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{/// <summary>
/// Хранилище. В репозитории будут участвовать только те классы, которые наследуются EntityBase
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntityBase
    { // <T>  - обозначение универсальности
      // ":" - определяет наследование
        void Create(T entity); // создаст объект
        T Read(Guid id); // вернёт объект который нам нужен (зависит от ИД)
        IEnumerable<T> ReadAll(); // IEnumerable - универсальное перечисление
        void Update(T entity); //перезапись
        void Delete(T entity);  // удаление объекта
    }
}

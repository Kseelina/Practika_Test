using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{/// <summary>
/// Единица работы, производит фиксацию изменения(сохранение), и чистит память
/// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }   
}

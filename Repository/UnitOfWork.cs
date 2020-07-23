using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            Displose(true);

        }

        public void Save()
        {
            _dbContext.SaveChanges();
            GC.SuppressFinalize(this);
        }
        private void Displose (bool disploing) // нужна нам очистка или нет
        {
            if (disploing)
            {
                if (_dbContext!=null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}

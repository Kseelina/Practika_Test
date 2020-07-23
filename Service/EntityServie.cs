using Models;
using Repository;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : EntityBase
    {
        private IRepository<T> _repository;
        private IUnitOfWork _unitOfWork;

        public EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual void Create(T entity)
        {
            // Проверка на корректность введённых данных:
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Create(entity);
            _unitOfWork.Save();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Delete(entity);
            _unitOfWork.Save();
        }

        public virtual T Read(Guid id)
        {
            return _repository.Read(id);
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return _repository.ReadAll().ToList();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Update(entity);
            _unitOfWork.Save();
        }
    }
}

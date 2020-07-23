using Models;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public abstract class EntityServices<T> : IEntityServices<T> where T : EntityBase
    {
        IRepository<T> _repository;
        private IUnitOfWork _unitOfWork;

        public EntityServices(IUnitOfWork unitOfWork, IRepository<T> repository) 
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }



        public virtual void Create(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("Ошибка из БД");}
            _repository.Create(entity);
            _unitOfWork.Save();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("Ошибка из БД"); }
            _repository.Delete(entity);
            _unitOfWork.Save();
        }

        public virtual T Read(Guid Id)
        {
            return _repository.Read(Id);
        }

        public virtual IEnumerable<T> Readall()
        {
            return _repository.Readall().ToList(); // ToList() для закрытия потока, чтобы не висело постоянное обращение к БД
        }

        public virtual void Update(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("Ошибка из БД"); }
            _repository.Update(entity);
            _unitOfWork.Save();
        }
}

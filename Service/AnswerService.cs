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
    public class AnswerService : EntityService<AnswerBase>, IAnswerService
    {
        public AnswerService(IUnitOfWork unitOfWork, IRepository<AnswerBase> repository) : base(unitOfWork, repository)
        {

        }
    }
}

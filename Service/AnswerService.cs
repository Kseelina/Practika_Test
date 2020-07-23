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
    public class AnswerService : EntityServices<AnswerBase>, IQuestionService
    {
        public AnswerService(IUnitOfWork unitOfWork, IRepository<AnswerBase> repository) : base(unitOfWork, repository)
        {

        }
    }
}

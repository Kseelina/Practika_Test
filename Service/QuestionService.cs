using Models;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class QuestionService : EntityService<QuestionBase>, IQuestionService
    {
        public QuestionService(IUnitOfWork unitOfWork, IRepository<QuestionBase> repository) : base(unitOfWork, repository)
        {

        }
    }
}

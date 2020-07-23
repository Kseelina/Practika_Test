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
   public class QuestionService : EntityServices<QuestionBase>, IQuestionService
    {
        public QuestionService(IUnitOfWork unitOfWork, IRepository <QuestionBase> repository) : base(unitOfWork, repository)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Interfaces;

namespace Repository
{
   public class QuestionRepository : Repository<QuestionBase>, IQuestionRepository
    {
        public QuestionRepository(DbContext dbContext): base(dbContext) { }
    }
}

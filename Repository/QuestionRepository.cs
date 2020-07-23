using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{/// <summary>
/// Хранилище для вопросов
/// </summary>
    public class QuestionRepository : Repository<QuestionBase>, IQuestionRepository
    {
        public QuestionRepository(DbContext dbContext) : base(dbContext) { }
    }
}

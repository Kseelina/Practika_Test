using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// оздание своего контекста для связи(работы) с БД
    /// </summary>
    ///  // ":" - определяет наследование
   
    public class QbContext : DbContext
    {
        public QbContext() : base("name= QBaseEntities") // вызываем базовый конструктор: 
            // base - имя подключения
        {

        }
        public DbSet<QuestionBase> Questions { set; get; }
        public DbSet<AnswerBase> Answers { set; get; }
// Далее создаём связь между моделями и БД (полиморфизм) ; protected override - запретить перезапись
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionBase>().ToTable("Questions");
            modelBuilder.Entity<AnswerBase>().ToTable("Answers");
        }
    }
}

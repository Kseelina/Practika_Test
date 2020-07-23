using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // пространство имён для работы с DbContext
using Models;

namespace Data
{
    // : - определяет наследование
    /// <summary>
    /// Создание своего контекста для работы с БД
    /// </summary>
    public class QbContext : DbContext
    {
        /// <summary>
        /// base - имя подключения
        /// </summary>
        public QbContext() : base("name=QBaseEntitis")
        {

        }
        public DbSet<QuestionBase> Questions { get; set; }
        public DbSet<QuestionBase> Answers { get; set; }
        // Далее создаём связь между моделями и БД (полиморфизм) ; protected override - запретить перезапись

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionBase>().ToTable("Questions");
            modelBuilder.Entity<AnswerBase>().ToTable("Answers");
        }

    }
}

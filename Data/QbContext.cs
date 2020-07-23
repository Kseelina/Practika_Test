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
    /// Для связи с БД
    /// </summary>
    public class QbContext : DbContext
    {
        public QbContext() : base("name= QBaseEntities") // вызываем базовый конструктор
        {

        }
        public DbSet<QuestionBase> Questions { set; get; }
        public DbSet<AnswerBase> Answers { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionBase>().ToTable("Questions");
            modelBuilder.Entity<AnswerBase>().ToTable("Answers");
        }
    }
}

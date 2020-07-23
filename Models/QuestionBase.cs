using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Модель для БД, по названиям полей в таблице Questions
    /// </summary>
    [Table("Questions")]
    public class QuestionBase : EntityBase
    {
        public string QuestText { get; set; }
        public string QuestImage { get; set; }

        public virtual List<AnswerBase> Answers { get; set; }

    }
}

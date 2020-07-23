using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{ /// <summary>
  /// Модель для БД, по названиям полей в таблице Questions
  /// </summary>
    [Table("Questions")]
    public class QuestionBase : EntityBase
    {
        public string QuestText { set; get; }
        public string QuestImage { set; get; }
        public virtual List<AnswerBase> Answers { set; get; }
    }
}

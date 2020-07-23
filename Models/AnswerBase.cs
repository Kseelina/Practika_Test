using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{/// <summary>
    /// Модель для БД, по названиям полей в таблице Answers
/// </summary> 
    [Table("Answers")]
    public class AnswerBase : EntityBase
    {
        public string AnswText { set; get; }
        public string AnswImage { set; get; }
        public int AnswIsRight { set; get; }
        public string QuestionId { set; get; }
        //Внешний ключ:
        [ForeignKey("QuestionId")]
        public virtual QuestionBase Question { set; get; }
        /*virtual - создаёт виртуальное поле, которое не связано с БД, но оно позволяет получать всю инфу*/
    }
}

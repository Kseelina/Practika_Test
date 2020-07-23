using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// Модель для БД, по названиям полей в таблице Answers
    /// </summary> 
    [Table("Answers")]
    public class AnswerBase : EntityBase
    {
        public string AnswText { get; set; }
        public string AnswImage { get; set; }
        public int AnswIsRight { get; set; }
        public string QuestionId { get; set; }
        //Внешний ключ:
        [ForeignKey("QuestionId")]
        public virtual  Question Question { get; set; } 
        /*virtual - создаёт виртуальное поле, которое не связано с БД, но оно позволяет получать всю инфу*/


    }


}

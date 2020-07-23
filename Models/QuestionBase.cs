using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{ /// <summary>
  /// 
  /// </summary>
    [Table("Questions")]
    public class QuestionBase : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string QuestText { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string QuestImage { set; get; }
        public virtual List<AnswerBase> Answers { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Question
    {
        /// <summary>
        /// Jтвечает за параметры каждого вопроса (точнее что содержит каждый вопрос)
        /// </summary>
        public Question() // для связи между вопросами (Question) и ответами (Answers)
        {
            Answers = new List<Answer>();
        }
// get, set - можем и получать и записывать характеристики
        public int Number { get; set; }  // Номер
        public string Image { get; set; }   // Картинка с вопросом
        public string Text { get; set; }// Текст вопроса
        public List<Answer> Answers { get; set; } // Варианты ответа (класс Answer)
        // Объявляем тип список <вариантов ответов>
        public string AnswersUser { get; set; } // Варианты ответа пользователя
        // Объявляем тип список <вариантов ответов>

    }
}

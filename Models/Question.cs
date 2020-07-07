using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Question
    {
        // Номер
        // Картинка
        // Текст
        // Варианты ответа (класс Answer)

        int Number { get; set; } // get, set - можем и получать и записывать характеристики
        string Image { get; set; }
        string Text { get; set; }
        List<Answer> Answers { get; set; }
        // Объявляем тип список <вариантов ответов>
    }
}

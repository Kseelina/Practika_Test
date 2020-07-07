using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // public - доступен во всей программе
    // private -  доступ только внутри (ограниченный) по defolt
   public class Answer
    {
        // Номер
        // Картинка к варианту ответа
        //Текст варианта ответа
        // верный / неверный

        int Number { get; set; }
        string Image { get; set; }
        string Text { get; set; }
        bool IsRight { get; set; }
    }
}

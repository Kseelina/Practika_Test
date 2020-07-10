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

        public int Number { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Класс, отвечает за параметры каждого ответа(точнее что содержит каждый ответ)
    /// </summary>

    // public - доступен во всей программе
    // private -  доступ только внутри (ограниченный) по default
    public class Answer
    {
        public int Number { get; set; } // Номер
        public string Image { get; set; } // Картинка к варианту ответа
        public string Text { get; set; }   //Текст варианта ответа
        public bool IsRight { get; set; }  // верный / неверный
    }
}

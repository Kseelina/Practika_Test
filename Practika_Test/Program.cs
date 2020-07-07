using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusnessLogic;

namespace Practika_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Metods metods = new Metods(); // создание нового экземпляра объекта
            string[] Text = metods.GetQuestions();
            

            Console.ReadKey();
        }
    }
}

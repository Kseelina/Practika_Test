using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusnessLogic;
using System.Configuration;

namespace Practika_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string testFolder = ConfigurationManager.AppSettings["questFolder"];
            string testFile = ConfigurationManager.AppSettings["questFile"];

            Metods metods = new Metods(); // создание нового экземпляра объекта
            List<string> Text = metods.GetQuestions(Path.Combine(testFolder, testFile));
            // Path.Combine - функция соединения

            Console.ReadKey();
        }
    }
}

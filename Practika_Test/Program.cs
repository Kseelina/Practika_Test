using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusnessLogic;
using Models;
using System.Configuration;
using NLog;

namespace Practika_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
            logger.Info("Программа успешно запущена.");          // вывод сообщения в лог файле


            string testFolder = ConfigurationManager.AppSettings["questFolder"];
            string testFile = ConfigurationManager.AppSettings["questFile"];

            Metods metods = new Metods(); // создание нового экземпляра объекта
            List<string> Text = metods.GetQuestions(Path.Combine(testFolder, testFile));
            // Path.Combine - функция соединения
            logger.Info("Файл с вопросами найден и успешно считан.");
            List <Question> questions =metods.SetTest(Path.Combine(testFolder, testFile));
            logger.Info("Файл с вопросами успешно преобразован в вид понятный для программы");
            Console.ReadKey();
        }

    }
}

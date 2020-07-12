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

            try
            {
              Metods metods = new Metods(); // создание нового экземпляра объекта
              List<string> Text = metods.GetQuestions(Path.Combine(testFolder, testFile));
              // Path.Combine - функция соединения
              logger.Info("Файл с вопросами найден и успешно считан.");
              List <Question> questions =metods.SetTest(Path.Combine(testFolder, testFile));
              logger.Info("Файл с вопросами успешно преобразован в вид понятный для программы");
            }
            catch (Exception e)
            {
               // Console.WriteLine("Ошибка! Файл по указанному пути не найден!"); // выводит поьзователю
                // а в лог файл выводится:
                logger.Error (e.Message); /* внутреннее сообщение об ошибке ; Message - выводит сообщение из класса 
                                           Metods  из функции GetQuestions (throw new Exception($"Ошибка! Файл по пути {file} не найден!");)*/
            }

            
            Console.ReadKey();
        }

    }
}

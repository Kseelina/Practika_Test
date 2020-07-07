using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusnessLogic
{
   public class Metods
    {
      public  List <string> GetQuestions(string file)
        { 
        
            List<string> str = new List<string>();
       /* Обработчик ошибок, чтобы ошибка не закрывала программу, а выводилась в понятном для пользователя виде
          и программа продолжала работать*/
            try
            {
                str = File.ReadAllLines(file).ToList();  
                // ToList - Преобразует полученное значение в тип лист
            }

            catch (FileNotFoundException) // Для конкретного случая, что файл не найден
            {
                Console.WriteLine("Ошибка! Файл по указанному пути не найден!");
            }
            catch (Exception) // Просто непредвидимая ошибка
            {
                Console.WriteLine("Файл по указанному пути не найден!");
            }

        return str;
        }

       
    }
}

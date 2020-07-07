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
      public  List <string> GetQuestions()
        { 
        string testFolder = @"C:\Users\Brave\Documents\Visual Studio 2019\projects\C#\Practika_Test\Test_3_in_1";
        string testFile = "Vopros.txt";

            List<string> str = new List<string>();

        try  
            {
                str = File.ReadAllLines(Path.Combine(testFolder,testFile)).ToList(); // Path.Combine - функция соединения

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

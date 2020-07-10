using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Models;

namespace BusnessLogic
{
   public class Metods
    {
      public  List <string> GetQuestions(string file)
        { 
        
            List <string> str = new List<string>();
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

        // Функция для вопросов к тесту
        public List<Question> SetTest(string file)
        {
            int n; // переменная, которая хранит в себе количество ответов на вопрос
            int m;  
            /*Создаём новый тип список, и выделяем для него память ; List<Question>() - являетчя функцией*/
            List<Question> quiz = new List<Question>();
            // считывание вопроса в переменную str
            List<string> str = GetQuestions(file);

            // вводим цикл дляя перебора строк теста; str.Count - определяет размер списка
            for (int i = 0; i < str.Count; i++)
            {
                // запоминаем число ответов; int.Parse - преобразует строку в число 
                n = int.Parse(str[i]);

                // TryParse - возвращает значение того, что произошла ошибка при переводе из одного типа данных в другой
                // Parse   - выводит ошибку, что произошла ошибка при переводе из одного типа данных в другой  
                
                m = n + 2; // Запоминаем количество ответов + сам вопрос + пустая строка 
                while(m>0) // пока не закончится весь блок в котором содерится и вопрос и варианты ответов к нему
                {
                    if (m==n+1) // строка с вопросом
                    {
                        Question qustion = new Question();
                        qustion.Text = str[i];          // считывание вопроса из блокнота в класс Question (в параметр текст)
                        if (str[i].Contains("#?"))
                        {
                            string[] auesTaxt = str[i].Split(new string[] { "#?" }, StringSplitOptions.RemoveEmptyEntries);
                            qustion.Image = auesTaxt[1];
                            qustion.Text = auesTaxt[0];
                        }

                    }
                    else if(m<n) // перебор вариантов ответа
                    {
                        Answer answer = new Answer();
                        answer.Text = str[i];          // считывание ответа из блокнота в класс Answer (в параметр текст)
                        if (str[i].Contains("#?"))
                        {
                            string[] auesTaxt = str[i].Split(new string[] { "#?" }, StringSplitOptions.RemoveEmptyEntries);
                            if (auesTaxt.Count()==1) { answer.Image = auesTaxt [0]; } // есои есть только картинка
                            else  // иначе есть и каринка и текст ответа
                                    {
                                        answer.Image = auesTaxt[1];
                                        answer.Text = auesTaxt[0]; 
                                    }
                            
                        }

                    }
                    m--;
                    i++;
                }

            }

            return quiz;
        }
    }
}

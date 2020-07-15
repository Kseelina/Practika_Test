using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Models;
using NLog;

namespace BusnessLogic
{
    /// <summary>
    /// Класс Metods отвечает за нахождение теста (в случае чего в логах пропишет, что путь не найден)
    /// А так же за считывание каждого блока (вопроса) и помещение вопроса с вариантами ответов в 
    /// тип Лист для дальнейшей работы программы с тестом
    /// quiz - переменная типа лист (List<Question>), котрая хранит в себе значения вопроов 
    /// (+ответы, относящиеся к каждому вопросу)
    /// </summary>


    public class Metods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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
                throw new Exception($"Ошибка! Файл по пути {file} не найден!");
            }
        return str;
        }

        // Функция для вопросов к тесту
        public List<Question> SetTest(string file)
        {
            int n; // переменная, которая хранит в себе количество ответов на вопрос
            //int m;
            int number_question = 1; // номер вопроса начинается с 1
            /*Создаём новый тип список, и выделяем для него память ; List<Question>() - являетчя функцией*/
            List<Question> quiz = new List<Question>();
            // считывание вопроса в переменную str
            List<string> str = GetQuestions(file);

            //Question qustion = new Question(); // создание пустых конструкторов
            //Answer answer = new Answer();

            //вводим цикл дляя перебора строк теста; str.Count - определяет размер списка
            for (int i = 0; i < str.Count; i++)
            {
                try
                {
                    // запоминаем число ответов; int.Parse - преобразует строку в число 
                     n = int.Parse(str[i++]);
                   
                }
                catch (Exception) // Указание ошибки, о неспособности перевести строку в число
                {
                    Console.WriteLine("Ошибка! Не удалось преобразовать строку!");
                    throw new Exception($"Ошибка! В файле по указанному пути {file} не удалось преобразовать строку номер {i+1} в число");
                    
                }
                // TryParse - возвращает значение того, что произошла ошибка при переводе из одного типа данных в другой
                // Parse   - выводит ошибку, что произошла ошибка при переводе из одного типа данных в другой  

                //m = n + 2; // Запоминаем количество ответов + сам вопрос + пустая строка 

                Question qustion = new Question(); // создание пустых конструкторов

                int number_answer = 1;

               // while (m>0) // пока не закончится весь блок в котором содерится и вопрос и варианты ответов к нему
                //{
                   
                    

                    //if (m==n+1) // строка с вопросом
                    //{

                        qustion.Number= number_question++;
                        qustion.Text = str[i];          // считывание вопроса из блокнота в класс Question (в параметр текст)
                        if (str[i].Contains("#?")) // если имеется картинка в вопросе
                        {
                            /* Разбиваем текст и картинку вопроса
                            и записываем по отдельности в параметры вопроса:*/
                            string[] auesTaxt = str[i].Split(new string[] { "#?" }, StringSplitOptions.RemoveEmptyEntries);
                            qustion.Image = auesTaxt[1];
                            qustion.Text = auesTaxt[0];
                        }
                i++;
                    //}
                   // else if(m<=n) // перебор вариантов ответа
                   // {

                     while(n>0)
                     {  
                        Answer answer = new Answer();
                        answer.Number=number_answer++;
                        answer.Text = str[i];          // считывание ответа из блокнота в класс Answer (в параметр текст)
                        if (str[i].Contains("#?"))
                        {
                            string[] auesTaxt = str[i].Split(new string[] { "#?" }, StringSplitOptions.RemoveEmptyEntries);
                            if (auesTaxt.Count()==1) // если есть только картинка
                            { 
                                answer.Image = auesTaxt [0];
                                answer.Text = null;
                            } 
                            else  // иначе есть и каринка и текст ответа
                                    {
                                        answer.Image = auesTaxt[1]; // записываем ссылку на картинку в параметры ответа
                                        answer.Text = auesTaxt[0];  // записываем текст ответа в параметры ответа
                                    }
                            
                        }
                        if (str[i].EndsWith("*")) // если ответ верный
                        {
                            // избавляемся от знака правильного ответа и записываем в параметр ответа
                            if (answer.Image != null) { answer.Image = answer.Image.TrimEnd('*'); }
                            if (answer.Text != null) { answer.Text = answer.Text.TrimEnd('*');}
                             
                            answer.IsRight = true; // говорим, что данный ответ является верным
                        }
                        else { answer.IsRight = false;} // говорим, что данный ответ является неверным

                        // заполняем параметр Answers в классе вопрос (Qustion) значениями параметров из класса ответ (Answer):
                        qustion.Answers.Add(answer);
                        // }
                        //    m--;
                        
                         i++;
                         n--;
                     }
                quiz.Add(qustion);
            }
            return quiz;
        }
        
    }
}

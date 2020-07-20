﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.IO;
using BusnessLogic;
using Models;




namespace GUI
{
    /// <summary>
    /// Главная визуальная форма программы, в которой выполняется загрузка каждого вопроса
    /// (+ ответы к вопросам) из теста (из класса Metods)
    /// Тутже выполняется визуализация формы пользователя (размещение и вид элементов управления )
    /// </summary>
    public partial class Form1 : Form
    {
        int QuestionNumberList = 0;    // номер вопроса, который идёт в списке лист
        const int NumQuestInTest = 15; // В тесте всегда 15 вопросов
        string ImageFolder = ConfigurationManager.AppSettings["questFolder"]; // Путь до папки с тестом (картинками)
        List<Question> questions = new List<Question>(); // создаём пустой лист под будущие вопросы
        List<Question> AnswersUser = new List<Question>(); // создаём пустой лист для записи ответов пользователя

        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера

//----------------------------------Рандомизирование вопросов------------------------------------------------------------------------
       
        List<Question> RandomQuestions()
        {
            List<Question> NewListQuestions = new List<Question>(); //Создаём новый лист под рандомизированные вопросы
            Question question = new Question();
            Random random = new Random(); // создание объекта рандом
            int i = 0;
            bool add = true;
            int[] mass = new int[NumQuestInTest]; // объявление массива
            while(i< NumQuestInTest)
            {
                add = true;
                mass[i] = random.Next(0, questions.Count());
                
                for (int j=0; j<i; j++)
                {
                    if (mass[i] == mass[j])
                    {
                        i--;
                        add = false;
                    }
                }
                if (add == true) { NewListQuestions.Add(questions.ElementAt(mass[i])); }
                i++;
            }
            return NewListQuestions;
        }
//----------------------------------Функия сохраения ответов пользователя----------------------------------------------------------------------------
        
        /// <summary>
        /// Запоминаем в ответах:
        /// Номер вопроса (ID вопроса по номеру)
        /// Положение отвеченного ответа как true
        /// </summary>
        /// <returns></returns>
        /// 
        void ChecAnswers()
        { /* Панель ответов обращается к дочерним элементам. он берёт все эти элементы и 
            преобразовать в тип коннтрол, потому что все они являются дочерними элементами типа контрол*/
            
            //questions[QuestionNumberList].AnswersUser = 
            //    AnswerField.Controls.OfType<RadioButton>().
            //    Where(x => x.Checked).Select(x => x.Tag.ToString()).Aggregate((x,y)=>x+"#"+y);

        }

        /// <summary>
        /// Инициализация формы, считывание файла и вызов FillForm() для заполнения формы 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            
            // Визуализация (то что видит пользователь и с чем взаимодействует)
            Buck.Enabled = false; // Кнопка Назад изначально неактивна

            logger.Info("Программа успешно запущена.");          // вывод сообщения в лог файле

            string testFolder = ConfigurationManager.AppSettings["questFolder"];
            string testFile = ConfigurationManager.AppSettings["questFile"];

            try
            {
                Metods metods = new Metods(); // создание нового экземпляра объекта
                List<string> Text = metods.GetQuestions(Path.Combine(testFolder, testFile));
                // Path.Combine - функция соединения
                logger.Info("Файл с вопросами найден и успешно считан.");
                questions = metods.SetTest(Path.Combine(testFolder, testFile));
                questions = RandomQuestions(); // вызов функции рандома вопросов
                logger.Info("Файл с вопросами успешно преобразован в вид понятный для программы.");

                // Автозаполнение ссылок на вопросы
                int i = 1;
                while (i <= questions.Count)
                {
                    LinkLabel label = new LinkLabel(); // создание объекта LinkLabel
                    label.Name = "label" + i;
                    label.Text = i++.ToString(); // запись текста от 1 до 15(максимум в тесте 15 вопросов)
                    // привязка к событию нажатия на ссылку (для перехода к вопросу данного номера):
                    label.Click += LinkLabelOnClik; 
                    label.Width = 35;
                    label.Height = 35;
                    label.Font = new Font("Times New Roman", 14);
                    label.TextAlign = ContentAlignment.TopCenter; // выравнивание по центру
                    label.BorderStyle = BorderStyle.FixedSingle; // рамки
                    NavigatingNum.Controls.Add(label); // добавление элемента на панель в форму
                }

                FillForm();
                logger.Info("Форма успешно заполнена.");
            }

            catch (Exception e)
            {
                // Console.WriteLine("Ошибка! Файл по указанному пути не найден!"); // выводит поьзователю
                // а в лог файл выводится:
                logger.Error(e.Message); /* внутреннее сообщение об ошибке ; Message - выводит сообщение из класса 
                                           Metods  из функции GetQuestions (throw new Exception($"Ошибка! Файл по пути {file} не найден!");)*/
            }
        }
//------------------------------------------------------------------------------------------------
        void FillForm () // функция переноса значений в форму из Metods
        {
            AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
            QuestionImage.Image = null; // очистка от картинки в вопросе
            try
            {
                Question question = questions[QuestionNumberList]; // вытаскиваем вопрос по его номеру в листе question
                // LINQ конструкция: для определения количество верных вариантов ответов:
                int N = question.Answers.Count (x=>x.IsRight == true )  ; 
                TextQuestion.Text = "Вопрос " + (QuestionNumberList+1) + ". " + question.Text; // текст вопроса
                if (question.Image!=null) {  QuestionImage.ImageLocation = Path.Combine(ImageFolder, question.Image);}
                
                // Вытаскиваем ответы
                /* foreach - цикл, перебрать варианты ответов, каждому из которых будем давать
                    имя вариант ответ в списке, который находится в переменной question и в свойстве 
                 список вопросов ; другими словами обращается к списку и берёт от туда значения*/
                foreach (Answer answer in question.Answers)
                {

                    // Если в ответе и текст и картинка
                    if (answer.Text != null && answer.Image != null)
                    {
                        /*?*/
                        AnswerField.FlowDirection = FlowDirection.LeftToRight;
                        PostingOneAnswerForm(answer);
                        PostingPictureForm(answer);
                    }

                    //Если в ответах только текст
                    else if (answer.Text != null && answer.Image == null)
                    {
                        if (N > 1) // чекбоксы (выбор нескольких вариантов ответа)
                        {
                            PostingFewAnswersForm(answer);
                        }
                        else // радиобатоны (выбор одного варианта ответа)
                        {
                            PostingOneAnswerForm(answer);
                        }
                    }
                    //Если в ответах тоько картинка
                    else if (answer.Text == null && answer.Image != null)
                    {
                        PostingPictureForm(answer);

                    }
                                       
                }
                


                    // Проверка на наличие картинки?
                    //if (QuestionImage) /?
                    //{ ?
                    //     logger.Error($"Ошибка! Картинка {question.Image} не найдена по указанному пути {ConfigurationManager.AppSettings["questFolder"]}."); 
                    //}/?
      
            }
            catch (Exception) // Указание ошибки, о неспособности передать в форму значений
            {
                throw new Exception($"Ошибка! Возникла ошибка при передачи значения типа Question в форму.");

            }
        }
//---------------------------------Кноки Далее, Назад---------------------------------------------------------------
        public void Next_Click(object sender, EventArgs e) // кнопка далее
        {
            QuestionNumberList++; // увеличение текущего номера вопроса
            VisibilityButton(); // Вызов проверки видимости кнопок дадее и назад

            if (QuestionNumberList == NumQuestInTest) // завершить тест и открыть форму результатов
            {
                Result result = new Result();
                this.Hide();
                result.ShowDialog();
                this.Show();
            }
            else 
            {
                Buck.Enabled = true; // Кнопка Назад становится активна
                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос 
            }
        }
        public void Buck_Click(object sender, EventArgs e) // кнопка назад
        {
            QuestionNumberList--;

            VisibilityButton(); // Вызов проверки видимости кнопок дадее и назад

            FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос
        }

//------------------------Функция проверки видимости кнопок дадее и назад с сохранением ответа пользователя-----------------------------
        public void VisibilityButton() 
        {
            ChecAnswers();

            if (QuestionNumberList + 1 == 1)
            {
                Buck.Enabled = false;
            }
            else { Buck.Enabled = true; }

            if (QuestionNumberList + 1 == NumQuestInTest)
            {
                Next.Text = "Завершить";
            }
            else { Next.Text = "Далее"; }

        }

//-----------------------------Автоматический вывод элементов ответов на вопрос---------------------------------
       public void PostingPictureForm(Answer answer)// Вывод картинки
        {
            PictureBox answerBox = new PictureBox();
            answerBox.ImageLocation = Path.Combine(ImageFolder, answer.Image);

            answerBox.Tag = answer.Number;
            // Визуализация

            answerBox.SizeMode = PictureBoxSizeMode.Zoom;
            answerBox.Width = 140;
            answerBox.Height = 140;
            answerBox.Dock = DockStyle.Bottom;
            AnswerField.FlowDirection = FlowDirection.LeftToRight;
            AnswerField.Controls.Add(answerBox);
        }

        public void PostingOneAnswerForm(Answer answer) // Вывод радиобатонов
        {
            RadioButton answerBox = new RadioButton();
            answerBox.Text = answer.Text;
            answerBox.Tag = answer.Number;
            // Визуализация
            AnswerField.FlowDirection = FlowDirection.TopDown;
            answerBox.Width = 400;
            AnswerField.Controls.Add(answerBox);
        }

        public void PostingFewAnswersForm(Answer answer) //Вывод чекбоксов
        {
            // вывод элементов
            CheckBox answerBox = new CheckBox();
            answerBox.Text = answer.Text;
 //        
            // Визуализация
            AnswerField.FlowDirection = FlowDirection.TopDown; // установление по вертикали
            answerBox.Width = 700;
            AnswerField.Controls.Add(answerBox);
        }
        

//---------------------------Переход по номерам вопросов в панеле навигации---------------------------------
        public void LinkLabelOnClik(object sender, EventArgs eventArgs)
        {
            if (sender is LinkLabel label) // При нажатии на ссылку с номером вопроса в панели навигации
            {
                QuestionNumberList = int.Parse(label.Text)-1;
                AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
                QuestionImage.Image = null; // очистка от картинки в вопросе
                VisibilityButton(); // Вызов проверки видимости кнопок дадее и назад
                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос
            }
        }





        //---------------------------------Закрытие теста---------------------------------------------------
        public void Form1_FormClosing(object sender, FormClosingEventArgs e) // При закрытии теста
        {
            if (MessageBox.Show("Тест не пройден. Вы действительно хотите закрыть программу?", "Завершение программы",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                logger.Info("Программа успешно закрыта.");
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}



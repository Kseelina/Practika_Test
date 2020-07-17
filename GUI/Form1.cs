using System;
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
        List<Answer> AnswersUser = new List<Answer>(); // создаём пустой лист для записи ответов пользователя

        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера

//----------------------------------Рандомизирование вопросов------------------------------------------------------------------------
       
        List<Question> RandomQuestions()
        {
            List<Question> NewListQuestions = new List<Question>(); //Создаём новый лист под рандомизированные вопросы
            Question question = new Question();
            Random random = new Random(); // создание объекта рандом
            int i = 0;
            while(i< NumQuestInTest)
            {
                // LINQ конструкция: для рандомного разбросса вопросов теста

                NewListQuestions.Add(questions.ElementAt(random.Next(0, questions.Count())));
                NewListQuestions.ForEach  (x => x.Number = i);
                i++;
            }
            return NewListQuestions;
        }
//----------------------------------Функия сохраения ответов пользователя----------------------------------------------------------------------------
        
        /// <summary>
        /// Запоминаем в ответах:
        /// Номер вопроса (текущий)
        /// Если есть картинка и(или) текст
        /// и положение отвеченного ответа как true
        /// </summary>
        /// <returns></returns>
        List<Answer>  SaveAnswersUser ()
        {




            return AnswersUser;
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
                    label.Text = i++.ToString(); // запись текста от 1 до 15(максимум в тесте 15 вопросов)
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

            if (QuestionNumberList+1 == NumQuestInTest-1)
            {
                Next.Text = "Завершить";
            }
            else { Next.Text = "Далее"; }

            if (QuestionNumberList+1 == NumQuestInTest) // завершить тест и открыть форму результатов
            {
                Result result = new Result();
                this.Hide();
                result.ShowDialog();
                this.Show();
                

            }
            else 
            {
                Buck.Enabled = true; // Кнопка Назад становится активна
                QuestionNumberList++; // увеличение текущего номера вопроса
                AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
                QuestionImage.Image = null; // очистка от картинки в вопросе
                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос 
            }
            
        }
        public void Buck_Click(object sender, EventArgs e) // кнопка назад
        {
            QuestionNumberList--;
            if (QuestionNumberList+1 == 1)
            {
                Buck.Enabled = false;
            }
            else { Buck.Enabled = true; }


            AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
            QuestionImage.Image = null; // очистка от картинки в вопросе

            FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос

        }

//-----------------------------Автоматический вывод элементов ответов на вопрос---------------------------------
        void PostingPictureForm(Answer answer)// Вывод картинки
        {
            PictureBox answerBox = new PictureBox();
            answerBox.ImageLocation = Path.Combine(ImageFolder, answer.Image);
            AnswerField.Controls.Add(answerBox);
            // Визуализация
            
            answerBox.SizeMode = PictureBoxSizeMode.Zoom;
            AnswerField.FlowDirection = FlowDirection.LeftToRight;
            
        }

        void PostingOneAnswerForm(Answer answer) // Вывод радиобатонов
        {
            RadioButton answerBox = new RadioButton();
            answerBox.Text = answer.Text;
            AnswerField.Controls.Add(answerBox);
            // Визуализация
            AnswerField.FlowDirection = FlowDirection.TopDown;
            answerBox.Width = 400;
        }

        void PostingFewAnswersForm(Answer answer) //Вывод чекбоксов
        {
            // вывод элементов
            CheckBox answerBox = new CheckBox();
            answerBox.Text = answer.Text;
            AnswerField.Controls.Add(answerBox);
            // Визуализация
            AnswerField.FlowDirection = FlowDirection.TopDown; // установление по вертикали
            answerBox.Width = 700;
        }
        
//---------------------------------Закрытие теста---------------------------------------------------
        public void Form1_FormClosing(object sender, FormClosingEventArgs e) // При закрытии теста
        {
            if (MessageBox.Show  ( "Тест не пройден. Вы действительно хотите закрыть программу?","Завершение программы",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning )== DialogResult.Yes)
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



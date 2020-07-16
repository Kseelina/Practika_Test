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
        string ImageFolder = ConfigurationManager.AppSettings["questFolder"]; // Путь до папки с тестом (картинками)
        private List<Question> questions = new List<Question>();
        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
        int QuestionNumberList = 0;    // номер вопроса, который идёт в списке лист он же question.Number
        int NumberCurrentQuestion = 1; // Номер текущего вопроса; текущий вопрос - это то что видит пользователь


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
                logger.Info("Файл с вопросами успешно преобразован в вид понятный для программы.");
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
 /*?*/          QuestionNumberList = NumberCurrentQuestion - 1; // на будущее для рандомизвации, а пока так

                Question question = questions[QuestionNumberList]; // вытаскиваем вопрос по его номеру в листе question
                // LINQ конструкция: для определения количество верных вариантов ответов:
                int N = question.Answers.Count (x=>x.IsRight == true )  ; 
                TextQuestion.Text = "Вопрос " + NumberCurrentQuestion + ". " + question.Text; // текст вопроса
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

        private void Next_Click(object sender, EventArgs e) // кнопка далее
        {

            if (NumberCurrentQuestion == 14)
            {
                Next.Text = "Завершить";
            }

            else { Next.Text = "Далее"; }

            if (NumberCurrentQuestion == 15)
            {
                Result result = new Result();
                this.Hide();
                result.ShowDialog();
                this.Show();
            }
            else 
            {
                Buck.Enabled = true; // Кнопка Назад становится активна
                NumberCurrentQuestion++; // увеличение текущего номера вопроса
                AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
                QuestionImage.Image = null; // очистка от картинки в вопросе

                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос 
            }
            
        }

        private void Buck_Click(object sender, EventArgs e) // кнопка назад
        {
            NumberCurrentQuestion--;
            if (NumberCurrentQuestion ==1)
            {
                Buck.Enabled = false;
            }
            else { Buck.Enabled = true; }
            
            
            AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
            QuestionImage.Image = null; // очистка от картинки в вопросе

            FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // При закрытии теста
        {
            if (MessageBox.Show  ( "Вы действительно хотите выйти из программы?","Завершение программы",
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
            PictureBox answerPicture = new PictureBox();
            answerBox.Text = answer.Text;
            answerPicture.ImageLocation = Path.Combine(ImageFolder, answer.Image);
            AnswerField.Controls.Add(answerBox);
            // Визуализация

            AnswerField.FlowDirection = FlowDirection.LeftToRight;
        }

        void PostingFewAnswersForm(Answer answer) //Вывод чекбоксов
        {
            // вывод элементов
            CheckBox answerBox = new CheckBox();
            answerBox.Text = answer.Text;
            AnswerField.Controls.Add(answerBox);
            // Визуализация
            AnswerField.FlowDirection = FlowDirection.TopDown; // установление по вертикали

        }

    }
}



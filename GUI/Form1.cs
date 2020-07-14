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
    public partial class Form1 : Form
    {
        private List<Question> questions = new List<Question>();
        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
        
        public Form1()
        {
            InitializeComponent();

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

        void FillForm () // функция переноса значений в форму из Metods
        {
           
            try
            {
                Question question = questions[0]; // вытаскиваем нулевой вопрос
                TextQuestion.Text = "Вопрос " + question.Number + ". " + question.Text; // текст вопроса

                try
                {
                    QuestionImage.ImageLocation = Path.Combine(ConfigurationManager.AppSettings["questFolder"], question.Image);

                }
                catch (Exception)
                {

                    throw new Exception($"Ошибка! Картинка {question.Image} не найдена по указанному пути {ConfigurationManager.AppSettings["questFolder"]}.");
                }
                


            }
            catch (Exception) // Указание ошибки, о неспособности передать в форму значений
            {
                throw new Exception($"Ошибка! Возникла ошибка при передачи значения типа Question в форму.");

            }
            
        }

        private void Next_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // При закрытии теста
        {
            DialogResult dialog = MessageBox.Show
            ( "Вы действительно хотите выйти из программы?","Завершение программы",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning );
            if (dialog == DialogResult.Yes)
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

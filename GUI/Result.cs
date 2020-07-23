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
    /// Форма для вывода окна результата
    /// </summary>
    public partial class Result : Form
    {
        private List<Question> _questions;
        string ImageFolder = ConfigurationManager.AppSettings["questFolder"]; // Путь до папки с тестом (картинками)
        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
                                                            //List<Question> Questions = new List<Question>();
        int QuestionNumberList = 0; // номер вопроса в списке
        bool ButtonRestart = false;


        private string questFolder = ConfigurationManager.AppSettings["questFolder"];

        public Result(List<Question> questions)
        {
            InitializeComponent();
            _questions = questions;
            FillFormResults();
        }
//-----------------------------------------Заполнение формы----------------------------------------------
        void FillFormResults()
        {

            foreach (Question question in _questions)
            {
                int number = 0;
                // Вывод вопроса + картинка (если есть)
                Label TextQuestion = new Label(); // создаём для вывода вопроса
                TextQuestion.Text = "Вопрос " + (QuestionNumberList + 1) + " " + question.Text; // записываем сам вопрос
                TextQuestion.Font = new Font("Times New Roman", 16);
                TextQuestion.Width = 600;

                FindingResults.FlowDirection = FlowDirection.TopDown;
                FindingResults.Controls.Add(TextQuestion);

                if (question.Image != null) // проверка на наличие картинки в вопросе
                {
                    PictureBox pictureBox = new PictureBox(); // создаём картинку
                    pictureBox.ImageLocation = Path.Combine(questFolder, question.Image); // путь до картинки
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // сохранением пропорций
                    pictureBox.MinimumSize = new Size(130, 130);
                    pictureBox.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    FindingResults.Controls.Add(pictureBox);
                }
                // вывод ответов:
                foreach (Answer answer in question.Answers)
                {
                    
                    CheckBox checkBox = new CheckBox();
                    checkBox.Width = 600;
                    checkBox.Font = new Font("Times New Roman", 14);
                    checkBox.Enabled = false; // взаимодействте с элементом нельзя

                    RadioButton radioButton = new RadioButton();
                    radioButton.Width = 600;
                    radioButton.Font = new Font("Times New Roman", 14);
                    radioButton.Enabled = false;

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.MaximumSize = new Size(300, 300);


                    int N = question.Answers.Count(x => x.IsRight == true);
                    if (N > 1)
                    {
                        //Если в ответах только текст
                        if (answer.Text != null && answer.Image == null)
                        {
                            checkBox.Text = answer.Text;
                            checkBox.Tag = answer.Number;
                            FindingResults.Controls.Add(checkBox);
                        }

                        // Если в ответах только картинки
                        else if (answer.Text == null && answer.Image != null)
                        {
                            //checkBox.Width = 13;
                            //checkBox.Height = 13;
                            checkBox.Text = "  ";
                            checkBox.Tag = answer.Number;
                            FindingResults.Controls.Add(checkBox);
                            pictureBox.ImageLocation = Path.Combine(ImageFolder, answer.Image);
                            FindingResults.Controls.Add(pictureBox);
                        }
                    }
                    else
                    {
                        //Если в ответах только текст
                        if (answer.Text != null && answer.Image == null)
                        {
                            radioButton.Text = answer.Text;
                            radioButton.Tag = answer.Number;
                            FindingResults.Controls.Add(radioButton);
                        }

                        // Если в ответах только картинки
                        else if (answer.Text == null && answer.Image != null)
                        {
                            //radioButton.Width = 13;
                            //radioButton.Height = 13;
                            radioButton.Text = "    ";
                            radioButton.Tag = answer.Number;
                            FindingResults.Controls.Add(radioButton);
                            pictureBox.ImageLocation = Path.Combine(ImageFolder, answer.Image);
                            FindingResults.Controls.Add(pictureBox);
                        }
                        // Если в ответах и текст и картинка
                        else if (answer.Text != null && answer.Image != null)
                        {
                            radioButton.Tag = answer.Number;
                            FindingResults.Controls.Add(radioButton);
                            pictureBox.ImageLocation = Path.Combine(ImageFolder, answer.Image);
                            FindingResults.Controls.Add(pictureBox);
                        }
                    }
                    FindingResults.FlowDirection = FlowDirection.TopDown; // установление по вертикали

                    // Проверка на ответы пользователя
                    if (!string.IsNullOrWhiteSpace(question.AnswersUser))
                    {
                        if(question.AnswersUser.Contains(question.Answers[number].Number .ToString()))
                        {
                            radioButton.BackColor = System.Drawing.Color.Red;
                            checkBox.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(question.AnswersUser))
                    {
                        if (question.Answers[number].IsRight)
                        {
                            radioButton.BackColor = System.Drawing.Color.Green;
                            checkBox.BackColor = System.Drawing.Color.Green;
                        }
                    }
                    number++;
                }
                QuestionNumberList++;
            } 
        }

        public void Result_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ButtonRestart==false)
            {           
                if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Завершение программы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    logger.Info("Программа успешно закрыта.");
                    e.Cancel = false;
                    ButtonRestart = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }

            }


        }

        public void button1_Click(object sender, EventArgs e)
        {

            ButtonRestart = true;
            DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}

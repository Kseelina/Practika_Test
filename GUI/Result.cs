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
        
        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
                                                            //List<Question> Questions = new List<Question>();

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

                Label TextQuestion = new Label(); // создаём для вывода вопроса
                TextQuestion.Text = "Вопрос "+ i + question.Text; // записываем сам вопрос
                TextQuestion.Font = new Font("Times New Roman", 14);
                TextQuestion.Width = 680;


                FindingResults.Controls.Add(TextQuestion);
                if (question.Image != null) // проверка на наличие картинки в вопросе
                {
                    PictureBox pictureBox = new PictureBox(); // создаём картинку
                    pictureBox.ImageLocation = Path.Combine(questFolder, question.Image); // путь до картинки
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // сохранением пропорций
                    pictureBox.MinimumSize = new Size(130, 130);
                    FindingResults.Controls.Add(pictureBox);
                }


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

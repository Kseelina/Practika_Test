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

        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
        public List<Question> questions { get; set; } 
        private string questFolder = ConfigurationManager.AppSettings["questFolder"];


        public Result()
        {
            InitializeComponent();
            



        }

        public void Result_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Завершение программы",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                logger.Info("Программа успешно закрыта.");
                e.Cancel = false;

                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

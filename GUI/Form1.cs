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
using Castle.Core.Logging;
using Castle.Windsor;
using Service.Interfaces;
using Service;




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
        bool nav = true;
        bool Restart = false;
        Logger logger = LogManager.GetCurrentClassLogger(); // объявление логера
        private WindsorContainer container; // создаём контейнер
        // Т.к. работть будем с интерфейсами, то и объекты нужны интерфейсовые
        private IQuestionService _questionService;
        private IAnswerService _answerService;



        //------------------------------------------Заполнение БД-------------------------------------------------------- 
        void UpdateDatabase(List<Question> _questions)
        {
            foreach (Question question in questions)
            {
                QuestionBase questionBase = new QuestionBase();
                // автоматическая генерация ИД вопроса и перевод его в текст:
                questionBase.Id = Guid.NewGuid().ToString(); 
                questionBase.QuestText = question.Text;
                questionBase.QuestImage = question.Image;

                foreach (Answer answer in question.Answers)
                {
                    AnswerBase answerBase = new AnswerBase();
                    // автоматическая генерация ИД ответа и перевод его в текст:
                    answerBase.Id = Guid.NewGuid().ToString();
                    answerBase.AnswText = answer.Text;
                    answerBase.AnswImage = answer.Image;
                    // записываем какой ответ , верный(1) или неверный(0)
                    // "?"  - тернарный оператор(типо ифа)
                    answerBase.AnswIsRight = answer.IsRight ? 1 : 0; 
                    answerBase.QuestionId = questionBase.Id;
                    _answerService.Create(answerBase); // Create - добавление в БД ответа
                }
                _questionService.Create(questionBase); // Create - добавление в БД вопроса
            }
        }

        //----------------------------------Рандомизирование вопросов------------------------------------------------------------------------

        List<Question> RandomQuestions()
        {
            // При рестарте теста подлежат перезаписи:
            nav = true; 
            ChecAnswers(); // сброс ответов пользователя (для вопросов которые могут повториться с прошлой попытки)
            QuestionNumberList = 0;
            NavigatingNum.Controls.Clear();

            //Сам механизм рандома
            List<Question> NewListQuestions = new List<Question>(); //Создаём новый лист под рандомизированные вопросы
            Question question = new Question();
            Random random = new Random(); // создание объекта рандом
            int i = 0;
            bool add = true;
            int[] mass = new int[NumQuestInTest]; // объявление массива
            while (i < NumQuestInTest)
            {
                add = true;
                mass[i] = random.Next(0, questions.Count());

                for (int j = 0; j < i; j++)
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

            if (Restart) // Если был нажат рестарт, то все ответы что отвечал пользователь обращаются в null
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    questions[i].AnswersUser = null;
                }
            }
            else
            { 
                List<RadioButton> UsersCheck = AnswerField.Controls.OfType<RadioButton>().Where(x => x.Checked).ToList();
                if (UsersCheck.Any())
                {
                    questions[QuestionNumberList].AnswersUser = AnswerField.Controls.OfType<RadioButton>().Where(x => x.Checked).Select(x => x.Tag.ToString()).Aggregate((x, y) => x + "#" + y);
                }

                List<CheckBox> Check = AnswerField.Controls.OfType<CheckBox>().Where(x => x.Checked).ToList();
                if (Check.Any())
                {
                    questions[QuestionNumberList].AnswersUser = AnswerField.Controls.OfType<CheckBox>().Where(x => x.Checked).Select(x => x.Tag.ToString()).Aggregate((x, y) => x + "#" + y);
                }

            }
        }

        /// <summary>
        /// Инициализация формы, считывание файла и вызов FillForm() для заполнения формы 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            container = Bootstrap.BuildContainer();


            _questionService = container.Resolve<IQuestionService>();
            _answerService = container.Resolve<IAnswerService>();
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
                                    
                List<QuestionBase> tmp = _questionService.ReadAll().ToList();  // Считывание из БД
                // проверка есть ли в БД значения
                if (tmp.Count == 0) // Если значений нет, то:
                {
                    // Открытие блокнота и запись в БД
                    List<Question> _questions = metods.SetTest(Path.Combine(testFolder, testFile));
                    UpdateDatabase(_questions); // Запись в БД вопросов из файла, если их там нет
                    tmp = _questionService.ReadAll().ToList(); // Вновь считывание из БД
                }
                // tmp - список вопросов из БД, выбираем оттуда
                foreach (QuestionBase questionBase in tmp)
                {
                    Question question = new Question();
                    question.Number = QuestionNumberList; // номер вопроса по списку
                    question.Text = questionBase.QuestText; // текст вопроса
                    question.Image = questionBase.QuestImage; // картинка
                    int indexAnswer = 1;
                    foreach (AnswerBase answerBase in questionBase.Answers)
                    {
                        Answer answer = new Answer();
                        answer.Number = indexAnswer;
                        answer.Text = answerBase.AnswText ;
                        answer.Image = answerBase.AnswImage;
                        // записываем какой ответ , верный(1) или неверный(0)
                        answer.IsRight = answerBase.AnswIsRight == 1;
                        question.Answers.Add(answer);
                        indexAnswer++;
                    }
                    questions.Add(question);
                    QuestionNumberList++;
                }

                //questions = tmp.Select(x => new Question()
                //{
                //    Text = x.QuestText,
                //    Image = x.QuestImage,
                //    Answers = x.Answers.Select(y => new Answer()
                //    {
                //            Text = y.AnswText,
                //            Image = y.AnswImage,
                //            IsRight = y.AnswIsRight == 1, // Сравнивает если в AnswIsRight, то будет тру

                //    }

                //}.ToString());


                questions = RandomQuestions(); // вызов функции рандома вопросов
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
//---------------------------------------функция переноса значений в форму из Metods---------------------------------------------------------
        void FillForm() 
        {
            if (Restart)
            {
                questions = RandomQuestions();
                Restart = false;
            }

            AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
            QuestionImage.Image = null; // очистка от картинки в вопросе

            if (nav)
            {
                nav = false;
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
            }
            try
            {
                Question question = questions[QuestionNumberList]; // вытаскиваем вопрос по его номеру в листе question
                // LINQ конструкция: для определения количество верных вариантов ответов:
                
                int N = question.Answers.Count(x => x.IsRight == true);
                TextQuestion.Text = "Вопрос " + (QuestionNumberList + 1) + ". " + question.Text; // текст вопроса
                if (question.Image != null) { QuestionImage.ImageLocation = Path.Combine(ImageFolder, question.Image); }

                // Вытаскиваем ответы
                /* foreach - цикл, перебрать варианты ответов, каждому из которых будем давать
                    имя вариант ответ в списке, который находится в переменной question и в свойстве 
                 список вопросов ; другими словами обращается к списку и берёт от туда значения*/

                //---------------------------------Автоматический вывод ответов на вопрос------------------------------------------
                foreach (Answer answer in question.Answers)
                {
                    RadioButton radio = new RadioButton(); // для единственного варианта ответа
                    radio.AutoEllipsis = true;
                    radio.Dock = DockStyle.Top; // позиция вверху
                    radio.Width = 800;
                    radio.Height = 90;
                    radio.AutoSize = false;
                    radio.Font = new Font("Times New Roman", 14);

                    CheckBox check = new CheckBox(); // для нескольких вариантов ответа
                    check.Dock = DockStyle.Top; // позиция вверху
                    check.Width = 800;
                    check.AutoSize = true;
                    check.Font = new Font("Times New Roman", 14); 
                    
                    Panel panel = new Panel(); // Создаём панель для размещения на ней элементов
                    panel.MinimumSize = new Size(200, 200);
                    panel.AutoSize = true;
                    panel.Dock = DockStyle.Left;

                    PictureBox picture = new PictureBox();   // для вывода картинок
                    picture.MinimumSize = new Size(160, 160);
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    picture.Dock = DockStyle.Fill;     // привязать к краям

                    if (!string.IsNullOrWhiteSpace(question.AnswersUser)) // запоминание ответов на предыдущие
                    {
                        radio.Checked = question.AnswersUser.Contains(answer.Number.ToString());
                        check.Checked = question.AnswersUser.Contains(answer.Number.ToString());
                    }

                    // Если в ответе и текст и картинка
                    if (answer.Text != null && answer.Image != null)
                    {
                        picture.ImageLocation = Path.Combine(ImageFolder, answer.Image);
                        picture.SizeMode = PictureBoxSizeMode.Zoom;
                        picture.MinimumSize = new Size(130, 130);
                        picture.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                        radio.Text = answer.Text;
                        radio.Tag = answer.Number;
                       // panel.Controls.Add(radio);
                        panel.Controls.Add(picture);
                        AnswerField.Controls.Add(radio);
                        AnswerField.Controls.Add(panel);
                    }

                    //Если в ответах только текст
                    else if (answer.Text != null && answer.Image == null)
                    {
                        radio.Height = 30;
                        if (N > 1) // чекбоксы (выбор нескольких вариантов ответа)
                        {
                            check.Text = answer.Text;
                            check.Tag = answer.Number;
                            AnswerField.Controls.Add(check);
                        }
                        else // радиобатоны (выбор одного варианта ответа)
                        {
                            radio.Text = answer.Text;
                            radio.Tag = answer.Number;
                            AnswerField.Controls.Add(radio);
                        }
                    }

                    //Если в ответах только картинка
                    else if (answer.Text == null && answer.Image != null)
                    {
                        if (N > 1) // чекбоксы (выбор нескольких вариантов ответа)
                        {
                            check.Width = 13;
                            check.Height = 13;
                            check.Text = "  ";
                            check.Tag = answer.Number;
                            // panel.Controls.Add(check);
                            AnswerField.Controls.Add(check);
                        }
                        else // радиобатоны (выбор одного варианта ответа)
                        {
                            radio.Width = 13;
                            radio.Height = 13;
                            radio.Text = "  ";
                            radio.Tag = answer.Number;
                            // panel.Controls.Add(radio);
                            AnswerField.Controls.Add(radio);

                        }
                        picture.ImageLocation = Path.Combine(ImageFolder, answer.Image);
                        picture.SizeMode = PictureBoxSizeMode.Zoom;
                        picture.MinimumSize = new Size(180, 180);

                        panel.Controls.Add(picture);
                        AnswerField.Controls.Add(panel);
                    }
                }
            }
            catch (Exception) // Указание ошибки, о неспособности передать в форму значений
            {
                throw new Exception($"Ошибка! Возникла ошибка при передачи значения типа Question в форму.");
            }
        }
     

//---------------------------------------Кноки Далее, Назад---------------------------------------------------------------
        public void Next_Click(object sender, EventArgs e) // кнопка далее
        {

            ChecAnswers();
            QuestionNumberList++; // увеличение текущего номера вопроса
           VisibilityButton(); // Вызов проверки видимости кнопок далее и назад

            if (QuestionNumberList == NumQuestInTest) // завершить тест и открыть форму результатов
            {
                Result result = new Result(questions);
                result.ShowDialog();
                result.Show();
                result.Hide();
                // Пройи тест заново:
                Restart = true;
                RandomQuestions();
                FillForm();
            }
            else
            {
                Buck.Enabled = true; // Кнопка Назад становится активна
                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос 
            }
        }
        public void Buck_Click(object sender, EventArgs e) // кнопка назад
        {
            ChecAnswers();
            QuestionNumberList--;
            VisibilityButton(); // Вызов проверки видимости кнопок дадее и назад

            FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос
        }


//------------------------Функция проверки видимости кнопок дадее и назад с сохранением ответа пользователя-----------------------------
        public void VisibilityButton()
        {
           // ChecAnswers();
          
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


//-------------------------------------Переход по номерам вопросов в панеле навигации---------------------------------
        public void LinkLabelOnClik(object sender, EventArgs eventArgs)
        {
            if (sender is LinkLabel label) // При нажатии на ссылку с номером вопроса в панели навигации
            { 
                ChecAnswers();
                QuestionNumberList = int.Parse(label.Text)-1;
                AnswerField.Controls.Clear(); // очистка поля с создаваемыми компонентами
                QuestionImage.Image = null; // очистка от картинки в вопросе
                VisibilityButton(); // Вызов проверки видимости кнопок дадее и назад
                FillForm(); // вызов функции для перебора и создания компонентов ответов на вопрос
            }
        }

//-----------------------------Расчёт размеров картинок при изменении размера главного окна--------------------------------------------
        private void AnswerField_Resize(object sender, EventArgs e)
        {
            Panel parent = (Panel)sender;
            foreach (Control control in parent.Controls)
            {
                if (control.Controls.GetType().ToString() == "PictureBox")
                {
                    PictureBox pictureBox = control.Controls.OfType<PictureBox>().First();
                    pictureBox.Width = (parent.Width * 10) / parent.Controls.Count;
                    pictureBox.Height = (parent.Width * 10) / parent.Controls.Count;
                }
            }
        }


//-------------------------------------------Закрытие теста---------------------------------------------------
        public void Form1_FormClosing(object sender, FormClosingEventArgs e) // При закрытии теста
        {
                //if (MessageBox.Show("Тест не пройден. Вы действительно хотите закрыть программу?", "Завершение программы",
                //MessageBoxButtons.YesNo,
                //MessageBoxIcon.Warning) == DialogResult.Yes)
                //{
                //    logger.Info("Программа успешно закрыта.");
                //    e.Cancel = false;
                //}
                //else
                //{
                //    e.Cancel = true;
                //}
        }

    }
}



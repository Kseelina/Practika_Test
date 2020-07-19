namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextQuestion = new System.Windows.Forms.Label();
            this.QuestionImage = new System.Windows.Forms.PictureBox();
            this.QuestionField = new System.Windows.Forms.Panel();
            this.AnswerField = new System.Windows.Forms.FlowLayoutPanel();
            this.Navigation = new System.Windows.Forms.Panel();
            this.NavigatingNum = new System.Windows.Forms.FlowLayoutPanel();
            this.Next = new System.Windows.Forms.Button();
            this.Buck = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).BeginInit();
            this.QuestionField.SuspendLayout();
            this.Navigation.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextQuestion
            // 
            this.TextQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextQuestion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextQuestion.Location = new System.Drawing.Point(0, 0);
            this.TextQuestion.MinimumSize = new System.Drawing.Size(520, 0);
            this.TextQuestion.Name = "TextQuestion";
            this.TextQuestion.Size = new System.Drawing.Size(610, 84);
            this.TextQuestion.TabIndex = 0;
            this.TextQuestion.Text = "Вопрос";
            // 
            // QuestionImage
            // 
            this.QuestionImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionImage.Location = new System.Drawing.Point(130, 62);
            this.QuestionImage.Name = "QuestionImage";
            this.QuestionImage.Size = new System.Drawing.Size(411, 188);
            this.QuestionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QuestionImage.TabIndex = 1;
            this.QuestionImage.TabStop = false;
            // 
            // QuestionField
            // 
            this.QuestionField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionField.Controls.Add(this.AnswerField);
            this.QuestionField.Controls.Add(this.Navigation);
            this.QuestionField.Controls.Add(this.QuestionImage);
            this.QuestionField.Controls.Add(this.TextQuestion);
            this.QuestionField.Location = new System.Drawing.Point(0, 0);
            this.QuestionField.MinimumSize = new System.Drawing.Size(690, 25);
            this.QuestionField.Name = "QuestionField";
            this.QuestionField.Size = new System.Drawing.Size(783, 434);
            this.QuestionField.TabIndex = 14;
            // 
            // AnswerField
            // 
            this.AnswerField.AutoSize = true;
            this.AnswerField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AnswerField.Location = new System.Drawing.Point(0, 284);
            this.AnswerField.MinimumSize = new System.Drawing.Size(520, 150);
            this.AnswerField.Name = "AnswerField";
            this.AnswerField.Size = new System.Drawing.Size(610, 150);
            this.AnswerField.TabIndex = 14;
            // 
            // Navigation
            // 
            this.Navigation.Controls.Add(this.NavigatingNum);
            this.Navigation.Controls.Add(this.Next);
            this.Navigation.Controls.Add(this.Buck);
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Right;
            this.Navigation.Location = new System.Drawing.Point(610, 0);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(173, 434);
            this.Navigation.TabIndex = 13;
            // 
            // NavigatingNum
            // 
            this.NavigatingNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NavigatingNum.Location = new System.Drawing.Point(3, 8);
            this.NavigatingNum.Name = "NavigatingNum";
            this.NavigatingNum.Size = new System.Drawing.Size(169, 149);
            this.NavigatingNum.TabIndex = 16;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(91, 163);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(79, 41);
            this.Next.TabIndex = 12;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Buck
            // 
            this.Buck.Location = new System.Drawing.Point(-1, 163);
            this.Buck.Name = "Buck";
            this.Buck.Size = new System.Drawing.Size(86, 40);
            this.Buck.TabIndex = 11;
            this.Buck.Text = "Назад";
            this.Buck.UseVisualStyleBackColor = true;
            this.Buck.Click += new System.EventHandler(this.Buck_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.QuestionField);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(783, 434);
            this.panel4.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 436);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 475);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).EndInit();
            this.QuestionField.ResumeLayout(false);
            this.QuestionField.PerformLayout();
            this.Navigation.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextQuestion;
        private System.Windows.Forms.PictureBox QuestionImage;
        private System.Windows.Forms.Panel QuestionField;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel Navigation;
        private System.Windows.Forms.Button Buck;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.FlowLayoutPanel AnswerField;
        private System.Windows.Forms.FlowLayoutPanel NavigatingNum;
    }
}


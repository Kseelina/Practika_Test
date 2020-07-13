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
            this.panel4 = new System.Windows.Forms.Panel();
            this.Navigation = new System.Windows.Forms.Panel();
            this.Next = new System.Windows.Forms.Button();
            this.Buck = new System.Windows.Forms.Button();
            this.QuestionNumber = new System.Windows.Forms.LinkLabel();
            this.NavigatingNum = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.AnswerField = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).BeginInit();
            this.QuestionField.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Navigation.SuspendLayout();
            this.NavigatingNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextQuestion
            // 
            this.TextQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextQuestion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextQuestion.Location = new System.Drawing.Point(0, 0);
            this.TextQuestion.MinimumSize = new System.Drawing.Size(520, 0);
            this.TextQuestion.Name = "TextQuestion";
            this.TextQuestion.Size = new System.Drawing.Size(529, 85);
            this.TextQuestion.TabIndex = 0;
            this.TextQuestion.Text = "Вопрос";
            // 
            // QuestionImage
            // 
            this.QuestionImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionImage.Image = ((System.Drawing.Image)(resources.GetObject("QuestionImage.Image")));
            this.QuestionImage.Location = new System.Drawing.Point(164, 61);
            this.QuestionImage.Name = "QuestionImage";
            this.QuestionImage.Size = new System.Drawing.Size(286, 190);
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
            this.QuestionField.Controls.Add(this.QuestionImage);
            this.QuestionField.Controls.Add(this.TextQuestion);
            this.QuestionField.Controls.Add(this.Navigation);
            this.QuestionField.Location = new System.Drawing.Point(0, 0);
            this.QuestionField.MinimumSize = new System.Drawing.Size(690, 25);
            this.QuestionField.Name = "QuestionField";
            this.QuestionField.Size = new System.Drawing.Size(702, 409);
            this.QuestionField.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.QuestionField);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(702, 409);
            this.panel4.TabIndex = 15;
            // 
            // Navigation
            // 
            this.Navigation.Controls.Add(this.NavigatingNum);
            this.Navigation.Controls.Add(this.QuestionNumber);
            this.Navigation.Controls.Add(this.Next);
            this.Navigation.Controls.Add(this.Buck);
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Right;
            this.Navigation.Location = new System.Drawing.Point(529, 0);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(173, 409);
            this.Navigation.TabIndex = 13;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(105, 210);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(68, 41);
            this.Next.TabIndex = 12;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Buck
            // 
            this.Buck.Location = new System.Drawing.Point(2, 210);
            this.Buck.Name = "Buck";
            this.Buck.Size = new System.Drawing.Size(68, 40);
            this.Buck.TabIndex = 11;
            this.Buck.Text = "Назад";
            this.Buck.UseVisualStyleBackColor = true;
            // 
            // QuestionNumber
            // 
            this.QuestionNumber.AutoSize = true;
            this.QuestionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionNumber.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionNumber.Location = new System.Drawing.Point(76, 215);
            this.QuestionNumber.Name = "QuestionNumber";
            this.QuestionNumber.Size = new System.Drawing.Size(25, 28);
            this.QuestionNumber.TabIndex = 15;
            this.QuestionNumber.TabStop = true;
            this.QuestionNumber.Text = "1";
            // 
            // NavigatingNum
            // 
            this.NavigatingNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NavigatingNum.Controls.Add(this.linkLabel1);
            this.NavigatingNum.Location = new System.Drawing.Point(6, 2);
            this.NavigatingNum.Name = "NavigatingNum";
            this.NavigatingNum.Size = new System.Drawing.Size(163, 202);
            this.NavigatingNum.TabIndex = 16;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.Location = new System.Drawing.Point(3, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(25, 28);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "1";
            // 
            // AnswerField
            // 
            this.AnswerField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswerField.AutoScroll = true;
            this.AnswerField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AnswerField.Location = new System.Drawing.Point(0, 257);
            this.AnswerField.Name = "AnswerField";
            this.AnswerField.Size = new System.Drawing.Size(698, 152);
            this.AnswerField.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 411);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 450);
            this.Name = "Form1";
            this.Text = "Тест";
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).EndInit();
            this.QuestionField.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.Navigation.ResumeLayout(false);
            this.Navigation.PerformLayout();
            this.NavigatingNum.ResumeLayout(false);
            this.NavigatingNum.PerformLayout();
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
        private System.Windows.Forms.LinkLabel QuestionNumber;
        private System.Windows.Forms.Panel NavigatingNum;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FlowLayoutPanel AnswerField;
    }
}


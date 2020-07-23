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
            this.Navigation = new System.Windows.Forms.Panel();
            this.NavigatingNum = new System.Windows.Forms.FlowLayoutPanel();
            this.Next = new System.Windows.Forms.Button();
            this.Buck = new System.Windows.Forms.Button();
            this.QuestionField = new System.Windows.Forms.Panel();
            this.AnswerField = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).BeginInit();
            this.Navigation.SuspendLayout();
            this.QuestionField.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextQuestion
            // 
            this.TextQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TextQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextQuestion.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextQuestion.Location = new System.Drawing.Point(0, 0);
            this.TextQuestion.MinimumSize = new System.Drawing.Size(520, 0);
            this.TextQuestion.Name = "TextQuestion";
            this.TextQuestion.Size = new System.Drawing.Size(621, 55);
            this.TextQuestion.TabIndex = 0;
            this.TextQuestion.Text = "Вопрос";
            // 
            // QuestionImage
            // 
            this.QuestionImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionImage.Location = new System.Drawing.Point(128, 58);
            this.QuestionImage.Name = "QuestionImage";
            this.QuestionImage.Size = new System.Drawing.Size(379, 170);
            this.QuestionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QuestionImage.TabIndex = 1;
            this.QuestionImage.TabStop = false;
            // 
            // Navigation
            // 
            this.Navigation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Navigation.Controls.Add(this.NavigatingNum);
            this.Navigation.Controls.Add(this.Next);
            this.Navigation.Controls.Add(this.Buck);
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Right;
            this.Navigation.Location = new System.Drawing.Point(621, 0);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(183, 234);
            this.Navigation.TabIndex = 13;
            // 
            // NavigatingNum
            // 
            this.NavigatingNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NavigatingNum.Location = new System.Drawing.Point(4, 8);
            this.NavigatingNum.Name = "NavigatingNum";
            this.NavigatingNum.Size = new System.Drawing.Size(169, 149);
            this.NavigatingNum.TabIndex = 16;
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(92, 163);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(90, 40);
            this.Next.TabIndex = 12;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Buck
            // 
            this.Buck.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Buck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Buck.Location = new System.Drawing.Point(0, 164);
            this.Buck.Name = "Buck";
            this.Buck.Size = new System.Drawing.Size(90, 40);
            this.Buck.TabIndex = 11;
            this.Buck.Text = "Назад";
            this.Buck.UseVisualStyleBackColor = false;
            this.Buck.Click += new System.EventHandler(this.Buck_Click);
            // 
            // QuestionField
            // 
            this.QuestionField.Controls.Add(this.TextQuestion);
            this.QuestionField.Controls.Add(this.QuestionImage);
            this.QuestionField.Controls.Add(this.Navigation);
            this.QuestionField.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestionField.Location = new System.Drawing.Point(0, 0);
            this.QuestionField.Name = "QuestionField";
            this.QuestionField.Size = new System.Drawing.Size(804, 234);
            this.QuestionField.TabIndex = 14;
            // 
            // AnswerField
            // 
            this.AnswerField.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AnswerField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnswerField.Location = new System.Drawing.Point(0, 234);
            this.AnswerField.Name = "AnswerField";
            this.AnswerField.Size = new System.Drawing.Size(804, 177);
            this.AnswerField.TabIndex = 15;
            this.AnswerField.Resize += new System.EventHandler(this.AnswerField_Resize);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(804, 411);
            this.Controls.Add(this.AnswerField);
            this.Controls.Add(this.QuestionField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).EndInit();
            this.Navigation.ResumeLayout(false);
            this.QuestionField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel QuestionField;
        private System.Windows.Forms.Panel Navigation;
        private System.Windows.Forms.FlowLayoutPanel NavigatingNum;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Buck;
        private System.Windows.Forms.PictureBox QuestionImage;
        private System.Windows.Forms.Label TextQuestion;
        private System.Windows.Forms.Panel AnswerField;
    }
}


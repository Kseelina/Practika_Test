namespace GUI
{
    partial class Result
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Info = new System.Windows.Forms.Panel();
            this.Restart = new System.Windows.Forms.Button();
            this.CorrectAnswers = new System.Windows.Forms.Label();
            this.FindingResults = new System.Windows.Forms.FlowLayoutPanel();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Controls.Add(this.Restart);
            this.Info.Controls.Add(this.CorrectAnswers);
            this.Info.Location = new System.Drawing.Point(8, 7);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(720, 107);
            this.Info.TabIndex = 1;
            // 
            // Restart
            // 
            this.Restart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Restart.Location = new System.Drawing.Point(428, 33);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(289, 33);
            this.Restart.TabIndex = 1;
            this.Restart.Text = "Начать заново";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.button1_Click);
            // 
            // CorrectAnswers
            // 
            this.CorrectAnswers.AutoSize = true;
            this.CorrectAnswers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CorrectAnswers.Location = new System.Drawing.Point(4, 32);
            this.CorrectAnswers.Name = "CorrectAnswers";
            this.CorrectAnswers.Size = new System.Drawing.Size(263, 31);
            this.CorrectAnswers.TabIndex = 0;
            this.CorrectAnswers.Text = "Правильных ответов: ";
            // 
            // FindingResults
            // 
            this.FindingResults.AutoScroll = true;
            this.FindingResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FindingResults.Location = new System.Drawing.Point(8, 120);
            this.FindingResults.Name = "FindingResults";
            this.FindingResults.Size = new System.Drawing.Size(719, 338);
            this.FindingResults.TabIndex = 2;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.FindingResults);
            this.Controls.Add(this.Info);
            this.Name = "Result";
            this.Text = "Окно результата";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Result_FormClosing);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Info;
        private System.Windows.Forms.Label CorrectAnswers;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.FlowLayoutPanel FindingResults;
    }
}
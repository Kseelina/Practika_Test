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
            this.label1 = new System.Windows.Forms.Label();
            this.Restart = new System.Windows.Forms.Button();
            this.CorrectAnswers = new System.Windows.Forms.Label();
            this.FindingResults = new System.Windows.Forms.FlowLayoutPanel();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Info.Controls.Add(this.label1);
            this.Info.Controls.Add(this.Restart);
            this.Info.Controls.Add(this.CorrectAnswers);
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(674, 107);
            this.Info.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Результат теста";
            // 
            // Restart
            // 
            this.Restart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Restart.BackColor = System.Drawing.SystemColors.Control;
            this.Restart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Restart.Location = new System.Drawing.Point(368, 33);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(289, 33);
            this.Restart.TabIndex = 1;
            this.Restart.Text = "Начать заново";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.button1_Click);
            // 
            // CorrectAnswers
            // 
            this.CorrectAnswers.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CorrectAnswers.Location = new System.Drawing.Point(4, 32);
            this.CorrectAnswers.MaximumSize = new System.Drawing.Size(0, 90);
            this.CorrectAnswers.Name = "CorrectAnswers";
            this.CorrectAnswers.Size = new System.Drawing.Size(0, 90);
            this.CorrectAnswers.TabIndex = 0;
            this.CorrectAnswers.Text = "Результат";
            // 
            // FindingResults
            // 
            this.FindingResults.AutoScroll = true;
            this.FindingResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FindingResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FindingResults.Location = new System.Drawing.Point(0, 107);
            this.FindingResults.Name = "FindingResults";
            this.FindingResults.Size = new System.Drawing.Size(674, 354);
            this.FindingResults.TabIndex = 2;
            this.FindingResults.WrapContents = false;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 461);
            this.Controls.Add(this.FindingResults);
            this.Controls.Add(this.Info);
            this.MinimumSize = new System.Drawing.Size(690, 500);
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
        private System.Windows.Forms.Label label1;
    }
}
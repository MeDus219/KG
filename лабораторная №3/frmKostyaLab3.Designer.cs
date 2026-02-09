namespace HelloWorld.лабораторная__3
{
    partial class frmKostyaLab3
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnChangeColors = new System.Windows.Forms.Button();
            this.trackBarFontSize = new System.Windows.Forms.TrackBar();
            this.txtWord = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(204, 340);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(95, 26);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Старт/Стоп";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnChangeColors
            // 
            this.btnChangeColors.Location = new System.Drawing.Point(328, 340);
            this.btnChangeColors.Name = "btnChangeColors";
            this.btnChangeColors.Size = new System.Drawing.Size(98, 26);
            this.btnChangeColors.TabIndex = 1;
            this.btnChangeColors.Text = "Цвет";
            this.btnChangeColors.UseVisualStyleBackColor = true;
            this.btnChangeColors.Click += new System.EventHandler(this.btnChangeColors_Click);
            // 
            // trackBarFontSize
            // 
            this.trackBarFontSize.Location = new System.Drawing.Point(469, 340);
            this.trackBarFontSize.Maximum = 200;
            this.trackBarFontSize.Minimum = 1;
            this.trackBarFontSize.Name = "trackBarFontSize";
            this.trackBarFontSize.Size = new System.Drawing.Size(104, 45);
            this.trackBarFontSize.TabIndex = 2;
            this.trackBarFontSize.Value = 1;
            this.trackBarFontSize.Scroll += new System.EventHandler(this.trackBarFontSize_Scroll);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(609, 346);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(100, 20);
            this.txtWord.TabIndex = 3;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // frmWordMylnikovSlave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.trackBarFontSize);
            this.Controls.Add(this.btnChangeColors);
            this.Controls.Add(this.btnStartStop);
            this.Name = "frmWordMylnikovSlave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вращение слова";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnChangeColors;
        private System.Windows.Forms.TrackBar trackBarFontSize;
        private System.Windows.Forms.TextBox txtWord;
    }
}
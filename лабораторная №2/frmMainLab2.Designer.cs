namespace HelloWorld
{
    partial class frmMainLab2
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
            this.btnSlaveDimaLab2 = new System.Windows.Forms.Button();
            this.btnDirectorLab2 = new System.Windows.Forms.Button();
            this.btnWriterLab2 = new System.Windows.Forms.Button();
            this.btnSlaveRomaLab2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSlaveDimaLab2
            // 
            this.btnSlaveDimaLab2.Location = new System.Drawing.Point(12, 12);
            this.btnSlaveDimaLab2.Name = "btnSlaveDimaLab2";
            this.btnSlaveDimaLab2.Size = new System.Drawing.Size(344, 63);
            this.btnSlaveDimaLab2.TabIndex = 0;
            this.btnSlaveDimaLab2.Text = "Дрягин Д. А. (и)";
            this.btnSlaveDimaLab2.UseVisualStyleBackColor = true;
            this.btnSlaveDimaLab2.Click += new System.EventHandler(this.btnSlaveDima_Click);
            // 
            // btnDirectorLab2
            // 
            this.btnDirectorLab2.Location = new System.Drawing.Point(12, 81);
            this.btnDirectorLab2.Name = "btnDirectorLab2";
            this.btnDirectorLab2.Size = new System.Drawing.Size(344, 66);
            this.btnDirectorLab2.TabIndex = 1;
            this.btnDirectorLab2.Text = "Мыльников К. А. (рук)";
            this.btnDirectorLab2.UseVisualStyleBackColor = true;
            this.btnDirectorLab2.Click += new System.EventHandler(this.btnDirectorLab2_Click);
            // 
            // btnWriterLab2
            // 
            this.btnWriterLab2.Location = new System.Drawing.Point(13, 153);
            this.btnWriterLab2.Name = "btnWriterLab2";
            this.btnWriterLab2.Size = new System.Drawing.Size(344, 60);
            this.btnWriterLab2.TabIndex = 2;
            this.btnWriterLab2.Text = "Кадыков М. Д. (тп)";
            this.btnWriterLab2.UseVisualStyleBackColor = true;
            this.btnWriterLab2.Click += new System.EventHandler(this.btnWriterLab2_Click);
            // 
            // btnSlaveRomaLab2
            // 
            this.btnSlaveRomaLab2.Location = new System.Drawing.Point(12, 219);
            this.btnSlaveRomaLab2.Name = "btnSlaveRomaLab2";
            this.btnSlaveRomaLab2.Size = new System.Drawing.Size(344, 63);
            this.btnSlaveRomaLab2.TabIndex = 3;
            this.btnSlaveRomaLab2.Text = "Литвиненко Р. Е. (и)";
            this.btnSlaveRomaLab2.UseVisualStyleBackColor = true;
            this.btnSlaveRomaLab2.Click += new System.EventHandler(this.btnSlaveRomaLab2_Click);
            // 
            // frmMainLab2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 290);
            this.Controls.Add(this.btnSlaveRomaLab2);
            this.Controls.Add(this.btnWriterLab2);
            this.Controls.Add(this.btnDirectorLab2);
            this.Controls.Add(this.btnSlaveDimaLab2);
            this.Name = "frmMainLab2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSlaveDimaLab2;
        private System.Windows.Forms.Button btnDirectorLab2;
        private System.Windows.Forms.Button btnWriterLab2;
        private System.Windows.Forms.Button btnSlaveRomaLab2;
    }
}
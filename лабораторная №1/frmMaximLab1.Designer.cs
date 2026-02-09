namespace HelloWorld
{
    partial class frmMaximLab1
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
            this.buttonModule = new System.Windows.Forms.Button();
            this.buttonVektor = new System.Windows.Forms.Button();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.textBoxZ1 = new System.Windows.Forms.TextBox();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.textBoxZ2 = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonModule
            // 
            this.buttonModule.Location = new System.Drawing.Point(20, 24);
            this.buttonModule.Name = "buttonModule";
            this.buttonModule.Size = new System.Drawing.Size(105, 56);
            this.buttonModule.TabIndex = 0;
            this.buttonModule.Text = "Модуль вектора";
            this.buttonModule.UseVisualStyleBackColor = true;
            this.buttonModule.Click += new System.EventHandler(this.buttonModule_Click);
            // 
            // buttonVektor
            // 
            this.buttonVektor.Location = new System.Drawing.Point(20, 114);
            this.buttonVektor.Name = "buttonVektor";
            this.buttonVektor.Size = new System.Drawing.Size(105, 58);
            this.buttonVektor.TabIndex = 1;
            this.buttonVektor.Text = "Векторное произведение векторов";
            this.buttonVektor.UseVisualStyleBackColor = true;
            this.buttonVektor.Click += new System.EventHandler(this.buttonVektor_Click);
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(173, 12);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(100, 20);
            this.textBoxX1.TabIndex = 2;
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(173, 38);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(100, 20);
            this.textBoxY1.TabIndex = 3;
            // 
            // textBoxZ1
            // 
            this.textBoxZ1.Location = new System.Drawing.Point(173, 64);
            this.textBoxZ1.Name = "textBoxZ1";
            this.textBoxZ1.Size = new System.Drawing.Size(100, 20);
            this.textBoxZ1.TabIndex = 4;
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(173, 108);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(100, 20);
            this.textBoxX2.TabIndex = 5;
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(173, 134);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(100, 20);
            this.textBoxY2.TabIndex = 6;
            // 
            // textBoxZ2
            // 
            this.textBoxZ2.Location = new System.Drawing.Point(173, 160);
            this.textBoxZ2.Name = "textBoxZ2";
            this.textBoxZ2.Size = new System.Drawing.Size(100, 20);
            this.textBoxZ2.TabIndex = 7;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(32, 197);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(65, 13);
            this.labelResult.TabIndex = 8;
            this.labelResult.Text = "Результат: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "x1=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "y1= ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "z1=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "x2=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "y2=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "z2=";
            // 
            // LabMax1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 225);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.textBoxZ2);
            this.Controls.Add(this.textBoxY2);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxZ1);
            this.Controls.Add(this.textBoxY1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.buttonVektor);
            this.Controls.Add(this.buttonModule);
            this.Name = "LabMax1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вариант 2 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonModule;
        private System.Windows.Forms.Button buttonVektor;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.TextBox textBoxZ1;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.TextBox textBoxZ2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
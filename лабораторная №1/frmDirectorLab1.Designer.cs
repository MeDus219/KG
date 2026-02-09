namespace HelloWorld
{
    partial class frmDirectorLab1
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
            this.btnClickThis = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintMatrix1 = new System.Windows.Forms.Button();
            this.PrintMatrix2 = new System.Windows.Forms.Button();
            this.MatrixMultiplicate = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddMatrix = new System.Windows.Forms.Button();
            this.SubtractionMatrix = new System.Windows.Forms.Button();
            this.TranspositionMatrix = new System.Windows.Forms.Button();
            this.PrintMatrix3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClickThis
            // 
            this.btnClickThis.Location = new System.Drawing.Point(21, 12);
            this.btnClickThis.Name = "btnClickThis";
            this.btnClickThis.Size = new System.Drawing.Size(75, 23);
            this.btnClickThis.TabIndex = 0;
            this.btnClickThis.Text = "Click this";
            this.btnClickThis.UseVisualStyleBackColor = true;
            this.btnClickThis.Click += new System.EventHandler(this.btnClickThis_Click);
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(18, 50);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(32, 13);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = "result";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show Hello";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "result";
            // 
            // PrintMatrix1
            // 
            this.PrintMatrix1.Location = new System.Drawing.Point(242, 41);
            this.PrintMatrix1.Name = "PrintMatrix1";
            this.PrintMatrix1.Size = new System.Drawing.Size(111, 23);
            this.PrintMatrix1.TabIndex = 4;
            this.PrintMatrix1.Text = "Ввод матрицы 1...";
            this.PrintMatrix1.UseVisualStyleBackColor = true;
            this.PrintMatrix1.Click += new System.EventHandler(this.PrintMatrix1_Click);
            // 
            // PrintMatrix2
            // 
            this.PrintMatrix2.Location = new System.Drawing.Point(242, 70);
            this.PrintMatrix2.Name = "PrintMatrix2";
            this.PrintMatrix2.Size = new System.Drawing.Size(111, 23);
            this.PrintMatrix2.TabIndex = 5;
            this.PrintMatrix2.Text = "Ввод матрицы 2...";
            this.PrintMatrix2.UseVisualStyleBackColor = true;
            this.PrintMatrix2.Click += new System.EventHandler(this.PrintMatrix2_Click);
            // 
            // MatrixMultiplicate
            // 
            this.MatrixMultiplicate.Location = new System.Drawing.Point(242, 99);
            this.MatrixMultiplicate.Name = "MatrixMultiplicate";
            this.MatrixMultiplicate.Size = new System.Drawing.Size(191, 23);
            this.MatrixMultiplicate.TabIndex = 6;
            this.MatrixMultiplicate.Text = "Умножение матриц 1 и 2";
            this.MatrixMultiplicate.UseVisualStyleBackColor = true;
            this.MatrixMultiplicate.Click += new System.EventHandler(this.MatrixMultiplicate_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(242, 128);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(191, 23);
            this.SaveFile.TabIndex = 7;
            this.SaveFile.Text = "Сохранить в файле “Res_Matr.txt”";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "n = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "false";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "false";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // AddMatrix
            // 
            this.AddMatrix.Location = new System.Drawing.Point(439, 99);
            this.AddMatrix.Name = "AddMatrix";
            this.AddMatrix.Size = new System.Drawing.Size(163, 23);
            this.AddMatrix.TabIndex = 12;
            this.AddMatrix.Text = "Сложение матриц";
            this.AddMatrix.UseVisualStyleBackColor = true;
            this.AddMatrix.Click += new System.EventHandler(this.AddMatrix_Click);
            // 
            // SubtractionMatrix
            // 
            this.SubtractionMatrix.Location = new System.Drawing.Point(439, 128);
            this.SubtractionMatrix.Name = "SubtractionMatrix";
            this.SubtractionMatrix.Size = new System.Drawing.Size(163, 23);
            this.SubtractionMatrix.TabIndex = 13;
            this.SubtractionMatrix.Text = "Вычитание матриц";
            this.SubtractionMatrix.UseVisualStyleBackColor = true;
            this.SubtractionMatrix.Click += new System.EventHandler(this.SubtractionMatrix_Click);
            // 
            // TranspositionMatrix
            // 
            this.TranspositionMatrix.Location = new System.Drawing.Point(12, 190);
            this.TranspositionMatrix.Name = "TranspositionMatrix";
            this.TranspositionMatrix.Size = new System.Drawing.Size(360, 23);
            this.TranspositionMatrix.TabIndex = 14;
            this.TranspositionMatrix.Text = "Транспонирование матрицы";
            this.TranspositionMatrix.UseVisualStyleBackColor = true;
            this.TranspositionMatrix.Click += new System.EventHandler(this.TranspositionMatrix_Click);
            // 
            // PrintMatrix3
            // 
            this.PrintMatrix3.Location = new System.Drawing.Point(12, 161);
            this.PrintMatrix3.Name = "PrintMatrix3";
            this.PrintMatrix3.Size = new System.Drawing.Size(111, 23);
            this.PrintMatrix3.TabIndex = 15;
            this.PrintMatrix3.Text = "Ввод матрицы 3...";
            this.PrintMatrix3.UseVisualStyleBackColor = true;
            this.PrintMatrix3.Click += new System.EventHandler(this.PrintMatrix3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "false";
            // 
            // HelloAndMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PrintMatrix3);
            this.Controls.Add(this.TranspositionMatrix);
            this.Controls.Add(this.SubtractionMatrix);
            this.Controls.Add(this.AddMatrix);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.MatrixMultiplicate);
            this.Controls.Add(this.PrintMatrix2);
            this.Controls.Add(this.PrintMatrix1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.btnClickThis);
            this.MaximizeBox = false;
            this.Name = "frmDirector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hello World! и Произведение матриц + Вариант 5";
            this.Load += new System.EventHandler(this.HelloAndMatrix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickThis;
        private System.Windows.Forms.Label lblHelloWorld;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrintMatrix1;
        private System.Windows.Forms.Button PrintMatrix2;
        private System.Windows.Forms.Button MatrixMultiplicate;
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AddMatrix;
        private System.Windows.Forms.Button SubtractionMatrix;
        private System.Windows.Forms.Button TranspositionMatrix;
        private System.Windows.Forms.Button PrintMatrix3;
        private System.Windows.Forms.Label label5;
    }
}


namespace HelloWorld
{
    partial class frmSlaveLab1
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
            this.btnCalculateDotProduct = new System.Windows.Forms.Button();
            this.btnMatrixVectorMultiplication = new System.Windows.Forms.Button();
            this.txtVectorA = new System.Windows.Forms.TextBox();
            this.txtVectorB = new System.Windows.Forms.TextBox();
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.txtVector = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculateDotProduct
            // 
            this.btnCalculateDotProduct.Location = new System.Drawing.Point(12, 25);
            this.btnCalculateDotProduct.Name = "btnCalculateDotProduct";
            this.btnCalculateDotProduct.Size = new System.Drawing.Size(164, 43);
            this.btnCalculateDotProduct.TabIndex = 0;
            this.btnCalculateDotProduct.Text = "Скалярное произведение векторов";
            this.btnCalculateDotProduct.UseVisualStyleBackColor = true;
            this.btnCalculateDotProduct.Click += new System.EventHandler(this.btnCalculateDotProduct_Click);
            // 
            // btnMatrixVectorMultiplication
            // 
            this.btnMatrixVectorMultiplication.Location = new System.Drawing.Point(12, 85);
            this.btnMatrixVectorMultiplication.Name = "btnMatrixVectorMultiplication";
            this.btnMatrixVectorMultiplication.Size = new System.Drawing.Size(164, 44);
            this.btnMatrixVectorMultiplication.TabIndex = 1;
            this.btnMatrixVectorMultiplication.Text = "Умножение матрицы на вектор";
            this.btnMatrixVectorMultiplication.UseVisualStyleBackColor = true;
            this.btnMatrixVectorMultiplication.Click += new System.EventHandler(this.btnMatrixVectorMultiplication_Click);
            // 
            // txtVectorA
            // 
            this.txtVectorA.Location = new System.Drawing.Point(199, 25);
            this.txtVectorA.Name = "txtVectorA";
            this.txtVectorA.Size = new System.Drawing.Size(166, 20);
            this.txtVectorA.TabIndex = 2;
            // 
            // txtVectorB
            // 
            this.txtVectorB.Location = new System.Drawing.Point(199, 48);
            this.txtVectorB.Name = "txtVectorB";
            this.txtVectorB.Size = new System.Drawing.Size(166, 20);
            this.txtVectorB.TabIndex = 3;
            // 
            // txtMatrix
            // 
            this.txtMatrix.Location = new System.Drawing.Point(199, 85);
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.Size = new System.Drawing.Size(166, 20);
            this.txtMatrix.TabIndex = 4;
            // 
            // txtVector
            // 
            this.txtVector.Location = new System.Drawing.Point(199, 109);
            this.txtVector.Name = "txtVector";
            this.txtVector.Size = new System.Drawing.Size(166, 20);
            this.txtVector.TabIndex = 5;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(42, 138);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(62, 13);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Результат:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "! записывать через запятую значения векторов(double через точку) !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "для матрицы: строка1;  строка2; строка3; строка4";
            // 
            // LabRoman1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 162);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtVector);
            this.Controls.Add(this.txtMatrix);
            this.Controls.Add(this.txtVectorB);
            this.Controls.Add(this.txtVectorA);
            this.Controls.Add(this.btnMatrixVectorMultiplication);
            this.Controls.Add(this.btnCalculateDotProduct);
            this.Name = "LabRoman1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вариант 3 6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculateDotProduct;
        private System.Windows.Forms.Button btnMatrixVectorMultiplication;
        private System.Windows.Forms.TextBox txtVectorA;
        private System.Windows.Forms.TextBox txtVectorB;
        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.TextBox txtVector;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
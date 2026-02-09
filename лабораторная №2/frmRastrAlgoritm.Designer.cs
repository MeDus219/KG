using System.Windows.Forms;

namespace HelloWorld
{
    partial class frmRastrAlgoritm
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.chkDashed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numThickness = new System.Windows.Forms.NumericUpDown();
            this.numLengthLine = new System.Windows.Forms.NumericUpDown();
            this.btnColorFilling = new System.Windows.Forms.Button();
            this.btnColorLine = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnClearCanvas = new System.Windows.Forms.Button();
            this.grpAlgoritm = new System.Windows.Forms.GroupBox();
            this.rdoDrawBresenham = new System.Windows.Forms.RadioButton();
            this.rdoFillingArea = new System.Windows.Forms.RadioButton();
            this.rdoDrawCDA = new System.Windows.Forms.RadioButton();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthLine)).BeginInit();
            this.grpAlgoritm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolbar.Controls.Add(this.chkDashed);
            this.pnlToolbar.Controls.Add(this.label3);
            this.pnlToolbar.Controls.Add(this.label2);
            this.pnlToolbar.Controls.Add(this.label1);
            this.pnlToolbar.Controls.Add(this.numThickness);
            this.pnlToolbar.Controls.Add(this.numLengthLine);
            this.pnlToolbar.Controls.Add(this.btnColorFilling);
            this.pnlToolbar.Controls.Add(this.btnColorLine);
            this.pnlToolbar.Controls.Add(this.btnComplete);
            this.pnlToolbar.Controls.Add(this.btnClearCanvas);
            this.pnlToolbar.Controls.Add(this.grpAlgoritm);
            this.pnlToolbar.Location = new System.Drawing.Point(456, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(202, 450);
            this.pnlToolbar.TabIndex = 0;
            // 
            // chkDashed
            // 
            this.chkDashed.AutoSize = true;
            this.chkDashed.Location = new System.Drawing.Point(19, 141);
            this.chkDashed.Name = "chkDashed";
            this.chkDashed.Size = new System.Drawing.Size(68, 17);
            this.chkDashed.TabIndex = 10;
            this.chkDashed.Text = "Пунктир";
            this.chkDashed.UseVisualStyleBackColor = true;
            this.chkDashed.CheckedChanged += new System.EventHandler(this.chkDashed_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Стиль линии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Длина штриха";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Толщина линии";
            // 
            // numThickness
            // 
            this.numThickness.Location = new System.Drawing.Point(19, 194);
            this.numThickness.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.Name = "numThickness";
            this.numThickness.Size = new System.Drawing.Size(120, 20);
            this.numThickness.TabIndex = 6;
            this.numThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThickness.ValueChanged += new System.EventHandler(this.numThickness_ValueChanged);
            // 
            // numLengthLine
            // 
            this.numLengthLine.Location = new System.Drawing.Point(19, 244);
            this.numLengthLine.Name = "numLengthLine";
            this.numLengthLine.Size = new System.Drawing.Size(120, 20);
            this.numLengthLine.TabIndex = 2;
            this.numLengthLine.ValueChanged += new System.EventHandler(this.numLengthLine_ValueChanged);
            // 
            // btnColorFilling
            // 
            this.btnColorFilling.Location = new System.Drawing.Point(102, 379);
            this.btnColorFilling.Name = "btnColorFilling";
            this.btnColorFilling.Size = new System.Drawing.Size(94, 28);
            this.btnColorFilling.TabIndex = 5;
            this.btnColorFilling.Text = "Цвет заливки";
            this.btnColorFilling.UseVisualStyleBackColor = true;
            this.btnColorFilling.Click += new System.EventHandler(this.btnColorFilling_Click);
            // 
            // btnColorLine
            // 
            this.btnColorLine.Location = new System.Drawing.Point(3, 379);
            this.btnColorLine.Name = "btnColorLine";
            this.btnColorLine.Size = new System.Drawing.Size(93, 29);
            this.btnColorLine.TabIndex = 3;
            this.btnColorLine.Text = "Цвет линии";
            this.btnColorLine.UseVisualStyleBackColor = true;
            this.btnColorLine.Click += new System.EventHandler(this.btnColorLine_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(3, 414);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(93, 31);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "Выполнить";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnClearCanvas
            // 
            this.btnClearCanvas.Location = new System.Drawing.Point(102, 414);
            this.btnClearCanvas.Name = "btnClearCanvas";
            this.btnClearCanvas.Size = new System.Drawing.Size(95, 31);
            this.btnClearCanvas.TabIndex = 1;
            this.btnClearCanvas.Text = "Очистить";
            this.btnClearCanvas.UseVisualStyleBackColor = true;
            this.btnClearCanvas.Click += new System.EventHandler(this.btnClearCanvas_Click);
            // 
            // grpAlgoritm
            // 
            this.grpAlgoritm.Controls.Add(this.rdoDrawBresenham);
            this.grpAlgoritm.Controls.Add(this.rdoFillingArea);
            this.grpAlgoritm.Controls.Add(this.rdoDrawCDA);
            this.grpAlgoritm.Location = new System.Drawing.Point(13, 11);
            this.grpAlgoritm.Name = "grpAlgoritm";
            this.grpAlgoritm.Size = new System.Drawing.Size(162, 100);
            this.grpAlgoritm.TabIndex = 0;
            this.grpAlgoritm.TabStop = false;
            this.grpAlgoritm.Text = "Выберите алгоритм";
            // 
            // rdoDrawBresenham
            // 
            this.rdoDrawBresenham.AutoSize = true;
            this.rdoDrawBresenham.Location = new System.Drawing.Point(6, 65);
            this.rdoDrawBresenham.Name = "rdoDrawBresenham";
            this.rdoDrawBresenham.Size = new System.Drawing.Size(127, 17);
            this.rdoDrawBresenham.TabIndex = 6;
            this.rdoDrawBresenham.TabStop = true;
            this.rdoDrawBresenham.Text = "Отрезок Брезенхем";
            this.rdoDrawBresenham.UseVisualStyleBackColor = true;
            // 
            // rdoFillingArea
            // 
            this.rdoFillingArea.AutoSize = true;
            this.rdoFillingArea.Location = new System.Drawing.Point(6, 42);
            this.rdoFillingArea.Name = "rdoFillingArea";
            this.rdoFillingArea.Size = new System.Drawing.Size(68, 17);
            this.rdoFillingArea.TabIndex = 1;
            this.rdoFillingArea.TabStop = true;
            this.rdoFillingArea.Text = "Заливка";
            this.rdoFillingArea.UseVisualStyleBackColor = true;
            // 
            // rdoDrawCDA
            // 
            this.rdoDrawCDA.AutoSize = true;
            this.rdoDrawCDA.Location = new System.Drawing.Point(6, 19);
            this.rdoDrawCDA.Name = "rdoDrawCDA";
            this.rdoDrawCDA.Size = new System.Drawing.Size(99, 17);
            this.rdoDrawCDA.TabIndex = 0;
            this.rdoDrawCDA.TabStop = true;
            this.rdoDrawCDA.Text = "Обычный ЦДА";
            this.rdoDrawCDA.UseVisualStyleBackColor = true;
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(450, 450);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // frmRastrAlgoritm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 450);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.pnlToolbar);
            this.Name = "frmRastrAlgoritm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Растровые алгоритмы";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthLine)).EndInit();
            this.grpAlgoritm.ResumeLayout(false);
            this.grpAlgoritm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClearCanvas;
        private System.Windows.Forms.GroupBox grpAlgoritm;
        private System.Windows.Forms.RadioButton rdoDrawCDA;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.RadioButton rdoFillingArea;
        private System.Windows.Forms.Button btnColorLine;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColorFilling;
        private RadioButton rdoDrawBresenham;
        private NumericUpDown numLengthLine;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown numThickness;
        private CheckBox chkDashed;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    /// <summary>
    /// Основная форма приложения для работы с матрицами.
    /// </summary>
    public partial class frmWriterLab1 : Form
    {        
        double constant;// Константа для операций с матрицами
        const int MaxN = 10; // максимально допустимая размерность матрицы         
        int n = 3; // текущая размерность матрицы 
        TextBox[,] MatrText = null; // матрица элементов TextBox
        double[,] Matr1 = new double[MaxN, MaxN]; // матрица 1 чисел плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxN]; // матрица 2 чисел плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxN]; // матрица результатов 
        bool f1; // флажок, который указывает о вводе данных в Matr1
        bool f2; // флажок, который указывает о вводе данных в Matr2
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]  
        frmOK form3 = null;   // экземпляр (объект) класса формы Form3 

        /// <summary>
        /// Конструктор класса Lab1Kostya, инициализирует компоненты формы.
        /// </summary>
        public frmWriterLab1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обнуляет все ячейки матрицы MatrText.
        /// </summary>
        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для чтения размерности матрицы и настройки интерфейса.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнуление ячейки MatrText
            Clear_MatrText();

            // 3. Настройка свойств ячеек матрицы MatrText
            //    с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // 4. Корректировка размеров формы
            form3.Width = 10 + n * dx + 20;
            form3.Height = 10 + n * dy + form3.button1.Height + 50;

            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form3.button1.Left = 10;
            form3.button1.Top = 10 + n * dy + 10;
            form3.button1.Width = form3.Width - 30;

            // 6. Вызов формы Form2
            if (form3.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. Данные в матрицу Matr1 внесены
                f1 = true;
                label2.Text = "true";
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для умножения матрицы на константу.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") return;
            constant = double.Parse(textBox2.Text);
            // 1. Проверка, введены ли данные в обеих матрицах    
            if (!(f1 == true)) return;
            // 2. Вычисление произведения матриц. Результат в Matr3    
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = Matr1[j, i] * constant;

                }
            // 3. Внесение данных в MatrText    
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции        
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Перевести число в строку        
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. Вывод формы    
            form3.ShowDialog();
        }


        /// <summary>
        /// Обработчик события загрузки формы Lab1Kostya.
        /// Инициализирует элементы управления, выделяет память для матрицы и настраивает текстовые поля.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void Lab1Kostya_Load(object sender, EventArgs e)
        {
            // І. Инициализация элементов управления и внутренних переменных   
            textBox1.Text = "";
            f1 = f2 = false; // матрицы еще не заполнены    
            label2.Text = "false";
            // ІІ. Выделение памяти и настройка MatrText    
            int i, j;
            // 1. Выделение памяти для формы Form2    
            form3 = new frmOK();
            // 2. Выделение памяти под самую матрицу    
            MatrText = new TextBox[MaxN, MaxN];
            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка 
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. Выделить память        
                    MatrText[i, j] = new TextBox();
                    // 3.2. Обнулить эту ячейку        
                    MatrText[i, j].Text = "0";
                    // 3.3. Установить позицию ячейки в форме Form2 
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i *
                    dx, 10 + j * dy);
                    // 3.4. Установить размер ячейки        
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    // 3.5. Пока что спрятать ячейку        
                    MatrText[i, j].Visible = false;
                    // 3.6. Добавить MatrText[i,j] в форму form2        
                    form3.Controls.Add(MatrText[i, j]);
                }
        }

        /// <summary>
        /// Обработчик события потери фокуса текстового поля для ввода размерности матрицы.
        /// Проверяет введённое значение и обновляет состояние флагов.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn > 4)
            {
                MessageBox.Show("матрица не больше 4x4");
                textBox1.Focus();
            }
            if (nn != n)
            {
                f1 = false;
                label2.Text = "false";
            }
        }
    }
}

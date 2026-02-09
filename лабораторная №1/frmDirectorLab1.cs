using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    /// <summary>
    /// Основная форма для работы с матрицами и вывода "Hello World!".
    /// </summary>
    public partial class frmDirectorLab1 : Form
    {
        const int MaxN = 10;// максимально допустимая размерность матрицы
        int n = 3;// текущая размерность матрицы
        TextBox[,] MatrText = null;// матрица элементов типа TextBox 
        double[,] Matr1 = new double[MaxN, MaxN]; // матрица 1 чисел с плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxN]; // матрица 2 чисел с плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxN]; // матрица результатов
        double[,] Matr4 = new double[MaxN, MaxN]; // транспонированная матрица
        bool f1; // флажок, который указывает о вводе данных в матрицу Matr1
        bool f2;// флажок, который указывает о вводе данных в матрицу Matr2
        bool f4;// флажок, который указывает о вводе данных в матрицу Matr4
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]
        frmOK form3 = null;   // экземпляр (объект) класса формы Form3

        /// <summary>
        /// Конструктор для формы HelloAndMatrix.
        /// Инициализирует компоненты формы.
        /// </summary>
        public frmDirectorLab1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для вывода "Hello World!".
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnClickThis_Click(object sender, EventArgs e)
        {
            lblHelloWorld.Text = "Hello World!";
            MessageBox.Show("Hello World!");
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для открытия формы Form2.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmHelloWorld f = new frmHelloWorld();
            if (f.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Result = OK!";
            }

            else

            {
                label1.Text = "Result = Cancel!";
            }
        }

        /// <summary>
        /// Обработчик события загрузки формы HelloAndMatrix.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void HelloAndMatrix_Load(object sender, EventArgs e)
        {
            // Инициализация элементов управления и внутренних переменных
            textBox1.Text = "";
            f1 = f2 = false; // матрицы еще не заполнены
            label3.Text = "false";
            label4.Text = "false";

            // Выделение памяти и настройка MatrText
            int i, j;

            // Выделение памяти для формы Form2
            form3 = new frmOK();

            // Выделение памяти под самую матрицу
            MatrText = new TextBox[MaxN, MaxN];

            // Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < MaxN; i++)
            {
                for (j = 0; j < MaxN; j++)
                {
                    // Выделить память
                    MatrText[i, j] = new TextBox();

                    // Обнулить эту ячейку
                    MatrText[i, j].Text = "0";

                    // Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);

                    // Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);

                    // Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;

                    // Добавить MatrText[i,j] в форму form2
                    form3.Controls.Add(MatrText[i, j]);
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для отображения матрицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void PrintMatrix1_Click(object sender, EventArgs e)
        {
            // Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // Обнуление ячейки MatrText
            Clear_MatrText();

            // Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // Корректировка размеров формы
            form3.Width = 10 + n * dx + 20;
            form3.Height = 10 + n * dy + form3.button1.Height + 50;

            // Корректировка позиции и размеров кнопки на форме Form3
            form3.button1.Left = 10;
            form3.button1.Top = 10 + n * dy + 10;
            form3.button1.Width = form3.Width - 30;

            // Вызов формы Form2
            if (form3.ShowDialog() == DialogResult.OK)
            {
                // Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // Данные в матрицу Matr1 внесены
                f1 = true;
                label3.Text = "true";
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для отображения матрицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void PrintMatrix2_Click(object sender, EventArgs e)
        {
            // Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // Обнулить ячейки MatrText
            Clear_MatrText();

            // Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // Корректировка размеров формы
            form3.Width = 10 + n * dx + 20;
            form3.Height = 10 + n * dy + form3.button1.Height + 50;

            // Корректировка позиции и размеров кнопки на форме Form3
            form3.button1.Left = 10;
            form3.button1.Top = 10 + n * dy + 10;
            form3.button1.Width = form3.Width - 30;

            // Вызов формы Form3
            if (form3.ShowDialog() == DialogResult.OK)
            {
                // Перенос строк из формы Form2 в матрицу Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);

                // Матрица Matr2 сформирована
                f2 = true;
                label4.Text = "true";
            }
        }

        /// <summary>
        /// Очищает все ячейки матрицы MatrText.
        /// </summary>
        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для умножения матриц и отображения результата.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void MatrixMultiplicate_Click(object sender, EventArgs e)
        {
            // Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;

            // Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                }

            // Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            // вывод формы
            form3.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для сохранения значений итоговой матрицы в файл
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void SaveFile_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив

            // Открыть файл для записи
            fw = new FileStream("Res_Matr.txt", FileMode.Create);

            // Запись матрицы результата в файл
            // Сначала записать число элементов матрицы Matr3
            msg = n.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);

            // Теперь записать саму матрицу
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < n; j++)
                    msg = msg + Matr3[i, j].ToString() + "  ";
                msg = msg + "\r\n"; // добавить перевод строки
            }

            // Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // запись строк матрицы в файл
            fw.Write(msgByte, 0, msgByte.Length);

            // Закрыть файл
            if (fw != null) fw.Close();
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для сложения матриц и отображения результата.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void AddMatrix_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true))) return;

            // Сложение матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                     Matr3[j, i] = Matr1[j, i] + Matr2[j, i];
                }
            // Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            // Вывод формы
            form3.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для вычитания матриц и отображения результата.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void SubtractionMatrix_Click(object sender, EventArgs e)
        {
            if (!((f1 == true) && (f2 == true))) return;

            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = Matr1[j, i] - Matr2[j, i];
                }
            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                   
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            
            form3.ShowDialog();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для отображения матрицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void PrintMatrix3_Click(object sender, EventArgs e)
        {
            //Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            //Обнулить ячейки MatrText
            Clear_MatrText();

            // Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    //Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    //Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // Корректировка размеров формы
            form3.Width = 10 + n * dx + 20;
            form3.Height = 10 + n * dy + form3.button1.Height + 50;

            // Корректировка позиции и размеров кнопки на форме Form3
            form3.button1.Left = 10;
            form3.button1.Top = 10 + n * dy + 10;
            form3.button1.Width = form3.Width - 30;

            // Вызов формы Form3
            if (form3.ShowDialog() == DialogResult.OK)
            {
                // Перенос строк из формы Form2 в матрицу Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr4[i, j] = Double.Parse(MatrText[i, j].Text);

                // Матрица Matr2 сформирована
                f4 = true;
                label5.Text = "true";
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки для транспонирования матрицы и отображения результата.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void TranspositionMatrix_Click(object sender, EventArgs e)
        {
            if (!(f4 == true)) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    MatrText[i, j].Text = Matr4[j, i].ToString();
                }

            form3.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает событие потери фокуса текстового поля для ввода размерности матрицы.
        /// Проверяет введенное значение на допустимый диапазон и устанавливает флаги состояния.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void textBox1_Leave(object sender, EventArgs e)
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
                f1 = f2 = false;
                label3.Text = "false";
                label4.Text = "false";
            }
        }
    }
}

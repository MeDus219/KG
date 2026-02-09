using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_laba3
{
    /// <summary>
    /// Главная форма приложения для демонстрации графических преобразований
    /// </summary>
    public partial class frmBaseLab3 : Form
    {
        /// <summary>Текущий цвет осей</summary>
        Color currentColor1;

        /// <summary>Текущий цвет квадрата</summary>
        Color currentColor2;

        /// <summary>Текущий цвет фигуры</summary>
        Color currentColor3;

        /// <summary>Диалог выбора цвета</summary>
        private ColorDialog colorDialog1;

        /// <summary>Переменная для направления движения фигуры</summary>
        private int moveDirection = 0;

        /// <summary>переменная для изменения кнопки старт</summary>
        bool f;

        /// <summary>элементы матрицы сдвига</summary>
        int k, l;

        /// <summary>матрица тела</summary>
        int[,] kv = new int[4, 3];

        /// <summary>матрица координат осей</summary>
        int[,] osi = new int[4, 3];

        /// <summary>матрица преобразования (целочисленная)</summary>
        int[,] matr_sdv = new int[3, 3];

        /// <summary>матрица преобразования (вещественная)</summary>
        float[,] Matr_sdv = new float[3, 3];

        /// <summary>матрица тела (вариант 10)</summary>
        int[,] pentagon = new int[5, 3];

        /// <summary>Масштаб по X</summary>
        float scaleX = 1.0f;

        /// <summary>Масштаб по Y</summary>
        float scaleY = 1.0f;

        /// <summary>Угол поворота (в градусах)</summary>
        float angle = 0.0f;

        /// <summary>Отражение по X</summary>
        bool reflectX = false;

        /// <summary>Отражение по Y</summary>
        bool reflectY = false;

        /// <summary>переменная для пятиугольника</summary>
        private bool Pentagon = false;

        /// <summary>элементы матрицы сдвига (координаты центра осей)</summary>
        int osi_k, osi_l;

        /// <summary>Длина штриха пунктирной линии</summary>
        private int dashLength = 5;

        /// <summary>Толщина линий осей</summary>
        private int axisThickness = 1;

        /// <summary>Толщина линий квадрата</summary>
        private int squareThickness = 1;

        /// <summary>Толщина линий пятиугольника</summary>
        private int pentagonThickness = 1;

        /// <summary>Флаг пунктирного стиля для осей</summary>
        private bool axisDashed = false;

        /// <summary>Флаг пунктирного стиля для квадрата</summary>
        private bool squareDashed = false;

        /// <summary>Флаг пунктирного стиля для пятиугольника</summary>
        private bool pentagonDashed = false;

        /// <summary>
        /// Инициализирует матрицу преобразований для осей
        /// </summary>
        /// <param name="k1">Смещение по X</param>
        /// <param name="l1">Смещение по Y</param>
        private void Init_matr_preob_osi(int k1, int l1)
        {
            // Создаем новую матрицу преобразования
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса Form1
        /// </summary>
        public frmBaseLab3()
        {
            InitializeComponent();
            InitializeComponents();
        }

        /// <summary>
        /// Инициализирует компоненты формы и настройки по умолчанию
        /// </summary>
        private void InitializeComponents()
        {
            // Инициализация NumericUpDown элементов
            numericUpDown1.Value = dashLength;
            numericUpDown2.Value = axisThickness;
            numericUpDown3.Value = squareThickness;
            numericUpDown4.Value = pentagonThickness;

            // Подписка на события
            numericUpDown1.ValueChanged += (s, e) => { dashLength = (int)numericUpDown1.Value; Redraw(); };
            numericUpDown2.ValueChanged += (s, e) => { axisThickness = (int)numericUpDown2.Value; Redraw(); };
            numericUpDown3.ValueChanged += (s, e) => { squareThickness = (int)numericUpDown3.Value; Redraw(); };
            numericUpDown4.ValueChanged += (s, e) => { pentagonThickness = (int)numericUpDown4.Value; Redraw(); };

            checkBox7.CheckedChanged += (s, e) => { axisDashed = checkBox7.Checked; Redraw(); };
            checkBox8.CheckedChanged += (s, e) => { squareDashed = checkBox8.Checked; Redraw(); };
            checkBox9.CheckedChanged += (s, e) => { pentagonDashed = checkBox9.Checked; Redraw(); };
        }

        /// <summary>
        /// Создает перо с заданными параметрами
        /// </summary>
        /// <param name="color">Цвет пера</param>
        /// <param name="thickness">Толщина линии</param>
        /// <param name="dashed">Флаг пунктирного стиля</param>
        /// <returns>Объект Pen с заданными параметрами</returns>
        private Pen CreatePen(Color color, int thickness, bool dashed)
        {
            Pen pen = new Pen(color, thickness);
            if (dashed)
            {
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { dashLength, dashLength };
            }
            return pen;
        }


        /// <summary>
        /// Инициализирует матрицу пятиугольника
        /// </summary>
        private void Init_pentagon()
        {
            // точка A
            pentagon[0, 0] = -40; pentagon[0, 1] = -50; pentagon[0, 2] = 1;
            // точка B
            pentagon[1, 0] = 50; pentagon[1, 1] = -20; pentagon[1, 2] = 1;
            // точка C
            pentagon[2, 0] = -10; pentagon[2, 1] = 55; pentagon[2, 2] = 1;
            // точка D
            pentagon[3, 0] = -10; pentagon[3, 1] = 15; pentagon[3, 2] = 1;
            // точка E
            pentagon[4, 0] = -50; pentagon[4, 1] = 50; pentagon[4, 2] = 1;  
        }

        /// <summary>
        /// Инициализирует матрицу квадрата
        /// </summary>
        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
        }

        /// <summary>
        /// Инициализирует матрицу преобразований
        /// </summary>
        /// <param name="k1">Смещение по X</param>
        /// <param name="l1">Смещение по Y</param>
        private void Init_matr_preob(int k1, int l1)
        {
            float rad = angle * (float)Math.PI / 180;

            // Сбрасываем матрицу перед каждым преобразованием
            Array.Clear(Matr_sdv, 0, Matr_sdv.Length);

            // Единичная матрица
            Matr_sdv[0, 0] = 1;
            Matr_sdv[1, 1] = 1;
            Matr_sdv[2, 2] = 1;

            // Применяем преобразования в правильном порядке: 
            // 1. Масштаб и отражение
            // 2. Поворот
            // 3. Сдвиг

            // Масштаб и отражение
            Matr_sdv[0, 0] = scaleX * (reflectX ? -1 : 1);
            Matr_sdv[1, 1] = scaleY * (reflectY ? -1 : 1);

            // Поворот
            float cos = (float)Math.Cos(rad);
            float sin = (float)Math.Sin(rad);
            float[,] rotate = 
            {
                { cos, sin, 0 },
                { -sin, cos, 0 },
                { 0, 0, 1 }
            };
            // Умножаем текущую матрицу на поворот
            MultiplyWith(rotate); 

            // Сдвиг
            Matr_sdv[2, 0] += k1;
            Matr_sdv[2, 1] += l1;
        }

        /// <summary>
        /// Умножает текущую матрицу преобразований на другую матрицу
        /// </summary>
        /// <param name="other">Матрица для умножения</param>
        private void MultiplyWith(float[,] other)
        {
            float[,] temp = new float[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    temp[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        temp[i, j] += Matr_sdv[i, k] * other[k, j];
                    }
                }
            }
            // Копируем результат обратно
            Buffer.BlockCopy(temp, 0, Matr_sdv, 0, sizeof(float) * 9);
        }

        /// <summary>
        /// Инициализирует матрицу осей координат
        /// </summary>
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;

        }

        /// <summary>
        /// Умножает две матрицы
        /// </summary>
        /// <param name="a">Первая матрица</param>
        /// <param name="b">Вторая матрица</param>
        /// <returns>Результат умножения матриц</returns>
        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int[,] r = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        private void btnDrawShape_Click(object sender, EventArgs e)
        {
            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            
            //вывод квадратика в середине
            Draw_Kv();
        }

        /// <summary>
        /// Отрисовывает пятиугольник
        /// </summary>
        private void Draw_pentagon()
        {
            pictureBox1.Refresh();
            //рисуем оси под фигурой
            osi_k = pictureBox1.Width / 2;
            osi_l = pictureBox1.Height / 2;
            Draw_osi();
            Init_pentagon();
            Init_matr_preob(k, l);

            float[,] pentagon1 = new float[5, 3];
            for (int i = 0; i < 5; i++)
            {
                pentagon1[i, 0] = pentagon[i, 0] * Matr_sdv[0, 0] + pentagon[i, 1] * Matr_sdv[1, 0] + Matr_sdv[2, 0];
                pentagon1[i, 1] = pentagon[i, 0] * Matr_sdv[0, 1] + pentagon[i, 1] * Matr_sdv[1, 1] + Matr_sdv[2, 1];
            }

            using (Pen p = CreatePen(currentColor3, pentagonThickness, pentagonDashed))
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                for (int i = 0; i < 5; i++)
                {
                    int next = (i + 1) % 5;
                    g.DrawLine(p, pentagon1[i, 0], pentagon1[i, 1], pentagon1[next, 0], pentagon1[next, 1]);
                }
            }
        }

        /// <summary>
        /// Отрисовывает квадрат
        /// </summary>
        private void Draw_Kv()
        {
            //создаем новый объект Graphics (поверхность рисования) из pictureBox
            //Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //очистка pictureBox перед рисованием
            pictureBox1.Refresh();
            //рисуем оси под фигурой
            osi_k = pictureBox1.Width / 2;
            osi_l = pictureBox1.Height / 2;
            Draw_osi();
            Init_kvadrat();
            Init_matr_preob_osi(k, l);
            int[,] kv1 = Multiply_matr(kv, matr_sdv);

            using (Pen myPen = CreatePen(currentColor2, squareThickness, squareDashed))
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                for (int i = 0; i < 4; i++)
                {
                    int next = (i + 1) % 4;
                    g.DrawLine(myPen, kv1[i, 0], kv1[i, 1], kv1[next, 0], kv1[next, 1]);
                }
            }
        }

        private void btnDrawAxes_Click(object sender, EventArgs e)
        {
            osi_k = pictureBox1.Width / 2;
            osi_l = pictureBox1.Height / 2;
            Draw_osi();
        }

        private void btnCLean_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            timer1.Interval = 130;

            button8.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "Старт";
            }
            f = !f;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Pentagon) Draw_pentagon(); else Draw_Kv();

            // Изменяем координаты в зависимости от направления
            switch (moveDirection)
            {
                // вправо (button4)
                case 1:
                    k += 5;
                    break;
                // влево (button5)
                case 2:
                    k -= 5;
                    break;
                // вниз (button6)
                case 3:
                    l += 5;
                    break;
                // вверх (button7)
                case 4:
                    l -= 5;
                    break;
            }

            if (Turn.Checked == true)
            {
                angle += 15;
                Redraw();
            }

            if (checkBox2.Checked == true)
            {
                reflectX = !reflectX;
                Redraw();
            }

            if (checkBox3.Checked == true)
            {
                reflectY = !reflectY;
                Redraw();
            }

            if (Up.Checked == true)
            {
                scaleX += 0.1f; scaleY += 0.1f;
                Redraw();
            }

            if (Down.Checked == true)
            {
                scaleX -= 0.1f; scaleY -= 0.1f;
                Redraw();
            }

            Thread.Sleep(80);
        }

        private void btnShiftRight_Click(object sender, EventArgs e)
        {
            //изменение соответствующего элемента матрицы сдвига
            k += 5;
            moveDirection = 1;
            if (Pentagon) Draw_pentagon(); else Draw_Kv();
        }

        private void btnShiftLeft_Click(object sender, EventArgs e)
        {
            k -= 5;
            if (Pentagon) Draw_pentagon(); else Draw_Kv();
            moveDirection = 2;
        }

        private void btnShiftDown_Click(object sender, EventArgs e)
        {
            l += 5;
            if (Pentagon) Draw_pentagon(); else Draw_Kv();
            moveDirection = 3;
        }

        private void btnShiftUp_Click(object sender, EventArgs e)
        {
            l -= 5;
            if (Pentagon) Draw_pentagon(); else Draw_Kv();
            moveDirection = 4;
        }

        private void btnColorOsi_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentColor1 = colorDialog2.Color;               
            }
        }

        private void btnColorKv_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentColor2 = colorDialog2.Color;             
            }
        }

        private void btnColorPent_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentColor3 = colorDialog2.Color;
            }
        }

        private void btnDrawVar10_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_pentagon();
        }

        /// <summary>
        /// Перерисовывает текущую фигуру
        /// </summary>
        private void Redraw()
        {
            pictureBox1.Image = null;
            if (Pentagon)
            {
                Draw_osi();
                Draw_pentagon();
            }
            else
            {
                Draw_osi();
                Draw_Kv();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            scaleX += 0.1f; scaleY += 0.1f;
            Redraw();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            scaleX -= 0.1f; scaleY -= 0.1f;
            Redraw();
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {
            angle += 15;
            Redraw();
        }

        private void btnReflectionX_Click(object sender, EventArgs e)
        {
            reflectX = !reflectX; Redraw();
        }

        private void btnReflectionY_Click(object sender, EventArgs e)
        {
            reflectY = !reflectY; Redraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Pentagon = checkBox1.Checked;
            // Сброс позиции при переключении
            k = pictureBox1.Width / 2; 
            l = pictureBox1.Height / 2;
            Redraw();
        }

        /// <summary>
        /// Отрисовывает оси координат
        /// </summary>
        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob_osi(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int[,] osi1 = Multiply_matr(osi, matr_sdv);

            using (Pen myPen = CreatePen(currentColor1, axisThickness, axisDashed))
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);
                g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);
            }
        }
    }
}
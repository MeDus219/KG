using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HelloWorld.лабораторная__2
{
    public partial class frmWriterLab2 : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр формы
        /// </summary>
        public frmWriterLab2()
        {
            InitializeComponent();
        }
        /// <summary>Начальная и конечная точки отрезка</summary>
        public int xn, yn, xk, yk;

        /// <summary>Буфер для рисования</summary> 
        Bitmap myBitmap;

        /// <summary>Текущий цвет границы и заливки</summary>
        Color currentBorderColor;

        /// <summary>Диалог выбора цвета</summary>
        private ColorDialog colorDialog1;

        /// <summary>Флаг толстой линии</summary>
        public bool Bigline;

        /// <summary>Цвет заливки</summary>
        private Color fillColor;

        /// <summary>Ширина bitmap</summary>
        private int bitmapWidth;

        /// <summary>Высота bitmap</summary>
        private int bitmapHeight;


        /// <summary>
        /// Обработчик события отпускания кнопки мыши
        /// </summary>
        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            //numberNodes – переменная, задающая количество узлов для
            //аппроксимации отрезка
            //xOutput – x-координата очередного узла
            //yOutput – y-координата очередного узла
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;
            //Объявляем объект "myPen", задающий цвет и толщину пера
            Pen myPen = new Pen(currentBorderColor, 1);

            if (Bigline)
            {
                myPen = new Pen(currentBorderColor, 3);
            }
            else
            {
                myPen = new Pen(currentBorderColor, 1);
            }
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //реализация обычного алгоритма ЦДА
            xk = e.X;
            yk = e.Y;
            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;
            for (index = 1; index <= numberNodes; index++)
            {
                //Рисуем прямоугольник
                g.DrawRectangle(myPen, (int)xOutput, (int)yOutput, 2, 2);
                //Рисуем закрашенный прямоугольник:
                //Объявляем объект "redBrush", задающий цвет кисти
                //SolidBrush redBrush = new SolidBrush(currentBorderColor);
                //Рисуем закрашенный прямоугольник
                //g.FillRectangle(redBrush, (int)xOutput, (int)yOutput, 2, 2);
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки очистки
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        /// <summary>
        /// Обработчик выбора цвета границы
        /// </summary>
        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && radioButton1.Checked)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Основная функция рисования/заливки
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            //отключаем кнопки
            button1.Enabled = button2.Enabled = false;
            //создаем новый экземпляр Bitmap размером с элемент
            //pictureBox1 (myBitmap)
            //на нем выводим попиксельно отрезок
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmapWidth = myBitmap.Width;
            bitmapHeight = myBitmap.Height;
            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    //рисуем прямоугольник
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);

                    //рисуем треугольник
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);
                }
                else if (radioButton2.Checked == true)
                {
                    myBitmap = pictureBox1.Image as Bitmap;
                    xn = 160;
                    yn = 40;

                    // Вызываем рекурсивную процедуру заливки с затравкой
                    FloodFill(xn, yn);
                }
                else if (radioButton3.Checked == true)
                {
                    myBitmap = pictureBox1.Image as Bitmap;
                    xn = 50;
                    yn = 50;

                    // Вызываем итеративную процедуру заливки с затравкой
                    IterativeFloodFill(xn, yn);
                }
                //передаем полученный растр mybitmap в элемент pictureBox
                pictureBox1.Image = myBitmap;
                // обновляем pictureBox и активируем кнопки
                pictureBox1.Refresh();
                button1.Enabled = button2.Enabled = true;
            }
        }

        /// <summary>
        /// Обработчик изменения состояния чекбокса толщины линии
        /// </summary>
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Bigline = checkBox1.Checked;
        }

        /// <summary>
        /// Обработчик выбора цвета заливки
        /// </summary>
        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fillColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки мыши на pictureBox
        /// </summary>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }

            else MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
        }

        /// <summary>
        /// Рисует линию методом ЦДА
        /// </summary>
        /// <param name="xStart">Начальная X-координата</param>
        /// <param name="yStart">Начальная Y-координата</param>
        /// <param name="xEnd">Конечная X-координата</param>
        /// <param name="yEnd">Конечная Y-координата</param>
        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            xn = xStart;
            yn = yStart;
            xk = xEnd;
            yk = yEnd;
            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;
            for (index = 1; index <= numberNodes; index++)
            {
                myBitmap.SetPixel((int)xOutput, (int)yOutput,
               currentBorderColor);
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }

        /// <summary>
        /// Рекурсивная заливка области
        /// </summary>
        /// <param name="x1">X-координата начальной точки</param>
        /// <param name="y1">Y-координата начальной точки</param>
        private void FloodFill(int x1, int y1)
        {
            // получаем цвет текущего пикселя с координатами x1, y1
            Color oldPixelColor = myBitmap.GetPixel(x1, y1);
            // сравнение цветов происходит в формате RGB
            // для этого используем метод ToArgb объекта Color
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb()) && (oldPixelColor.ToArgb() != fillColor.ToArgb()))
            {
                //перекрашиваем пиксель
                myBitmap.SetPixel(x1, y1, fillColor);

                FloodFill(x1 + 1, y1);
                FloodFill(x1 - 1, y1);
                FloodFill(x1, y1 + 1);
                FloodFill(x1, y1 - 1);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Итеративная заливка области с использованием стека
        /// </summary>
        /// <param name="startX">X-координата начальной точки</param>
        /// <param name="startY">Y-координата начальной точки</param>
        private void IterativeFloodFill(int startX, int startY)
        {
            // Проверяем, что начальная точка внутри изображения
            if (startX < 0 || startX >= myBitmap.Width || startY < 0 || startY >= myBitmap.Height)
                return;

            // Получаем цвет границы и цвет заливки
            Color borderColor = currentBorderColor;
            Color targetColor = fillColor;

            // Получаем цвет начального пикселя
            Color startColor = myBitmap.GetPixel(startX, startY);

            // Если начальный пиксель уже граница или залит, выходим
            if (startColor.ToArgb() == borderColor.ToArgb() ||
                startColor.ToArgb() == targetColor.ToArgb())
            {
                return;
            }

            // Создаем стек для хранения точек
            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(startX, startY));

            int maxIterations = myBitmap.Width * myBitmap.Height * 2;
            int iterations = 0;

            while (pixels.Count > 0 && iterations < maxIterations)
            {
                iterations++;
                Point current = pixels.Pop();
                int x = current.X;
                int y = current.Y;

                // Проверяем границы изображения
                if (x <= 0 || x >= bitmapWidth - 1 || y <= 0 || y >= bitmapHeight - 1)
                    continue;

                // Получаем цвет текущего пикселя
                Color currentColor = myBitmap.GetPixel(x, y);

                // Если пиксель не граница и еще не залит
                if (currentColor.ToArgb() == startColor.ToArgb() &&
                    currentColor.ToArgb() != targetColor.ToArgb())
                {
                    // Заливаем текущий пиксель
                    myBitmap.SetPixel(x, y, targetColor);

                    // Добавляем соседние пиксели в стек
                    pixels.Push(new Point(x + 1, y));
                    pixels.Push(new Point(x - 1, y));
                    pixels.Push(new Point(x, y + 1));
                    pixels.Push(new Point(x, y - 1));
                }
            }
        }
    }
}

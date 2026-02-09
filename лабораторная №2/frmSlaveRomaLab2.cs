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
    public partial class frmSlaveRomaLab2 : Form
    {
        // Глобальные переменные
        bool CheckLine;

        // Список отрезков (каждый отрезок - массив из двух точек)
        List<Point[]> lines = new List<Point[]>();

        // Отсекающее окно
        Rectangle clipWindow;

        // Флаг установки окна
        bool isSettingClipWindow = false;

        // Флаг установки отрезков
        bool isSettingLines = false;

        // Координаты отрезков
        int xn, yn, xk, yk;

        // Объект Bitmap для вывода отрезка
        Bitmap myBitmap;

        // Текущий цвет отрезка, текущий цвет заливким и цвет для отсеченных частей
        Color currentBorderColor = Color.Red;
        Color currentColor = Color.Black;
        Color clippedColor = Color.Blue;

        // Коды областей для алгоритма Коэна-Сазерленда
        const int INSIDE = 0;
        const int LEFT = 1;
        const int RIGHT = 2;
        const int BOTTOM = 4;
        const int TOP = 8;

        public frmSlaveRomaLab2()
        {
            InitializeComponent();
        }

        // Функция вычисления кода точки для алгоритма Коэна-Сазерленда
        int ComputeCode(Rectangle rect, Point p)
        {
            int code = INSIDE;

            if (p.X < rect.Left)
                code |= LEFT;
            else if (p.X > rect.Right)
                code |= RIGHT;
            if (p.Y < rect.Top)
                code |= TOP;
            else if (p.Y > rect.Bottom)
                code |= BOTTOM;

            return code;
        }

        // Алгоритм отсечения Коэна-Сазерленда
        bool CohenSutherlandClip(ref Rectangle rect, ref Point p1, ref Point p2)
        {
            int code1 = ComputeCode(rect, p1);
            int code2 = ComputeCode(rect, p2);
            bool accept = false;

            while (true)
            {
                if ((code1 == 0) && (code2 == 0))
                {
                    // Оба конца внутри - принимаем отрезок
                    accept = true;
                    break;
                }
                else if ((code1 & code2) != 0)
                {
                    // Оба конца с одной стороны окна - отвергаем
                    break;
                }
                else
                {
                    // Отрезок нуждается в отсечении
                    int codeOut = code1 != 0 ? code1 : code2;
                    Point p = new Point();

                    // Находим точку пересечения
                    if ((codeOut & TOP) != 0)
                    {
                        p.X = p1.X + (p2.X - p1.X) * (rect.Top - p1.Y) / (p2.Y - p1.Y);
                        p.Y = rect.Top;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        p.X = p1.X + (p2.X - p1.X) * (rect.Bottom - p1.Y) / (p2.Y - p1.Y);
                        p.Y = rect.Bottom;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        p.Y = p1.Y + (p2.Y - p1.Y) * (rect.Right - p1.X) / (p2.X - p1.X);
                        p.X = rect.Right;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        p.Y = p1.Y + (p2.Y - p1.Y) * (rect.Left - p1.X) / (p2.X - p1.X);
                        p.X = rect.Left;
                    }

                    // Заменяем точку вне окна точкой пересечения
                    if (codeOut == code1)
                    {
                        p1 = p;
                        code1 = ComputeCode(rect, p1);
                    }
                    else
                    {
                        p2 = p;
                        code2 = ComputeCode(rect, p2);
                    }
                }
            }
            return accept;
        }

        // Алгоритм ЦДА для рисования отрезка
        void CDA(int xStart, int yStart, int xEnd, int yEnd, Color color)
        {
            int index, numberNodes = 200;
            double xOutput = xStart, yOutput = yStart;
            double dx = xEnd - xStart, dy = yEnd - yStart;

            for (index = 1; index <= numberNodes; index++)
            {
                myBitmap.SetPixel((int)xOutput, (int)yOutput, color);
                xOutput += dx / numberNodes;
                yOutput += dy / numberNodes;
            }
        }

        // Функция заливки с застравкой (рекурсивная)
        void FloodFill(int x, int y)
        {
            // Получаем цвет текущего пикселя с координатами x1, y1
            Color oldPixelColor = myBitmap.GetPixel(x, y);

            // Сравнение цветов происходит в формате RGB
            // Для этого используем метод ToArgb объекта Color
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb()) &&
                (oldPixelColor.ToArgb() != currentColor.ToArgb()))
            {
                // Перекрашиваем пиксель
                myBitmap.SetPixel(x, y, currentColor);

                // Вызываем метод для 4-х соседних пикселей
                FloodFill(x + 1, y);
                FloodFill(x - 1, y);
                FloodFill(x, y + 1);
                FloodFill(x, y - 1);
            }
            else
            {
                //выходим из метода
                return;
            }
        }

        // Обработчики событий
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                xn = e.X;
                yn = e.Y;
            }
            else if (radioButton2.Checked)
            {
                xn = e.X;
                yn = e.Y;
                MessageBox.Show($"Координаты: X = {xn}, Y = {yn}");
                myBitmap = pictureBox1.Image as Bitmap;
                pictureBox1.Image = myBitmap;
                FloodFill(xn, yn);
            }
            else if (radioButton3.Checked && isSettingClipWindow)
            {
                // Установка первого угла отсекающего окна
                clipWindow.X = e.X;
                clipWindow.Y = e.Y;
                clipWindow.Width = 0;
                clipWindow.Height = 0;
            }
            else if (radioButton4.Checked && isSettingLines)
            {
                // Начало нового отрезка
                xn = e.X;
                yn = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                Pen myPen = new Pen(currentBorderColor, checkBox1.Checked ? 2 : 1);
                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                xk = e.X;
                yk = e.Y;
                g.DrawLine(myPen, xn, yn, xk, yk);
            }
            else if (radioButton3.Checked && isSettingClipWindow)
            {
                // Установка второго угла отсекающего окна
                clipWindow.Width = e.X - clipWindow.X;
                clipWindow.Height = e.Y - clipWindow.Y;

                // Нормализуем прямоугольник (если width или height отрицательные)
                if (clipWindow.Width < 0)
                {
                    clipWindow.X += clipWindow.Width;
                    clipWindow.Width = -clipWindow.Width;
                }
                if (clipWindow.Height < 0)
                {
                    clipWindow.Y += clipWindow.Height;
                    clipWindow.Height = -clipWindow.Height;
                }

                // Рисуем отсекающее окно
                myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(myBitmap))
                {
                    g.DrawRectangle(Pens.Black, clipWindow);
                }
                pictureBox1.Image = myBitmap;
            }
            else if (radioButton4.Checked && isSettingLines)
            {
                // Конец отрезка
                xk = e.X;
                yk = e.Y;

                // Добавляем отрезок в список
                lines.Add(new Point[] { new Point(xn, yn), new Point(xk, yk) });

                // Рисуем отрезок
                using (Graphics g = Graphics.FromImage(myBitmap))
                {
                    g.DrawLine(Pens.Black, xn, yn, xk, yk);
                }
                pictureBox1.Image = myBitmap;
            }
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка поля
            pictureBox1.Image = null;
            lines.Clear();
            isSettingClipWindow = false;
            isSettingLines = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Отключаем кнопки
            button1.Enabled = false;
            button2.Enabled = false;

            // Создаем новый экземпляр Bitmap размером с элемент
            // pictureBox1 (myBitmap)
            // На нем выводим попиксельно отрезок
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    // Рисуем прямоугольник
                    CDA(10, 10, 10, 110, currentBorderColor);
                    CDA(10, 10, 110, 10, currentBorderColor);
                    CDA(10, 110, 110, 110, currentBorderColor);
                    CDA(110, 10, 110, 110, currentBorderColor);

                    // Рисуем треугольник
                    CDA(150, 10, 150, 200, currentBorderColor);
                    CDA(250, 50, 150, 200, currentBorderColor);
                    CDA(150, 10, 250, 150, currentBorderColor);
                }
                else
                {
                    if (radioButton2.Checked == true)
                    {
                        // Получаем растр созданного рисунка в mybitmap
                        myBitmap = pictureBox1.Image as Bitmap;

                        // Задаем координаты затравки
                        xn = 160;
                        yn = 40;

                        // Вызываем рекурсивную процедуру заливки с затравкой
                        FloodFill(xn, yn);
                    }
                }
            }
            // Передаем полученный растр mybitmap в элемент pictureBox
            pictureBox1.Image = myBitmap;

            // Обновляем pictureBox и активируем кнопки
            pictureBox1.Refresh();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && radioButton1.Checked)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && radioButton2.Checked)
            {
                currentColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Кнопка "Установить отсекающее окно"
            isSettingClipWindow = true;
            isSettingLines = false;
            radioButton3.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Кнопка "Добавить отрезки"
            isSettingLines = true;
            isSettingClipWindow = false;
            radioButton4.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Кнопка "Выполнить отсечение"
            if (myBitmap == null) return;

            // Создаем копию оригинального изображения
            Bitmap originalBitmap = new Bitmap(myBitmap);

            // Рисуем отсекающее окно
            using (Graphics g = Graphics.FromImage(myBitmap))
            {
                g.DrawRectangle(Pens.Black, clipWindow);

                // Обрабатываем все отрезки
                foreach (var line in lines)
                {
                    Point p1 = line[0];
                    Point p2 = line[1];

                    // Применяем алгоритм отсечения
                    if (CohenSutherlandClip(ref clipWindow, ref p1, ref p2))
                    {
                        // Рисуем видимую часть отрезка
                        g.DrawLine(new Pen(currentBorderColor), p1, p2);

                        // Рисуем отсеченные части другим цветом
                        if (p1 != line[0])
                            g.DrawLine(new Pen(clippedColor), line[0], p1);
                        if (p2 != line[1])
                            g.DrawLine(new Pen(clippedColor), p2, line[1]);
                    }
                    else
                    {
                        // Отрезок полностью вне окна - рисуем его clippedColor
                        g.DrawLine(new Pen(clippedColor), line[0], line[1]);
                    }
                }
            }

            pictureBox1.Image = myBitmap;
            pictureBox1.Refresh();
        }
    }
}

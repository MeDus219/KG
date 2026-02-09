using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HelloWorld.лабораторная__2
{
    public partial class frmSlaveDimaLab2 : Form
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public frmSlaveDimaLab2()
        {
            InitializeComponent();
        }
 
        /// <summary>
        /// Обработчик события нажатия кнопки для рисования окружности.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем радиус из TextBox (не забудьте добавить TextBox на форму)
            if (int.TryParse(textBox1.Text, out int radius) && radius > 0) // Проверяем, что введенный радиус корректен и больше нуля
            {
                // Создаем Bitmap для pictureBox, чтобы рисовать на нем
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bmp)) // Создаем графический объект из Bitmap
                {
                    // Рисуем окружность алгоритмом Брезенхема
                    DrawCircle(g, pictureBox1.Width / 2, pictureBox1.Height / 2, radius); // Вызываем метод для рисования окружности
                }

                // Устанавливаем Bitmap в pictureBox для отображения
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("Введите корректный радиус."); // Сообщаем пользователю об ошибке ввода
            }
        }

        /// <summary>
        /// Рисует окружность по алгоритму Брезенхема.
        /// </summary>
        /// <param name="g">Графический объект для рисования.</param>
        /// <param name="xc">X-координата центра окружности.</param>
        /// <param name="yc">Y-координата центра окружности.</param>
        /// <param name="radius">Радиус окружности.</param>
        private void DrawCircle(Graphics g, int xc, int yc, int radius)
        {
            int x = 0; // Начальная X-координата точки на окружности
            int y = radius; // Начальная Y-координата точки на окружности (высота радиуса)
            int d = 3 - 2 * radius; // Начальное значение ошибки (d)

            // Рисуем начальные точки окружности
            DrawCirclePoints(g, xc, yc, x, y); // Рисуем симметричные точки

            while (y >= x) // Пока y больше или равно x
            {
                x++; // Увеличиваем x

                if (d > 0) // Если ошибка больше нуля
                {
                    y--; // Уменьшаем y (переход к следующему уровню вниз)
                    d = d + 4 * (x - y) + 10; // Обновляем значение ошибки
                }
                else // Если ошибка меньше или равна нулю
                {
                    d = d + 4 * x + 6; // Обновляем значение ошибки без изменения y
                }

                // Рисуем симметричные точки окружности
                DrawCirclePoints(g, xc, yc, x, y);
            }
        }

        /// <summary>
        /// Рисует симметричные точки окружности.
        /// </summary>
        /// <param name="g">Графический объект для рисования.</param>
        /// <param name="xc">X-координата центра окружности.</param>
        /// <param name="yc">Y-координата центра окружности.</param>
        /// <param name="x">X-координата точки на окружности.</param>
        /// <param name="y">Y-координата точки на окружности.</param>
        private void DrawCirclePoints(Graphics g, int xc, int yc, int x, int y)
        {
            // Устанавливаем цвет рисования (например, темно-красный)
            g.FillRectangle(Brushes.DarkRed, xc + x, yc + y, 1, 1); // Первая четверть
            g.FillRectangle(Brushes.DarkRed, xc - x, yc + y, 1, 1); // Вторая четверть
            g.FillRectangle(Brushes.DarkRed, xc + x, yc - y, 1, 1); // Третья четверть
            g.FillRectangle(Brushes.DarkRed, xc - x, yc - y, 1, 1); // Четвертая четверть
            g.FillRectangle(Brushes.DarkRed, xc + y, yc + x, 1, 1); // Первая четверть (симметрия по оси Y)
            g.FillRectangle(Brushes.DarkRed, xc - y, yc + x, 1, 1); // Вторая четверть (симметрия по оси Y)
            g.FillRectangle(Brushes.DarkRed, xc + y, yc - x, 1, 1); // Третья четверть (симметрия по оси Y)
            g.FillRectangle(Brushes.DarkRed, xc - y, yc - x, 1, 1); // Четвертая четверть (симметрия по оси Y)
        }
    }
}

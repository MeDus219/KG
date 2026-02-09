using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HelloWorld
{
    /// <summary>
    /// Главная форма приложения для демонстрации алгоритмов растеризации
    /// </summary>
    public partial class frmRastrAlgoritm : Form
    {
        /// <summary>
        /// Координата X начальной точки отрезка
        /// </summary>
        public int Xn;

        /// <summary>
        /// Координата Y начальной точки отрезка
        /// </summary>
        public int Yn;

        /// <summary>
        /// Координата X конечной точки отрезка
        /// </summary>
        public int Xk;

        /// <summary>
        /// Координата Y конечной точки отрезка
        /// </summary>
        public int Yk;

        /// <summary>
        /// Буфер для хранения растрового изображения
        /// </summary>
        private Bitmap myBitmap;

        /// <summary>
        /// Текущий цвет границы для рисования отрезков
        /// </summary>
        private Color currentBorderColor = Color.Black;

        /// <summary>
        /// Текущий цвет для заливки области
        /// </summary>
        private Color currentFillColor;

        /// <summary>
        /// Инициализирует новый экземпляр формы
        /// </summary>
        public frmRastrAlgoritm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Стиль линии (сплошная, пунктирная)
        /// </summary>
        private DashStyle lineStyle = DashStyle.Solid;

        /// <summary>
        /// Флаг, указывающий, нужно ли рисовать пунктирную линию
        /// </summary>
        private bool isDashed = false;

        /// <summary>
        /// Длина штриха пунктирной линии (в пикселях)
        /// </summary>
        private int dashLength = 5;

        /// <summary>
        /// Текущая толщина линии
        /// </summary>
        private int currentLineThickness = 1;
        
        /// <summary>
        /// Устанавливет длину пунктира
        private void numLengthLine_ValueChanged(object sender, EventArgs e)
        {
            dashLength = (int)numLengthLine.Value;
        }

        /// <summary>
        /// Устанавливет пунктир
        private void chkDashed_CheckedChanged(object sender, EventArgs e)
        {
            isDashed = chkDashed.Checked;
        }
        
        /// <summary>
        /// Устанавливет толщину линии
        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            currentLineThickness = (int)numThickness.Value;
        }

        /// <summary>
        /// Обрабатывает событие отпускания кнопки мыши на холсте
        /// </summary>
        /// <param name="sender">Объект PictureBox, представляющий холст</param>
        /// <param name="e">Данные о событии мыши</param>
        /// <remarks>
        /// При работе в режиме рисования отрезков выполняет растеризацию отрезка
        /// между точками нажатия и отпускания мыши
        /// </remarks>
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (rdoDrawCDA.Checked == true)
            {
                Pen myPen = new Pen(currentBorderColor, currentLineThickness);
                // Устанавливаем стиль линии (сплошная/пунктирная)
                // Если длина пунктира больше 0 - рисуем пунктир
                if (dashLength > 0) 
                {
                    myPen.DashStyle = DashStyle.Custom;
                    myPen.DashPattern = new float[] { dashLength, dashLength };
                }
                // Иначе - сплошная линия
                else
                {
                    myPen.DashStyle = DashStyle.Solid;
                }

                int index, numberNodes;
                double xOutput, yOutput, dx, dy;

                Graphics g = Graphics.FromHwnd(picCanvas.Handle);
                Xk = e.X;
                Yk = e.Y;
                dx = Xk - Xn;
                dy = Yk - Yn;
                numberNodes = 200;
                xOutput = Xn;
                yOutput = Yn;


                for (index = 1; index <= numberNodes; index++)
                {
                    g.DrawRectangle(myPen, (int)xOutput, (int)yOutput, 1, 1);
                    xOutput = xOutput + dx / numberNodes;
                    yOutput = yOutput + dy / numberNodes;
                }
            }
            else if (rdoDrawBresenham.Checked == true)
            {
                // Встроенный алгоритм Брезенхема
                // Вычисляем разницу координат
                Xk = e.X;
                Yk = e.Y;

                // Создает и получает растровое изображение
                if (myBitmap == null)
                {
                    myBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
                }

                // Метод рисует линию по координатам
                BresenhamLine(Xn, Yn, Xk, Yk);

                // Обновляет в Picture Box
                picCanvas.Image = myBitmap;
                picCanvas.Refresh();
            }
        }

        /// <summary>
        /// Рисует линии по алгоритму Брезенхема
        /// </summary>
        /// <param name="x0">X-координата начальной точки отрезка</param>
        /// <param name="y0">Y-координата начальной точки отрезка</param>
        /// <param name="x0">X-координата конечной точки отрезка</param>
        /// <param name="y0">Y-координата конечной точки отрезка</param>
        /// <remarks>
        /// При работе в режиме рисования отрезков выполняет растеризацию отрезка
        /// между точками нажатия и отпускания мыши
        /// </remarks>
        /// 

        private void BresenhamLine(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            int pixelCounter = 0;
            bool drawSegment = true;

            while (true)
            {
                if (!isDashed || drawSegment)
                {
                    // Отрисовка с учетом толщины линии
                    for (int i = -currentLineThickness / 2; i <= currentLineThickness / 2; i++)
                    {
                        for (int j = -currentLineThickness / 2; j <= currentLineThickness / 2; j++)
                        {
                            int px = x0 + i;
                            int py = y0 + j;

                            if (px >= 0 && px < myBitmap.Width && py >= 0 && py < myBitmap.Height)
                            {
                                myBitmap.SetPixel(px, py, currentBorderColor);
                            }
                        }
                    }
                }

                pixelCounter++;
                if (isDashed && pixelCounter >= dashLength)
                {
                    drawSegment = !drawSegment;
                    pixelCounter = 0;
                }

                if (x0 == x1 && y0 == y1)
                {
                    break;
                }
                int e2 = 2 * err;
                if (e2 > -dy) 
                { 
                    err -= dy; x0 += sx; 
                }
                if (e2 < dx) 
                { 
                    err += dx; y0 += sy; 
                }
            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки очистки холста
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(picCanvas.Height, picCanvas.Width);
            Color newPixelColor = Color.FromArgb(247, 249, 239);

            for (int x = 0; x < myBitmap.Width; x++)
            {
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    myBitmap.SetPixel(x, y, newPixelColor);
                }
            }
            picCanvas.Image = myBitmap;
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки мыши на холсте
        /// </summary>
        /// <param name="sender">Объект PictureBox, представляющий холст</param>
        /// <param name="e">Данные о событии мыши</param>
        /// <remarks>
        /// В зависимости от выбранного режима либо фиксирует начальную точку отрезка,
        /// либо начинает заливку области
        /// </remarks>
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (rdoDrawCDA.Checked == true)
            {
                Xn = e.X;
                Yn = e.Y;
            }
            else if (rdoFillingArea.Checked == true)
            {
                Xn = e.X;
                Yn = e.Y;
                MessageBox.Show($"Координаты: X = {Xn}, Y = {Yn}");

                myBitmap = picCanvas.Image as Bitmap;
                picCanvas.Image = myBitmap;
                FloodFill(Xn, Yn);
            }
            else if (rdoDrawBresenham.Checked)
            {
                Xn = e.X; // Запоминаем начальную точку
                Yn = e.Y;
            }
        }

        
        /// <summary>
        /// Реализует алгоритм Цифрового Дифференциального Анализатора для растеризации отрезка
        /// </summary>
        /// <param name="xStart">X-координата начальной точки отрезка</param>
        /// <param name="yStart">Y-координата начальной точки отрезка</param>
        /// <param name="xEnd">X-координата конечной точки отрезка</param>
        /// <param name="yEnd">Y-координата конечной точки отрезка</param>
        /// <remarks>
        /// Алгоритм разбивает отрезок на 200 равных частей и последовательно
        /// рисует точки, создавая видимость непрерывного отрезка
        /// </remarks>
        private void DrawCDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int numberNodes = 200;
            double x = xStart, y = yStart;
            double dx = (xEnd - xStart) / (double)numberNodes;
            double dy = (yEnd - yStart) / (double)numberNodes;

            int counter = 0;
            bool drawPixel = true;

            for (int i = 0; i <= numberNodes; i++)
            {
                if (drawPixel)
                {
                    myBitmap.SetPixel((int)x, (int)y, currentBorderColor);
                }

                counter++;
                if (isDashed && counter >= dashLength)
                {
                    drawPixel = !drawPixel;
                    counter = 0;
                }

                x += dx;
                y += dy;
            }
        }
        /// <summary>
        /// Устанавливает цвет заливки области через диалог выбора цвета
        /// </summary>
        /// <param name="sender">Кнопка выбора цвета заливки</param>
        /// <param name="e">Аргументы события</param>
        /// <exception cref="System.Exception">Может выбрасывать исключение при проблемах
        /// с диалогом выбора цвета</exception>
        private void btnColorFilling_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && rdoFillingArea.Checked)
            {
                currentFillColor = colorDialog1.Color;
            }
        }
        /// <summary>
        /// Устанавливает цвет границы отрезков через диалог выбора цвета
        /// </summary>
        /// <param name="sender">Кнопка выбора цвета границы</param>
        /// <param name="e">Аргументы события</param>
        /// <exception cref="System.Exception">Может выбрасывать исключение при проблемах
        /// с диалогом выбора цвета</exception>
        private void btnColorLine_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Выполняет построение тестовых фигур или заливку области
        /// </summary>
        /// <param name="sender">Кнопка выполнения операции</param>
        /// <param name="e">Аргументы события</param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            btnClearCanvas.Enabled = false;
            btnComplete.Enabled = false;

            myBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);

            using (Graphics g = Graphics.FromHwnd(picCanvas.Handle))
            {
                if (rdoDrawCDA.Checked == true)
                {
                    DrawCDA(10, 10, 10, 110);
                    DrawCDA(10, 10, 110, 10);
                    DrawCDA(10, 110, 110, 110);
                    DrawCDA(110, 10, 110, 110);

                    DrawCDA(150, 10, 150, 200);
                    DrawCDA(250, 50, 150, 200);
                    DrawCDA(150, 10, 250, 150);
                }
                else if (rdoFillingArea.Checked == true)
                {
                    myBitmap = picCanvas.Image as Bitmap;
                    Xn = 160;
                    Yn = 40;
                    FloodFill(Xn, Yn);
                }

                picCanvas.Image = myBitmap;
                picCanvas.Refresh();
                btnClearCanvas.Enabled = true;
                btnComplete.Enabled = true;
            }
        }

        /// <summary>
        /// Реализует алгоритм рекурсивной заливки области с затравкой
        /// </summary>
        /// <param name="x">X-координата начальной точки заливки</param>
        /// <param name="y">Y-координата начальной точки заливки</param>
        /// <remarks>
        /// Алгоритм проверяет цвет текущего пикселя и, если он отличается
        /// от цвета границы и заливки, закрашивает его и рекурсивно
        /// обрабатывает 4 соседних пикселя
        /// </remarks>
        /// <exception cref="System.StackOverflowException">Может возникнуть при заливке 
        /// очень больших областей</exception>
        private void FloodFill(int x, int y)
        {
            Color oldPixelColor = myBitmap.GetPixel(x, y);

            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb()) &&
                (oldPixelColor.ToArgb() != currentFillColor.ToArgb()))
            {
                myBitmap.SetPixel(x, y, currentFillColor);

                FloodFill(x + 1, y);
                FloodFill(x - 1, y);
                FloodFill(x, y + 1);
                FloodFill(x, y - 1);
            }
        }

        /// <summary>
        /// Рисует отрезок по алгоритму Брезенхема
        /// </summary>
        /// <param name="x0">Начальная X-координата</param>
        /// <param name="y0">Начальная Y-координата</param>
        /// <param name="x1">Конечная X-координата</param>
        /// <param name="y1">Конечная Y-координата</param>
        private void DrawBresenhamLine(int x0, int y0, int x1, int y1)
        {
            // Вычисляем разницу координат
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            // Определяем направление шага
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;

            // Инициализация ошибки
            int err = dx - dy;

            // Основной цикл
            while (true)
            {
                // Рисуем пиксель
                myBitmap.SetPixel(x0, y0, currentBorderColor);

                // Если достигли конечной точки — выходим
                if (x0 == x1 && y0 == y1) break;

                // Вычисляем удвоенную ошибку
                int e2 = 2 * err;

                // Корректируем координаты и ошибку
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KG_Laba3_Individual
{
    public partial class frmRomanLab3 : Form
    {
        // Глобальные переменные
        private int boatX = 100;
        private int boatY;
        private int seagullX;
        private int seagullY;
        
        // Добавляем переменную для расстояния
        private int seagullDistance = 0;
        
        // Максимальное расстояние удаления
        private const int MaxDistance = 500;

        // Цвета заката (для неба)
        private Color[] sunsetColors = {
            Color.FromArgb(255, 233, 150),
            Color.FromArgb(255, 192, 77),
            Color.FromArgb(255, 135, 5),
            Color.FromArgb(207, 86, 26),
            Color.FromArgb(163, 50, 40),
            Color.FromArgb(100, 30, 50)
        };

        // Цвета моря (градиент от светлого к темному)
        private Color[] seaColors = {
            Color.FromArgb(0, 150, 200),
            Color.FromArgb(0, 100, 150),
            Color.FromArgb(0, 60, 100)
        };

        /// <summary>
        /// Конструктор формы, инициализирует компоненты и начальные позиции объектов
        /// </summary>
        public frmRomanLab3()
        {
            InitializeComponent();

            // Инициализация компонентов
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox1.SizeChanged += PictureBox1_SizeChanged;

            timer1.Interval = 50;
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            // Инициализируем начальную позицию лодки
            UpdateBoatPosition();
            DrawScene();
        }

        /// <summary>
        /// Обработчик изменения размера PictureBox
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void PictureBox1_SizeChanged(object sender, EventArgs e)
        {
            UpdateBoatPosition();
            DrawScene();
        }

        /// <summary>
        /// Обновляет позицию лодки относительно нового размера PictureBox
        /// </summary>
        private void UpdateBoatPosition()
        {
            // Морская граница - 2/3 высоты окна
            int seaLevel = pictureBox1.Height * 2 / 3;

            // Позиция лодки: на 30 пикселей выше нижней границы моря
            boatY = seaLevel - 30;
        }

        /// <summary>
        /// Обработчик таймера, обновляет позиции объектов и перерисовывает сцену
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Движение лодки
            boatX += 2;
            if (boatX > pictureBox1.Width + 200)
                boatX = -200;

            // Движение чайки
            seagullDistance += 5;
            if (seagullDistance > MaxDistance)
            {
                seagullDistance = 0;
                seagullX = pictureBox1.Width / 2 + new Random().Next(-50, 50);
                seagullY = pictureBox1.Height / 3 + new Random().Next(-50, 50);
            }

            DrawScene();
        }

        /// <summary>
        /// Отрисовывает всю сцену (небо, море, лодку и чайку)
        /// </summary>
        private void DrawScene()
        {
            if (pictureBox1.Width == 0 || pictureBox1.Height == 0)
                return;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Рисуем небо с закатом (верхние 2/3)
                DrawSky(g);

                // Рисуем море (нижняя 1/3)
                DrawSea(g);

                // Рисуем лодку (на море)
                DrawBoat(g, boatX, boatY);

                // Рисуем чайку (в небе)
                DrawSeagull(g, pictureBox1.Width / 2, pictureBox1.Height / 3);
            }

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = bmp;
        }

        /// <summary>
        /// Рисует небо с градиентом заката
        /// </summary>
        /// <param name="g">Объект Graphics для рисования</param>
        private void DrawSky(Graphics g)
        {
            int skyHeight = pictureBox1.Height * 2 / 3;
            int segmentHeight = skyHeight / sunsetColors.Length;

            for (int i = 0; i < sunsetColors.Length; i++)
            {
                using (SolidBrush brush = new SolidBrush(sunsetColors[i]))
                {
                    int y = i * segmentHeight;
                    int height = (i == sunsetColors.Length - 1) ?
                        skyHeight - y : segmentHeight;

                    g.FillRectangle(brush, 0, y, pictureBox1.Width, height);
                }
            }

            // Солнце
            g.FillEllipse(Brushes.Yellow, pictureBox1.Width - 120, 30, 80, 80);
        }

        /// <summary>
        /// Рисует море с градиентом от светлого к темному
        /// </summary>
        /// <param name="g">Объект Graphics для рисования</param>
        private void DrawSea(Graphics g)
        {
            int seaLevel = pictureBox1.Height * 2 / 3;
            int seaHeight = pictureBox1.Height - seaLevel;
            int segmentHeight = seaHeight / seaColors.Length;

            for (int i = 0; i < seaColors.Length; i++)
            {
                using (SolidBrush brush = new SolidBrush(seaColors[i]))
                {
                    int y = seaLevel + i * segmentHeight;
                    int height = (i == seaColors.Length - 1) ?
                        pictureBox1.Height - y : segmentHeight;

                    g.FillRectangle(brush, 0, y, pictureBox1.Width, height);
                }
            }
        }

        /// <summary>
        /// Рисует лодку в указанных координатах
        /// </summary>
        /// <param name="g">Объект Graphics для рисования</param>
        /// <param name="x">X-координата лодки</param>
        /// <param name="y">Y-координата лодки</param>
        private void DrawBoat(Graphics g, int x, int y)
        {
            using (Pen brownPen = new Pen(Color.Brown, 2))
            using (Pen grayPen = new Pen(Color.Gray, 2))
            using (Pen darkRedPen = new Pen(Color.DarkRed, 2))
            {
                // Корпус лодки
                Point[] hull = {
                    new Point(x, y),
                    new Point(x + 150, y),
                    new Point(x + 120, y + 30),
                    new Point(x + 30, y + 30)
                };

                g.FillPolygon(Brushes.Brown, hull);
                g.DrawPolygon(brownPen, hull);

                // Мачта
                g.FillRectangle(Brushes.DarkGray, x + 75, y - 80, 5, 80);

                // Парус
                Point[] sail = {
                    new Point(x + 80, y - 80),
                    new Point(x + 80, y - 20),
                    new Point(x + 140, y - 50)
                };
                g.FillPolygon(Brushes.White, sail);
                g.DrawPolygon(grayPen, sail);

                // Флаг
                Point[] flag = {
                    new Point(x + 80, y - 85),
                    new Point(x + 80, y - 95),
                    new Point(x + 95, y - 90)
                };
                g.FillPolygon(Brushes.Red, flag);
                g.DrawPolygon(darkRedPen, flag);
            }
        }

        /// <summary>
        /// Рисует чайку в указанных координатах с учетом расстояния
        /// </summary>
        /// <param name="g">Объект Graphics для рисования</param>
        /// <param name="centerX">Центральная X-координата чайки</param>
        /// <param name="centerY">Центральная Y-координата чайки</param>
        private void DrawSeagull(Graphics g, int centerX, int centerY)
        {
            float sizeFactor = 1.0f - (float)seagullDistance / MaxDistance;
            sizeFactor = Math.Max(0.1f, sizeFactor);

            int currentX = centerX + (int)(seagullDistance * 0.3f);
            int currentY = centerY - (int)(seagullDistance * 0.2f);

            int bodyWidth = (int)(30 * sizeFactor);
            int bodyHeight = (int)(15 * sizeFactor);
            int wingSize = (int)(25 * sizeFactor);

            g.FillEllipse(Brushes.White, currentX, currentY, bodyWidth, bodyHeight);

            Point[] wings = {
                new Point(currentX + bodyWidth/2, currentY + bodyHeight/2),
                new Point(currentX - wingSize/2, currentY - wingSize/3),
                new Point(currentX + bodyWidth/2, currentY + bodyHeight/2),
                new Point(currentX + bodyWidth + wingSize/2, currentY - wingSize/3)
            };
            g.DrawLines(Pens.White, wings);
        }
    }
}
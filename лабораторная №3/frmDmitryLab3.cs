using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace TrainSimulation
{
    /// <summary>
    /// Главная форма приложения, содержащая анимацию движущегося поезда.
    /// </summary>
    public partial class frmDmitryLab3 : Form
    {
        // Позиции фонов
        private int backgroundPosition1 = 0;
        private int backgroundPosition2 = 0;
        private int trackPosition = 0;

        // Позиция поезда
        private int trainPositionX = 100;

        // Анимация шатунов
        private int connectingRodAngle = 0;
        private int wheelRotation = 0;

        // Случайные деревья для фона
        private List<Tree> trees = new List<Tree>();
        private Random random = new Random();

        // Таймер для анимации
        private Timer animationTimer;

        /// <summary>
        /// Инициализирует новый экземпляр класса Form1.
        /// </summary>
        public frmDmitryLab3()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ClientSize = new Size(800, 500);

            // Создаем случайные деревья для фона
            for (int i = 0; i < 20; i++)
            {
                trees.Add(new Tree
                {
                    X = random.Next(0, 2000),
                    Type = random.Next(1, 4),
                    Scale = 0.5f + (float)random.NextDouble() * 0.7f
                });
            }

            // Настраиваем таймер анимации
            animationTimer = new Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        /// <summary>
        /// Обработчик события таймера анимации.
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Движение фона
            backgroundPosition1 -= 3;
            backgroundPosition2 -= 3;

            if (backgroundPosition1 < -this.ClientSize.Width)
                backgroundPosition1 = this.ClientSize.Width;

            if (backgroundPosition2 < -this.ClientSize.Width)
                backgroundPosition2 = this.ClientSize.Width;

            // Движение рельс
            trackPosition -= 5;
            if (trackPosition < -50) trackPosition = 0;

            // Анимация шатунов и колес
            connectingRodAngle = (connectingRodAngle + 10) % 360;
            wheelRotation = (wheelRotation + 5) % 360;

            this.Invalidate();
        }

        /// <summary>
        /// Обрабатывает событие отрисовки формы.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Рисуем небо
            using (LinearGradientBrush skyBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, this.ClientSize.Height / 2),
                Color.LightSkyBlue,
                Color.White))
            {
                g.FillRectangle(skyBrush, 0, 0, this.ClientSize.Width, this.ClientSize.Height / 2);
            }

            // Рисуем землю
            using (LinearGradientBrush groundBrush = new LinearGradientBrush(
                new Point(0, this.ClientSize.Height / 2),
                new Point(0, this.ClientSize.Height),
                Color.DarkGreen,
                Color.SaddleBrown))
            {
                g.FillRectangle(groundBrush, 0, this.ClientSize.Height / 2, this.ClientSize.Width, this.ClientSize.Height / 2);
            }

            // Рисуем дальний фон (деревья)
            DrawBackground(g, backgroundPosition1);
            DrawBackground(g, backgroundPosition2);

            // Рисуем рельсы и шпалы
            DrawTracks(g);

            // Рисуем поезд
            DrawTrain(g);
        }

        /// <summary>
        /// Рисует фоновые деревья.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        /// <param name="offsetX">Смещение по оси X.</param>
        private void DrawBackground(Graphics g, int offsetX)
        {
            int groundLevel = this.ClientSize.Height / 2 + 50;

            foreach (var tree in trees)
            {
                int x = tree.X + offsetX;
                if (x < -100 || x > this.ClientSize.Width + 100) continue;

                DrawTree(g, x, groundLevel, tree.Type, tree.Scale);
            }
        }

        /// <summary>
        /// Рисует дерево заданного типа.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        /// <param name="x">Координата X основания дерева.</param>
        /// <param name="groundLevel">Уровень земли.</param>
        /// <param name="type">Тип дерева (1-3).</param>
        /// <param name="scale">Масштаб дерева.</param>
        private void DrawTree(Graphics g, int x, int groundLevel, int type, float scale)
        {
            int height = (int)(150 * scale);
            int width = (int)(80 * scale);

            // Ствол
            using (Pen trunkPen = new Pen(Color.SaddleBrown, 10 * scale))
            {
                g.DrawLine(trunkPen, x, groundLevel, x, groundLevel - height);
            }

            // Крона
            Color leavesColor = type == 1 ? Color.ForestGreen :
                              type == 2 ? Color.DarkGreen : Color.MediumSeaGreen;

            using (Brush leavesBrush = new SolidBrush(leavesColor))
            {
                if (type == 1 || type == 3)
                {
                    // Овальная крона
                    g.FillEllipse(leavesBrush, x - width / 2, groundLevel - height - width / 3, width, width);
                }
                else
                {
                    // Треугольная крона
                    Point[] triangle = new Point[]
                    {
                        new Point(x, groundLevel - height - width),
                        new Point(x - width/2, groundLevel - height),
                        new Point(x + width/2, groundLevel - height)
                    };
                    g.FillPolygon(leavesBrush, triangle);
                }
            }
        }

        /// <summary>
        /// Рисует железнодорожные пути.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        private void DrawTracks(Graphics g)
        {
            int trackLevel = this.ClientSize.Height / 2 + 100;

            // Рельсы
            using (Pen railPen = new Pen(Color.DarkGray, 10))
            {
                g.DrawLine(railPen, 0, trackLevel, this.ClientSize.Width, trackLevel);
                g.DrawLine(railPen, 0, trackLevel + 50, this.ClientSize.Width, trackLevel + 50);
            }

            // Шпалы
            using (Brush sleeperBrush = new SolidBrush(Color.Brown))
            {
                for (int x = trackPosition; x < this.ClientSize.Width + 50; x += 50)
                {
                    g.FillRectangle(sleeperBrush, x, trackLevel + 10, 40, 30);
                }
            }
        }

        /// <summary>
        /// Рисует поезд с локомотивом и вагоном.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        private void DrawTrain(Graphics g)
        {
            int trainBottom = this.ClientSize.Height / 2 + 100;

            // Локомотив
            using (Brush locomotiveBrush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(locomotiveBrush, trainPositionX + 220, trainBottom - 120, 200, 80);
            }

            // Труба
            using (Brush chimneyBrush = new SolidBrush(Color.Black))
            {
                g.FillRectangle(chimneyBrush, trainPositionX + 380, trainBottom - 160, 20, 40);
            }

            // Окно локомотива
            using (Brush windowBrush = new SolidBrush(Color.LightBlue))
            {
                g.FillRectangle(windowBrush, trainPositionX + 250, trainBottom - 100, 40, 30);
            }

            // Пассажирский вагон
            using (Brush carriageBrush = new SolidBrush(Color.Blue))
            {
                g.FillRectangle(carriageBrush, trainPositionX, trainBottom - 110, 200, 70);
            }

            // Окна вагона 
            for (int i = 0; i < 4; i++)
            {
                int windowX = trainPositionX + 20 + i * 45;

                // Рамка окна
                using (Pen windowFramePen = new Pen(Color.Black, 2))
                {
                    g.DrawRectangle(windowFramePen, windowX, trainBottom - 90, 30, 20);
                }
            }

            // Колеса
            DrawWheel(g, trainPositionX + 43, trainBottom - 30);
            DrawWheel(g, trainPositionX + 103, trainBottom - 30);
            DrawWheel(g, trainPositionX + 163, trainBottom - 30);
            DrawWheel(g, trainPositionX + 253, trainBottom - 30);
            DrawWheel(g, trainPositionX + 313, trainBottom - 30);
            DrawWheel(g, trainPositionX + 373, trainBottom - 30);

            // Шатуны
            DrawConnectingRod(g, trainPositionX + 253, trainBottom - 30, connectingRodAngle);
            DrawConnectingRod(g, trainPositionX + 313, trainBottom - 30, connectingRodAngle);
        }

        /// <summary>
        /// Рисует колесо поезда.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        /// <param name="x">Координата X центра колеса.</param>
        /// <param name="y">Координата Y центра колеса.</param>
        private void DrawWheel(Graphics g, int x, int y)
        {
            // Обод
            using (Pen wheelPen = new Pen(Color.Black, 8))
            {
                g.DrawEllipse(wheelPen, x - 25, y - 25, 50, 50);
            }

            // Спицы
            using (Pen spokePen = new Pen(Color.Black, 3))
            {
                for (int i = 0; i < 8; i++)
                {
                    double angle = (wheelRotation + i * 45) * Math.PI / 180;
                    int x2 = x + (int)(20 * Math.Cos(angle));
                    int y2 = y + (int)(20 * Math.Sin(angle));
                    g.DrawLine(spokePen, x, y, x2, y2);
                }
            }
        }

        /// <summary>
        /// Рисует шатун, соединяющий колеса.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования.</param>
        /// <param name="wheelX">Координата X центра колеса.</param>
        /// <param name="wheelY">Координата Y центра колеса.</param>
        /// <param name="angle">Текущий угол поворота шатуна.</param>
        private void DrawConnectingRod(Graphics g, int wheelX, int wheelY, int angle)
        {
            double rad = angle * Math.PI / 180;
            int rodLength = 60; // Длина шатуна (расстояние между центрами колес)

            // Первый конец шатуна закреплен на центре текущего колеса
            int fixedEndX = wheelX;
            int fixedEndY = wheelY;

            // Второй конец шатуна вращается по радиусу другого колеса
            int movingWheelX = wheelX + rodLength; // Положение другого колеса
            int movingWheelY = wheelY;

            // Точка крепления шатуна на другом колесе (вращается по окружности)
            int movingEndX = movingWheelX + (int)(25 * Math.Cos(rad + Math.PI)); // +Math.PI чтобы было противоположно
            int movingEndY = movingWheelY + (int)(25 * Math.Sin(rad + Math.PI));

            using (Pen rodPen = new Pen(Color.DarkRed, 5))
            {
                // Рисуем сам шатун
                g.DrawLine(rodPen, fixedEndX, fixedEndY, movingEndX, movingEndY);
            }
        }
    }

    /// <summary>
    /// Класс, представляющий дерево на фоне.
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Координата X основания дерева.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Тип дерева (1-3).
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Масштаб дерева.
        /// </summary>
        public float Scale { get; set; }
    }
}
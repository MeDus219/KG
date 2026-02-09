using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HelloWorld.лабораторная__3
{
    /// <summary>
    /// Главная форма приложения для демонстрации анимации
    /// </summary>
    public partial class frmMaksimLab3 : Form
    {
        /// <summary>
        /// Текущий диаметр пульсирующей окружности
        /// </summary>
        private float circleDiameter = 10;

        /// <summary>
        /// Шаг изменения диаметра окружности при анимации
        /// </summary>
        private const float DiameterStep = 2f;

        /// <summary>
        /// Флаг, указывающий растет ли окружность в текущий момент
        /// </summary>
        private bool isGrowing = true;

        /// <summary>
        /// Текущий цвет окружности
        /// </summary>
        private Color currentColor;

        /// <summary>
        /// Таймер для управления анимацией
        /// </summary>
        private readonly Timer animationTimer = new Timer();

        /// <summary>
        /// Генератор случайных чисел для создания цветов
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public frmMaksimLab3()
        {
            InitializeComponent();

            random = new Random();

            // Настройка свойств формы
            ConfigureForm();

            InitializeTimer();

            // Подписка на события формы
            SubscribeToEvents();

            // Генерация начального случайного цвета
            currentColor = GenerateRandomColor();
        }

        /// <summary>
        /// Настраивает основные параметры формы
        /// </summary>
        private void ConfigureForm()
        {
            this.ClientSize = new Size(800, 800);
            // Включаем двойную буферизацию для плавности анимации
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
        }

        /// <summary>
        /// Инициализирует и настраивает таймер анимации
        /// </summary>
        private void InitializeTimer()
        {
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        /// <summary>
        /// Подписывается на события формы
        /// </summary>
        private void SubscribeToEvents()
        {
            this.Paint += MainForm_Paint;
            this.Load += MainForm_Load;
        }

        /// <summary>
        /// Генерирует случайный цвет
        /// </summary>
        /// <returns>Случайно сгенерированный цвет</returns>
        private Color GenerateRandomColor()
        {
            return Color.FromArgb
            (
                random.Next(256),
                random.Next(256),
                random.Next(256)
            );
        }

        /// <summary>
        /// Рисует антенну в указанной точке
        /// </summary>
        /// <param name="g">Объект Graphics для рисования</param>
        /// <param name="center">Центральная точка для рисования антенны</param>
        private void DrawAntenna(Graphics g, Point center)
        {
            const int antennaHeight = 300;
            const int mastWidth = 10;
            const int crossbarCount = 5;

            // Рисуем центральный стержень антенны
            using (Pen mastPen = new Pen(Color.Black, mastWidth))
            {
                g.DrawLine(mastPen,
                    center.X, center.Y - antennaHeight / 2,
                    center.X, center.Y + antennaHeight / 2);
            }

            // Рисуем поперечные элементы антенны
            for (int i = 0; i < crossbarCount; i++)
            {
                float yPos = center.Y - antennaHeight / 2 +
                           (i + 1) * (antennaHeight / (crossbarCount + 1));
                int length = 90 + i * 30;

                using (Pen crossbarPen = new Pen(Color.Black, 3))
                {
                    g.DrawLine(crossbarPen,
                        center.X - length / 2, yPos,
                        center.X + length / 2, yPos);
                }
            }
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            animationTimer.Start();
        }

        /// <summary>
        /// Обработчик тика таймера анимации
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isGrowing)
            {
                circleDiameter += DiameterStep;
                if (circleDiameter > Math.Min(ClientSize.Width, ClientSize.Height) * 1.0f)
                {
                    isGrowing = false;
                    // Смена цвета при достижении максимума
                    currentColor = GenerateRandomColor();
                }
            }
            else
            {
                circleDiameter -= DiameterStep;
                if (circleDiameter < 10f)
                {
                    isGrowing = true;
                    // Смена цвета при достижении минимума
                    currentColor = GenerateRandomColor();
                }
            }

            // Запрос на перерисовку
            Invalidate();
        }

        // <summary>
        /// Обработчик события отрисовки формы
        /// </summary>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Включаем сглаживание
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Point center = new Point(ClientSize.Width / 2, ClientSize.Height / 2);

            // Рисуем пульсирующую окружность
            using (Pen pulsePen = new Pen(currentColor, 3))
            {
                g.DrawEllipse(pulsePen,
                    center.X - circleDiameter / 2,
                    center.Y - circleDiameter / 2,
                    circleDiameter,
                    circleDiameter);
            }

            DrawAntenna(g, center);
        }
    }
}
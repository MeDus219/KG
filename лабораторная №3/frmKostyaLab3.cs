using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld.лабораторная__3
{
    public partial class frmKostyaLab3 : Form
    {
        public frmKostyaLab3()
        {
            InitializeComponent();
            InitializeColors();
            this.DoubleBuffered = true;
            this.Paint += MainForm_Paint;
            this.Load += MainForm_Load;
            this.MouseDown += MainForm_MouseDown;
        }

        private string word = "Пример";
        private PointF position = new PointF(300, 200);
        private float fontSize = 24;
        private float rotationAngle = 0;
        private Color[] letterColors;
        private Random random = new Random();
        private bool isRotating = false;

        /// <summary>
        /// Инициализирует массив цветов для каждой буквы слова
        /// </summary>
        private void InitializeColors()
        {
            letterColors = new Color[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                letterColors[i] = GetRandomColor();
            }
        }

        /// <summary>
        /// Генерирует случайный цвет
        /// </summary>
        /// <returns>Сгенерированный случайный цвет</returns>
        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        /// <summary>
        /// Обработчик события отрисовки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события Paint</param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawWord(e.Graphics);
        }

        /// <summary>
        /// Рисует слово с вращением вокруг средней буквы
        /// </summary>
        /// <param name="g">Графический контекст для рисования</param>
        private void DrawWord(Graphics g)
        {
            if (string.IsNullOrEmpty(word) || word.Length == 0) return;

            Font font = new Font("Arial", fontSize, FontStyle.Bold);

            // Находим среднюю букву
            int middleIndex = word.Length / 2;
            string middleChar = word[middleIndex].ToString();

            // Измеряем размер средней буквы
            SizeF middleCharSize = g.MeasureString(middleChar, font);

            // Позиция начала средней буквы
            float middleCharX = position.X;

            // Рассчитываем смещение для средней буквы
            for (int i = 0; i < middleIndex; i++)
            {
                middleCharX += g.MeasureString(word[i].ToString(), font).Width;
            }

            // Центр средней буквы - точка вращения
            PointF rotationCenter = new PointF(
                middleCharX + middleCharSize.Width / 2,
                position.Y + middleCharSize.Height / 2);

            // Сохраняем исходное состояние
            GraphicsState state = g.Save();

            // Устанавливаем преобразования
            g.TranslateTransform(rotationCenter.X, rotationCenter.Y);
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-rotationCenter.X, -rotationCenter.Y);

            // Рисуем все буквы
            float currentX = position.X;
            for (int i = 0; i < word.Length; i++)
            {
                string letter = word[i].ToString();
                float letterWidth = g.MeasureString(letter, font).Width;

                g.DrawString(letter, font, new SolidBrush(letterColors[i]),
                            currentX, position.Y);

                currentX += letterWidth;
            }

            // Восстанавливаем состояние
            g.Restore(state);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки мыши на форме
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события мыши</param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                position = e.Location;
                this.Refresh();
            }
        }

        /// <summary>
        /// Обработчик события загрузки формы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            trackBarFontSize.Value = (int)fontSize;
            txtWord.Text = word;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Старт/Стоп"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            isRotating = !isRotating;
            btnStartStop.Text = isRotating ? "Стоп" : "Старт";

            if (isRotating)
            {
                new Thread(() =>
                {
                    while (isRotating)
                    {
                        rotationAngle = (rotationAngle + 2) % 360;
                        this.Invoke((MethodInvoker)delegate { this.Refresh(); });
                        Thread.Sleep(50);
                    }
                }).Start();
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки смены цветов букв
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void btnChangeColors_Click(object sender, EventArgs e)
        {
            InitializeColors();
            this.Refresh();
        }

        /// <summary>
        /// Обработчик события изменения положения ползунка размера шрифта
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void trackBarFontSize_Scroll(object sender, EventArgs e)
        {
            fontSize = trackBarFontSize.Value;
            this.Refresh();
        }

        /// <summary>
        /// Обработчик события изменения текста в поле ввода
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            word = txtWord.Text;
            InitializeColors();
            this.Refresh();
        }
    }
}

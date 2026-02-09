using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    /// <summary>
    /// Основная форма приложения для вычисления модуля и векторного произведения.
    /// </summary>
    public partial class frmMaximLab1 : Form
    {
        /// <summary>
        /// Конструктор класса LabMax1, инициализирует компоненты формы.
        /// </summary>
        public frmMaximLab1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для вычисления модуля вектора.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonModule_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBoxX1.Text);
                double y = double.Parse(textBoxY1.Text);
                double z = double.Parse(textBoxZ1.Text);

                double module = Math.Sqrt(x * x + y * y + z * z);
                labelResult.Text = $"Модуль вектора: {module:F2}";
            }
            catch (FormatException)
            {
                labelResult.Text = "Ошибка ввода! Пожалуйста, введите числовые значения.";
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки для вычисления векторного произведения двух векторов.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void buttonVektor_Click(object sender, EventArgs e)
        {
            try
            {
                // Чтение координат первого вектора из текстовых полей
                double x1 = double.Parse(textBoxX1.Text);
                double y1 = double.Parse(textBoxY1.Text);
                double z1 = double.Parse(textBoxZ1.Text);

                // Чтение координат второго вектора из текстовых полей
                double x2 = double.Parse(textBoxX2.Text);
                double y2 = double.Parse(textBoxY2.Text);
                double z2 = double.Parse(textBoxZ2.Text);

                // Вычисление векторного произведения
                double vektorX = y1 * z2 - z1 * y2;
                double vektorY = z1 * x2 - x1 * z2;
                double vektorZ = x1 * y2 - y1 * x2;

                // Отображение результата
                labelResult.Text = $"Векторное произведение: ({vektorX:F2}, {vektorY:F2}, {vektorZ:F2})";
            }
            catch (FormatException)
            {
                labelResult.Text = "Ошибка ввода! Пожалуйста, введите числовые значения.";
            }
        }
    }
}

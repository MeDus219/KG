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
    /// Основная форма для приложения "Компьютерная графика".
    /// Позволяет пользователю открывать различные лабораторные работы.
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// Конструктор для формы ComputerGraphics.
        /// Инициализирует компоненты формы.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 1.
        /// Открывает форму Lab1.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmMainLab1 f = new frmMainLab1(); // Создаем экземпляр формы Lab1
            f.Show(); // Показываем форму Lab1
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 2.
        /// Открывает форму Lab2.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            frmMainLab2 f = new frmMainLab2();
            f.Show();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 3.
        /// Открывает форму Lab3.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Lab3 f = new Lab3();
            f.Show();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 4.
        /// Открывает форму Lab4.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            frmMainLab4 f = new frmMainLab4();
            f.Show();
        }
    }
}

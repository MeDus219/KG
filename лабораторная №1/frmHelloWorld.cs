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
    /// Представляет форму Form2.
    /// Используется для отображения дополнительных опций или информации.
    /// </summary>
    public partial class frmHelloWorld : Form
    {
        /// <summary>
        /// Конструктор для формы Form2.
        /// Инициализирует компоненты формы.
        /// </summary>
        public frmHelloWorld()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки button1.
        /// Устанавливает результат диалога в DialogResult.OK.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки button2.
        /// Устанавливает результат диалога в DialogResult.Cancel.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

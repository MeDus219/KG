using HelloWorld.лабораторная__2;
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
    /// Главная форма лабораторной работы 2 для демонстрации заданий
    /// </summary>
    public partial class frmMainLab2 : Form
    {
        public frmMainLab2()
        {
            InitializeComponent();
        }

        private void btnSlaveDima_Click(object sender, EventArgs e)
        {
            frmSlaveDimaLab2 form = new frmSlaveDimaLab2();
            form.Show();
        }

        private void btnDirectorLab2_Click(object sender, EventArgs e)
        {
            frmRastrAlgoritm form = new frmRastrAlgoritm();
            form.Show();
        }

        private void btnWriterLab2_Click(object sender, EventArgs e)
        {
            frmWriterLab2 form = new frmWriterLab2();
            form.Show();
        }

        private void btnSlaveRomaLab2_Click(object sender, EventArgs e)
        {
            frmSlaveRomaLab2 form = new frmSlaveRomaLab2();
            form.Show();
        }
    }
}

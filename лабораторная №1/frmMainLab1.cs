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
    public partial class frmMainLab1 : Form
    {
        public frmMainLab1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDirectorLab1 f = new frmDirectorLab1();
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmWriterLab1 f = new frmWriterLab1();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMaximLab1 f = new frmMaximLab1();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSlaveLab1 f = new frmSlaveLab1();
            f.Show();
        }
    }
}

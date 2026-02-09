using HelloWorld.лабораторная__3;
using KG_laba3;
using KG_Laba3_Individual;
using TrainSimulation;
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
    public partial class Lab3 : Form
    {
        public Lab3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDmitryLab3 form = new frmDmitryLab3();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMaksimLab3 form = new frmMaksimLab3();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmBaseLab3 form = new frmBaseLab3();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmRomanLab3 form = new frmRomanLab3();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKostyaLab3 form = new frmKostyaLab3();
            form.Show();
        }
    }
}

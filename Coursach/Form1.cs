using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help prog = new Help();
            prog.ShowDialog();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') !=-1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl (e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button1.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double width;
            double height;
            double area;
            double perim;
            double cd;
            double eps = 0;

            try
            {
                width = Convert.ToDouble(textBox2.Text);
                height = Convert.ToDouble(textBox1.Text);

                area = width * height;
                perim = (width + height) * 2;

                label10.Text = area.ToString();
                label11.Text = perim.ToString();
                label12.Text = Math.Ceiling(perim).ToString();

                if (area <= 10d) eps = 1.275;          
                if ((area > 10d) && (area <= 20d)) eps = 1.175;
                if (area > 20d) eps = 1.075;


                if ((width <= 3) && (height <= 3))
                    cd = ((width * (height / 0.6 - 1) + height * (width / 0.6 - 1)) * eps) / 3;
                else
                    cd = ((width * (height / 0.6 - 1) + height * (width / 0.6 - 1)) * eps) / 4;

                label13.Text = Math.Ceiling(cd).ToString();
                label14.Text = Math.Ceiling(area / 0.6).ToString();
                label15.Text = Math.Ceiling(area / 3).ToString();
                label16.Text = Math.Ceiling((area / 0.6) * 2 * 1.2).ToString();
            }
            catch
            {
                textBox1.Focus();
            }
        }
    }
}

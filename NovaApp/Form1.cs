using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace NovaApp
{
    public partial class Form1 : Form
    {
        Random random = new Random();
       
        
        
        public Form1()
        {
            InitializeComponent();
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form form = new Form();
            form.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            form.Width = 300;
            form.Height = 200;
            form.Controls.Add(button1);
            button1.Location = new Point(0, 0);
            form.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            changeColor();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            changeColor();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            changeColor();
        }
        private void changeColor()
        {
            int red = (int)((double)trackBar1.Value / trackBar1.Maximum * 255);
            int green = (int)((double)trackBar2.Value / trackBar2.Maximum * 255);
            int blue = (int)((double)trackBar3.Value / trackBar3.Maximum * 255);

            ActiveForm.BackColor = Color.FromArgb(red, green, blue);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ActiveForm.Size = new Size(500, 600);
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ActiveForm.Size = new Size(600, 500);
            checkBox1.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string zprava = "To je nějaké dlouhé ne? :)";
            if (textBox1.Text == "red")
            {
                ActiveForm.BackColor = Color.Red;
            } else if (textBox1.Text == "blue")
            {
                ActiveForm.BackColor = Color.Blue;
            } else if (textBox1.Text == "green")
            {
                ActiveForm.BackColor = Color.Green;
            } else
            {
                ActiveForm.BackColor = Color.White;
            }

            if (textBox1.Text.Length > 10){
                MessageBox.Show(zprava);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    panel1.BackColor = cd.Color;    
                }
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (trackBar4.Value <= 1)
            {
                panel3.BackColor = Color.Black;
            }
            else if (trackBar4.Value >= 2)
            {
                panel3.BackColor = Color.Yellow;
            }
            panel3.BackColor = Color.FromArgb(trackBar4.Value, 255, 255, 0);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ActiveForm.Size = new Size(900, 600);
            checkBox1.Checked = false;
        }
    }
}

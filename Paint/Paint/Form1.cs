using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{

    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(1024, 768);
        Pen kalem = new Pen(Color.White, 6);
        bool draw = false;
        public Form1()
        {



            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (draw)
                draw = false;
            else
                draw = true;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(draw)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawEllipse(kalem, e.X, e.Y,6,1);
                pictureBox1.Image = bmp;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            kalem.Color = Color.Red; 

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            kalem.Color = Color.Blue; 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            kalem.Color = Color.Green;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            kalem.Color = Color.Purple;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            kalem.Color = Color.Lime;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPEG Files (*.jpg) | *.jpg|BMP Files (*.bmp)|*.bmp";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.ShowDialog();
            if ( saveFileDialog1.FileName !="")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace greyscale
{
    public partial class Form1 : Form
    {
        int[,] macierz;
        int[,] macierzR;
        int[,] macierzG;
        int[,] macierzB;
        int[,] macierzGray;
        int[,] macierzSepia;

        Bitmap newbitmap;
        public Form1()
        {
            InitializeComponent();

        }
        void GrayScale()
        {
           

            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int x = 0; x < macierz.GetLength(1); x++)
                {
                    Color oc = newbitmap.GetPixel(i, x);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    newbitmap.SetPixel(i, x, nc);
                    
                }
            }
            pictureBox1.Image = newbitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                newbitmap = new Bitmap(openFileDialog1.FileName);

            }
            macierzR = new int[newbitmap.Width, newbitmap.Height];
            macierzG = new int[newbitmap.Width, newbitmap.Height];
            macierzB = new int[newbitmap.Width, newbitmap.Height];
            macierzGray = new int[newbitmap.Width, newbitmap.Height];
            macierzSepia = new int[newbitmap.Width, newbitmap.Height];
            for (int i = 0; i < macierzR.GetLength(0); i++)
            {
                for (int j = 0; j < macierzR.GetLength(1); j++)
                {
                    macierzR[i, j] = newbitmap.GetPixel(i, j).R;
                    macierzG[i, j] = newbitmap.GetPixel(i, j).G;
                    macierzB[i, j] = newbitmap.GetPixel(i, j).B;
                   
                    macierzGray[i, j] = (macierzR[i,j]+macierzG[i,j] + macierzB[i,j])/3;
                    

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < macierzR.GetLength(0); i++)
            {
                for (int j = 0; j < macierzR.GetLength(1); j++)
                {
                    newbitmap.SetPixel(i, j, Color.FromArgb(macierzGray[i, j], macierzGray[i, j], macierzGray[i, j]));
                    pictureBox1.Image = newbitmap;

                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            for (int x= 0; x<pictureBox1.Image.Size.Width; x++)
            {
                for (int y = 0; y<pictureBox1.Image.Size.Height; y++)
                {
                    macierzR[x, y] = trackBar1.Value;
                    macierzGray[x, y] = (macierzR[x, y] + macierzG[x, y] + macierzB[x, y]) / 3;
                }
            }

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar2.Value.ToString();
            for (int x = 0; x < pictureBox1.Image.Size.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Image.Size.Height; y++)
                {
                    macierzG[x, y] = trackBar2.Value;
                    macierzGray[x, y] = (macierzR[x, y] + macierzG[x, y] + macierzB[x, y]) / 3;
                }
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar3.Value.ToString();
            for (int x = 0; x < pictureBox1.Image.Size.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Image.Size.Height; y++)
                {
                    macierzB[x, y] = trackBar3.Value;
                    macierzGray[x, y] = (macierzR[x, y] + macierzG[x, y] + macierzB[x, y]) / 3;
                }
            }
        }
    }
}

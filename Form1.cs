using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resim_Üzerinde_Yazı_Yazma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string resim;
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            

            openFileDialog1.ShowDialog();
            resim = openFileDialog1.FileName;
            bmp = new Bitmap(resim);
            pictureBox1.Image = bmp;
        }
        Color renk;
        private void btnRenkSec_Click(object sender, EventArgs e)
        {

            colorDialog1.ShowDialog();
            renk = colorDialog1.Color;
            btnRenkSec.BackColor = renk;
        }
        Bitmap bmp;
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (txtMetin.Text != "")
            {
                try
                {
                    Graphics gr = Graphics.FromImage(bmp);
                    gr.DrawString(txtMetin.Text, new Font("Candara", Convert.ToInt16(txtBoyut.Text), FontStyle.Bold), new SolidBrush(renk), 20, 30);
                    pictureBox1.Image = bmp;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Boyut boş olamaz");
                }
            }
            else
            {
                MessageBox.Show("Metin giriniz");
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Resim|.jpg";
            saveFileDialog1.ShowDialog();
            bmp.Save(saveFileDialog1.FileName);

        }
    }
}
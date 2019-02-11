using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologyCapstone
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        public Form1()
        {
            InitializeComponent();

            ZoomSlider.Minimum = 1;
            ZoomSlider.Maximum = 10;
            //ZoomSlider.Value = 
        }


        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.InitialDirectory = @"C:\Users\FAITH\Pictures\geography";
            DialogResult picResult = pic.ShowDialog();
            String picLocation = pic.FileName;
            pictureBox1.ImageLocation = picLocation;
            pictureBox1.Load();
            originalImage = pictureBox1.Image;                                    
        }

        private void ZoomSlider_Scroll(object sender, EventArgs e)
        {
            if(ZoomSlider.Value > 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = PictureZoom(originalImage, new Size(ZoomSlider.Value, ZoomSlider.Value));
                pictureBox1.Load();
            }            
        }

        public Image PictureZoom(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), 
                Convert.ToInt32(img.Height * size.Height));
            Graphics graph = Graphics.FromImage(bm);
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

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
        private int zoomCentre = 8;
        public Form1()
        {
            InitializeComponent();

            ZoomSlider.Minimum = 1;
            ZoomSlider.Maximum = 16;
            ZoomSlider.Value = zoomCentre;
        }


        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.InitialDirectory = @"C:\Users\FAITH\Pictures\geography";
            //Filter to show only Files with Image extensions
            //pic.Filter = "Image Files|*.png;*.jpg;*.bmp";
            //pic.FilterIndex = 0;
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
              pictureBox1.Image = PictureZoom_Function(originalImage, new Size(ZoomSlider.Value, ZoomSlider.Value));
            }  
            /*Bitmap newImage = new Bitmap(originalImage, (Convert.ToInt32(originalImage.Width * ZoomSlider.Value)
               /10 ),(Convert.ToInt32(originalImage.Height * ZoomSlider.Value)/10));
            //New Graphics object
            Graphics g = Graphics.FromImage(newImage);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic; //clean up Image
            pictureBox1.Image = null;
            pictureBox1.Image = newImage;*/
        }

        public Image PictureZoom_Function(Image img, Size size)
        {
            Bitmap newImage = new Bitmap(img, Convert.ToInt32((img.Width * size.Width)/10), 
                Convert.ToInt32((img.Height * size.Height)/10));
            Graphics graph = Graphics.FromImage(newImage);  //New Graphics object
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic; //clean up Image
            return newImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

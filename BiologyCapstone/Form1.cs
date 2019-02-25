using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Reference - StackOverflow
namespace BiologyCapstone
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private int zoomCentre = 5;
        public Form1()
        {
            InitializeComponent();

            ZoomSlider.Minimum = 1;
            ZoomSlider.Maximum = zoomCentre * 2;
            ZoomSlider.Value = zoomCentre;
            brightnessControl.Minimum = 0;
            brightnessControl.Maximum = 10;
            //brightnessControl.Value = 0;
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
            EditedImage.Image = pictureBox1.Image;
        }

        private void ZoomSlider_Scroll(object sender, EventArgs e)
        {
            if(ZoomSlider.Value > 0)
            {
              EditedImage.Image = null;
              EditedImage.Image = PictureZoom_Function(originalImage, new Size(ZoomSlider.Value, ZoomSlider.Value));
            }
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
        //Still need to figure out how to reset trackBar when program is till runnin but a new image is loaded
        //Also need to figure out how to undo the change in brightness, when the trackBar is moved backwards
        private void brightnessControl_Scroll(object sender, EventArgs e)
        {
            int currentTrackBarPosition = brightnessControl.Value;
            double scaledPostion = currentTrackBarPosition * 51.2;
            if(EditedImage.Image != null)
            {
                originalImage = EditedImage.Image;
                Bitmap bmpOriginalImage = new Bitmap(originalImage);
                //EditedImage.Image = AdjustPixelDisplayByBrightness_Function(originalImage, scaledPostion);
                EditedImage.Image = UsingLockBitsToEditPixels(bmpOriginalImage, scaledPostion);
            }            
        }
        public Image AdjustPixelDisplayByBrightness_Function(Image image, double value)
        {
            Bitmap bmp = new Bitmap(image);
            for(int i = 0; i < bmp.Width; i ++)
            {                
                for(int j = 0; j < bmp.Height; j ++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    double distance = Math.Sqrt((red * red) + (green * green) + (blue * blue));
                    //float pixelBrightness = c.GetBrightness();                    
                    if (distance < value)
                    {
                        c = Color.Black;                                               
                    }
                    bmp.SetPixel(i, j, c);
                }
            }
            return bmp;
        }

        public Bitmap UsingLockBitsToEditPixels(Bitmap img, double value)
        {
            Bitmap bmp = img;
            //to use LockBits had to allow unsafe code - Should I still do this???
            //use LockBit to access pixels with pointers
            unsafe
            {
                BitmapData imageBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, bmp.PixelFormat);

                //number of bytes per pixel, height of pixels, width of pixels in bytes
                int numBytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightOfPixels = imageBmpData.Height;
                int widthOfPixelsinBytes = imageBmpData.Width * numBytesPerPixel;

                //pointer to adress of first pixel - Scan0 gets/sets address of first pixel in bitmap
                byte* pointerFirstPixel = (byte*)imageBmpData.Scan0;

                //Get the RGB components, check brightness and adjust as necessary
                for(int i = 0; i < heightOfPixels; i ++)
                {
                    //.Stride gets/sets scan width of the bitmap object
                    //use .Stride to go through each line of the image
                    byte* currentLine = pointerFirstPixel + (i * imageBmpData.Stride);
                    for(int j = 0; j < widthOfPixelsinBytes; j = j + numBytesPerPixel)
                    {
                        //Get RGB components
                        int red = currentLine[j];
                        int green = currentLine[j + 1];
                        int blue = currentLine[j + 2];

                        double distance = Math.Sqrt((red * red) + (green * green) + (blue * blue));
                        if (distance < value)
                        {
                            currentLine[j] = 0;
                            currentLine[j + 1] = 0;
                            currentLine[j + 2] = 0;
                        }
                    }
                }
                bmp.UnlockBits(imageBmpData);
            }            
            return bmp;
        }

        private void EditedImage_Click(object sender, EventArgs e)
        {

        }
    }
}


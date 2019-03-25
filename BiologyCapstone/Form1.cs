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
        private Image editedImage;
        private int zoomCentre = 5;
        public float width;
        public float height;
        public Form1()
        {
            InitializeComponent();

            ZoomSlider.Minimum = 1;
            ZoomSlider.Maximum = zoomCentre * 2;
            ZoomSlider.Value = zoomCentre;
            brightnessControl.Minimum = 0;
            brightnessControl.Maximum = 100;
            brightnessControl.Value = 0;
        }

        public void Form1_Resize(object sender, EventArgs e)
        {
            float newWidth = this.Width / width;
            float newHeight = this.Height / height;
            setControls(newWidth, newHeight, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(Form1_Resize);
            width = this.Width;
            height = this.Height;
            setTarget(this);
        }

        public void setTarget(Control control)
        {
            foreach (Control con in control.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
            }
        }

        public void setControls(float newWidth, float newHeight, Control control)
        {
            foreach(Control con in control.Controls)
            {
                string[] myTarget = con.Tag.ToString().Split(new char[] { ':' });
                float dimensions = Convert.ToSingle(myTarget[0]) * newWidth;
                con.Width = (int)(dimensions);

                dimensions = Convert.ToSingle(myTarget[1]) * newHeight;
                con.Height = (int)(dimensions);

                dimensions = Convert.ToSingle(myTarget[2]) * newWidth;
                con.Left = (int)(dimensions);

                dimensions = Convert.ToSingle(myTarget[3]) * newHeight;
                con.Top = (int)(dimensions);

                Single currentSize = Convert.ToSingle(myTarget[4]) * newWidth;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
            }
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
            PictureZoom_Function(originalImage, new Size(pictureBox1.Width, pictureBox1.Height), pictureBox1);            
            EditedImage.Image = pictureBox1.Image;
            editedImage = EditedImage.Image;
            ZoomSlider.Value = zoomCentre;
            brightnessControl.Value = 0;
        }

        private void ZoomSlider_Scroll(object sender, EventArgs e)
        {
            if(ZoomSlider.Value > 0)
            {
              //EditedImage.Image = null;
              //EditedImage.Image = PictureZoom_Function(originalImage, new Size(ZoomSlider.Value, ZoomSlider.Value));
                PictureZoom_Function(originalImage, new Size(originalImage.Width * ZoomSlider.Value / ZoomSlider.Maximum, 
                  originalImage. Height * ZoomSlider.Value / ZoomSlider.Maximum), EditedImage);
            }
        }

        public void PictureZoom_Function(Image img, Size size, PictureBox zoomedImageBox)
        {
            Bitmap newImage = new Bitmap(img, size.Width, size.Height);
            Graphics graph = Graphics.FromImage(newImage);  //New Graphics object
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic; //clean up Image
            zoomedImageBox.Image = newImage;            
        }

        private void brightnessControl_Scroll(object sender, EventArgs e)
        {
            int currentTrackBarPosition = brightnessControl.Value;
            //double scaledPostion = currentTrackBarPosition * 51.2; // Make 51.2 calculated value
            //double scaling = Math.Sqrt((byte.MaxValue * byte.MaxValue) + (byte.MaxValue * byte.MaxValue) + 
            // (byte.MaxValue * byte.MaxValue));
            double scaling = Math.Sqrt(byte.MaxValue * byte.MaxValue * 3);
            scaling = scaling / 100;
            double scaledPostion = currentTrackBarPosition * scaling;
            if (EditedImage.Image != null)
            {
                //originalImage = EditedImage.Image;
                Bitmap bmpOriginalImage = new Bitmap(pictureBox1.Image);
                //EditedImage.Image = AdjustPixelDisplayByBrightness_Function(originalImage, scaledPostion);
                EditedImage.Image = UsingLockBitsToEditPixels(bmpOriginalImage, scaledPostion);
                editedImage = EditedImage.Image;
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
            //to use LockBits had to allow unsafe code
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

       
       private void minimumRadius_Scroll(object sender, EventArgs e)
        {
            
        }       

        public int numberOfPoints(Image img, double value)
        {
            Bitmap bmp = new Bitmap(img);
            
            BitmapData imageBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                   ImageLockMode.ReadWrite, bmp.PixelFormat);

            //number of bytes per pixel, height of pixels, width of pixels in bytes
            int numBytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int heightOfPixels = imageBmpData.Height;
            int widthOfPixelsinBytes = imageBmpData.Width * numBytesPerPixel;
            bool[,] nonDarkPixels = new bool[bmp.Height, widthOfPixelsinBytes];
            //to use LockBits had to allow unsafe code
            //use LockBit to access pixels with pointers
            unsafe
            {          

                //pointer to adress of first pixel - Scan0 gets/sets address of first pixel in bitmap
                byte* pointerFirstPixel = (byte*)imageBmpData.Scan0;

                //Get the RGB components, check brightness and adjust as necessary
                for (int i = 0; i < heightOfPixels; i++)
                {    //.Stride gets/sets scan width of the bitmap object
                    //use .Stride to go through each line of the image
                    byte* currentLine = pointerFirstPixel + (i * imageBmpData.Stride);
                    for (int j = 0; j < widthOfPixelsinBytes; j = j + numBytesPerPixel)
                    {
                        //Get RGB components
                        int red = currentLine[j];
                        int green = currentLine[j + 1];
                        int blue = currentLine[j + 2];

                        double distance = Math.Sqrt((red * red) + (green * green) + (blue * blue));
                        if (distance > 0) // if the pixel is not black find it's components
                        {
                            nonDarkPixels[i, j] = true;
                        }

                    }
                }
                bmp.UnlockBits(imageBmpData);
            }
            int count = 0;
            bool [,] visited = new bool[bmp.Height, widthOfPixelsinBytes];
            for (int i = 0; i < visited.GetLength(0); i ++)
            {
                for(int j = 0; j < visited.GetLength(1); j ++)
                {
                    if(nonDarkPixels[i, j] && !visited[i,j])
                    {
                        //DFS count connected methods
                        DepthFirstSearch(nonDarkPixels, i, j, visited);                        
                        count ++;           // count = number of components??
                    }
                }
            }
            return count;
        }

        public bool [,] DepthFirstSearch(bool [, ] nonDarkPixels, int starti, int startj, bool[,] visited)
        {
            visited[starti, startj] = true;
            for(int i = starti - 1; i <= starti + 1; i ++) // go +1 and - 1 from each pixel
            {
                for(int j = startj - 1; j <= startj + 1; j ++)
                {
                    if (i < visited.GetLength(0) && j < visited.GetLength(1) && i >= 0 && j >= 0
                        && visited[i, j] == false && nonDarkPixels[i, j] == true)
                    {
                        DepthFirstSearch(nonDarkPixels, i, j, visited);
                    }
                }
            }
            return visited;
        }

        public void DFS(bool [,] visited, int startX, int startY)
        {            
                      
        }

        
        
        private void EditedImage_Click(object sender, EventArgs e)
        {

        }

        private void numberOfSpots_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Count_Click(object sender, EventArgs e)
        {
            int currentTrackBarPosition = brightnessControl.Value;
            double scaling = Math.Sqrt(byte.MaxValue * byte.MaxValue * 3);
            scaling = (scaling + scaling) / 100;
            double scaledPostion = currentTrackBarPosition * scaling;
            int number = numberOfPoints(editedImage, scaledPostion);
            numberOfSpots.Text = number.ToString();
        }
    }
}

  
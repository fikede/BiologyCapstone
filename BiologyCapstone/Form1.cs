using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
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
        int numOfSpots;
        public int minNumberOfPixels;
        public int maxNumberOfPixels;
        public Form1()
        {
            InitializeComponent();

            ZoomSlider.Minimum = 1;
            ZoomSlider.Maximum = zoomCentre * 2;
            ZoomSlider.Value = zoomCentre;
            brightnessControl.Minimum = 0;
            brightnessControl.Maximum = 100;
            brightnessControl.Value = 0;
            maximumRadius.Minimum = 0;
            maximumRadius.Maximum = 100;
            minimumRadius.Minimum = 0;
            minimumRadius.Maximum = 100;
            ZoomSlider.Hide();
            Zoom.Hide();
        }
               
        private void Form1_Resize_1(object sender, EventArgs e)
        {
            float newWidth = this.Width / width;
            float newHeight = this.Height / height;
            setControls(newWidth, newHeight, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            if(pic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = pic.FileName;
            }
            pictureBox1.Load();
            originalImage = pictureBox1.Image;
            PictureZoom_Function(originalImage, new Size(pictureBox1.Width, pictureBox1.Height), pictureBox1);            
            EditedImage.Image = pictureBox1.Image;
            editedImage = EditedImage.Image;
            ZoomSlider.Value = zoomCentre;
            brightnessControl.Value = 0;
            maximumRadius.Value = 1;
            minimumRadius.Value = 1;
        }

        private void ZoomSlider_Scroll(object sender, EventArgs e)
        {
            if(ZoomSlider.Value > 0)
            {
                PictureZoom_Function(originalImage, new Size(originalImage.Width * ZoomSlider.Value 
                    / ZoomSlider.Maximum, originalImage. Height * ZoomSlider.Value / ZoomSlider.Maximum), 
                    EditedImage);
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
            double scaling = Math.Sqrt(byte.MaxValue * byte.MaxValue * 3);
            scaling = scaling / 100;
            double scaledPostion = currentTrackBarPosition * scaling;
            if (EditedImage.Image != null)
            {
                //originalImage = EditedImage.Image;
                Bitmap bmpOriginalImage = new Bitmap(pictureBox1.Image);
                EditedImage.Image = UsingLockBitsToEditPixels(bmpOriginalImage, scaledPostion);
                editedImage = EditedImage.Image;
            }            
        }

        public Bitmap UsingLockBitsToEditPixels(Bitmap img, double value)
        {
            Bitmap bmp = img;
            //to use LockBits have to allow unsafe code
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
         
        public int numberOfPoints(Image img)
        {
            Bitmap bmp = new Bitmap(img);            
            BitmapData imageBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                   ImageLockMode.ReadWrite, bmp.PixelFormat);

            //number of bytes per pixel, height of pixels, width of pixels in bytes
            int numBytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int heightOfPixels = imageBmpData.Height;
            int widthOfPixelsinBytes = imageBmpData.Width * numBytesPerPixel;
            bool[,] nonDarkPixels = new bool[bmp.Height, bmp.Width];
            unsafe
            {  
                //pointer to adress of first pixel - Scan0 gets/sets address of first pixel in bitmap
                byte* pointerFirstPixel = (byte*)imageBmpData.Scan0;

                for (int i = 0; i < heightOfPixels; i++)
                {    
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
                            nonDarkPixels[i, j/numBytesPerPixel] = true;
                        }
                    }
                }
                bmp.UnlockBits(imageBmpData);
            }
            int count = 0;
            bool [,] visited = new bool[bmp.Height, bmp.Width];
            List<Spot> spots = new List<Spot>();                 
            
            for (int i = 0; i < visited.GetLength(0); i ++)
            {
                for(int j = 0; j < visited.GetLength(1); j ++)
                {
                    if(nonDarkPixels[i, j] && !visited[i,j])
                    {
                        //DFS count connected methods
                        Spot s =  DepthFirstSearch(nonDarkPixels, i, j, visited);
                        count++;           // count = number of components in the whole image
                        spots.Add(s);
                        
                    }
                }
            }
            int counter = numberOfSpotsBasedOnRadius(spots);
            return counter;
        }

        public int numberOfSpotsBasedOnRadius(List<Spot> spots)
        {
            int count = 0;
            for (int i = 0; i < spots.Count; i++)
            {
                if (spots[i].getNumberOfPixelsInASpot() < minNumberOfPixels)
                {
                    spots[i].setNumberOfComponents(0);
                }
                else if (spots[i].getNumberOfPixelsInASpot() <= maxNumberOfPixels 
                    && spots[i].getNumberOfPixelsInASpot() >= minNumberOfPixels)
                {
                    spots[i].setNumberOfComponents(1);
                }
                
                else if (spots[i].getNumberOfPixelsInASpot() > maxNumberOfPixels)
                {
                    int f = spots[i].getNumberOfPixelsInASpot();    
                    f = (int) (spots[i].getNumberOfPixelsInASpot() 
                        / maxNumberOfPixels);
                    spots[i].setNumberOfComponents(f);
                }
                
                count += spots[i].getNumberOfComponents();
            }   
            Draw(spots);
            return count;
        }

        public void Draw(List<Spot> spots)
        {
            Graphics g = this.EditedImage.CreateGraphics();    
            Font arialFont = new Font("Arial", 10, FontStyle.Bold);
            for (int c = 0; c < spots.Count; c++)
            {
                if (spots[c].getNumberOfComponents() > 0)
                {
                    //Now I'm just writing the number near/beside the spot instead of drawing
                    string text = spots[c].getNumberOfComponents().ToString();
                    Point p = new Point();
                    p.X = spots[c].getCentrePointY();
                    p.Y = spots[c].getCentrePointX();
                    g.DrawString(text, arialFont, Brushes.OrangeRed, p);
                }
            }
        }

        public Spot DepthFirstSearch(bool [, ] nonDarkPixels, int starti, int startj, bool[,] visited)
        {//return a spot instead
            int countX = 0;
            int countY = 0;
            int countOfPixelsInASpot = 0;
            int averageX = 0;
            int averageY = 0;
            Stack<Point> result = new Stack<Point>();
            Point temp = new Point();
            temp.X = starti;
            temp.Y = startj;
            result.Push(temp);
            while (result.Count != 0)
            {              
                Point newPoint = result.Pop();
                //find centre point, finding average x and y values
                visited[newPoint.X, newPoint.Y] = true;
                averageX += newPoint.X;
                averageY += newPoint.Y;
                countX++;
                countY++;
                countOfPixelsInASpot++;
                // i = height = y, j = width = x
                for (int i = newPoint.X - 1; i <= newPoint.X + 1; i++) // go +1 and - 1 from each pixel
                {
                    for (int j = newPoint.Y - 1; j <= newPoint.Y + 1; j++)
                    {
                        if (i < visited.GetLength(0) && j < visited.GetLength(1) && i >= 0 && j >= 0
                            && !visited[i, j] && nonDarkPixels[i, j])
                        {
                            Point p = new Point(); ;
                            p.X = i;     
                            p.Y = j;
                            result.Push(p);                            
                        }
                    }
                }
            }
            Spot sp = new Spot();
            averageX = averageX / countX;
            averageY = averageY / countY;
            
            Point centrePoint = new Point(averageX, averageY);
            sp.setCentrePoint(centrePoint);
            sp.setNumberOfPixelsInASpot(countOfPixelsInASpot);
            return sp;
        }
                
        private void EditedImage_Click(object sender, EventArgs e)
        {

        }

        private void numberOfSpots_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Count_Click(object sender, EventArgs e)
        {
            numOfSpots = numberOfPoints(editedImage);            
            countByRadius.Text = numOfSpots.ToString();                        
        }

        private void minimumRadius_Scroll(object sender, EventArgs e)
        {
            brightnessControl_Scroll(null, null);
            minimumSize.BackColor = Color.Black;
            Graphics g = this.minimumSize.CreateGraphics();
            g.Clear(minimumSize.BackColor);
            
            Pen p = new Pen(Brushes.Lime);
            p.Width = 1;
            Rectangle rect = new Rectangle();            

            minNumberOfPixels = (int) calculateNumberOfPixels(minimumRadius.Value);
            int radius = (int)Math.Sqrt(minNumberOfPixels / Math.PI);
            rect.Width = radius * 2;
            rect.Height = radius * 2;
                        
            rect.X = (minimumSize.Width / 2) - radius;
            rect.Y = (minimumSize.Height / 2) - radius;

            g.DrawEllipse(p, rect);
            g.FillEllipse(Brushes.Lime, rect);
        }

        private void radiusControl_Scroll(object sender, EventArgs e)
        {
            brightnessControl_Scroll(null, null);
            maximumSize.BackColor = Color.Black;
            Graphics g = this.maximumSize.CreateGraphics();
            g.Clear(maximumSize.BackColor);        
            Pen p = new Pen(Brushes.Lime);
            p.Width = 1;
            Rectangle rect = new Rectangle();
           
            
            maxNumberOfPixels = (int)calculateNumberOfPixels(maximumRadius.Value);
            int radius = (int) Math.Sqrt(maxNumberOfPixels / Math.PI);
            rect.Width = radius *2;
            rect.Height = radius * 2;

            rect.X = (maximumSize.Width / 2) - radius;
            rect.Y = (maximumSize.Height / 2) - radius;

            g.DrawEllipse(p, rect);
            g.FillEllipse(Brushes.Lime, rect);
        }

        public double calculateNumberOfPixels(int sliderPosition)
        {
            int f = 1;
            int p = sliderPosition;
            double c = Math.Log(EditedImage.Size.Height * EditedImage.Size.Width) / minimumRadius.Maximum;

            double numberOfPixels = f * Math.Exp(p * c);
            return numberOfPixels;
        }

        private void CountByRadius_Click(object sender, EventArgs e)
        {
        }

        private void count_Click_1(object sender, EventArgs e)
        {
        }

        private void adjustedCountByRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayText_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!displayText.Checked)
            {
                brightnessControl_Scroll(null, null);
            }
            else
            {
                numOfSpots = numberOfPoints(editedImage);
            }
        }
    }
}

  
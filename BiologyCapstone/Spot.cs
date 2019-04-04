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

namespace BiologyCapstone
{
    public class Spot
    {
        //Point centrePoint;
        public int numberOfPixelsInASpot;
        public Point centrePoint;
        public int numberOfComponents;
        public Spot()
        {
            centrePoint.X = 0;
            centrePoint.Y = 0;
            numberOfPixelsInASpot = 0;
            numberOfComponents = 0;
        }
        public Spot(Point centrePoint, int numberOfPixelsInASpot, int numberOfComponents)
        {
            this.centrePoint = centrePoint;
            this.numberOfPixelsInASpot = numberOfPixelsInASpot;
            this.numberOfComponents = numberOfComponents;
        }
        public Spot(int centrePointX, int centrePointY, int numberOfPixelsInASpot, 
            int numberOfComponents)
        {
            this.centrePoint.X = centrePointX;
            this.centrePoint.Y = centrePointY;
            this.numberOfPixelsInASpot = numberOfPixelsInASpot;
            this.numberOfComponents = numberOfComponents;
        }
        public void setCentrePoint(Point centrePoint)
        {
            this.centrePoint = centrePoint;
        }
        public void setCentrePoint(int centrePointX, int centrePointY)
        {
            this.centrePoint.X = centrePointX;
            this.centrePoint.Y = centrePointY;
        }
        public void setCentrePointX(int centrePointX)
        {
            this.centrePoint.X = centrePointX;
        }
        public void setCentrePointY(int centrePointY)
        {
            this.centrePoint.Y = centrePointY;
        }
        public void setNumberOfPixelsInASpot(int numberOfPixelsInASpot)
        {
            this.numberOfPixelsInASpot = numberOfPixelsInASpot;
        }
        public void setNumberOfComponents(int numberOfComponents)
        {
            this.numberOfComponents = numberOfComponents;
        }

        public Point getCentrePoint()
        {
            return centrePoint;
        }
        public int getCentrePointX()
        {
            return centrePoint.X;
        }
        public int getCentrePointY()
        {
            return centrePoint.Y;
        }
        public int getNumberOfPixelsInASpot()
        {
             return numberOfPixelsInASpot;
        }
        public int getNumberOfComponents()
        {
            return numberOfComponents;
        }
    }

}

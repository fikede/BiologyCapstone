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
        public int numberOfSpots;
        public Point centrePoint;
        public Spot()
        {
            centrePoint.X = 0;
            centrePoint.Y = 0;
            numberOfSpots = 0;
        }
        public Spot(Point centrePoint, int numberOfSpots)
        {
            this.centrePoint = centrePoint;
            this.numberOfSpots = numberOfSpots;
        }
        public Spot(int centrePointX, int centrePointY, int numberOfSpots)
        {
            this.centrePoint.X = centrePointX;
            this.centrePoint.Y = centrePointY;
            this.numberOfSpots = numberOfSpots;
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
        public void setNumberOfSpots(int numberOfSpots)
        {
            this.numberOfSpots = numberOfSpots;
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
        public int getNumberOfSpots()
        {
             return numberOfSpots;
        }


    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Polygon :  Graphic
    {
        public List<Point> lPoint;
        public Pen myPen;
        public List<Point> lPointsResize = new List<Point>();       
        public Polygon(List<Point> lPoint, Pen myPen)
        {
            this.lPoint = lPoint;
            this.myPen = myPen;            
        }
        public override void Move(int deltaX, int deltaY)
        {
            for (int i = 0; i < lPoint.Count; i++)
            {
                Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                lPoint[i] = p;
            }
            minX += deltaX;
            maxX += deltaX;
            minY += deltaY;
            maxY += deltaY;
        }
        public override void Draw(Graphics gp, bool isSelected)
        {            
            gp.DrawPolygon(myPen, lPoint.ToArray());
            minX = int.MaxValue; maxX = int.MinValue; minY = int.MaxValue; maxY = int.MinValue;
            foreach (Point point in lPoint)
            {
                if (point.X < minX)
                {
                    minX = point.X;
                }
                if (point.X > maxX)
                {
                    maxX = point.X;
                }
                if (point.Y < minY)
                {
                    minY = point.Y;
                }
                if (point.Y > maxY)
                {
                    maxY = point.Y;
                }
            }
            if (isSelected)
            {
                Brush myBrush;
                RectangleF[] rectangles = new RectangleF[8];
                if (myPen.Color.Equals(Color.Black) || myPen.Color.Equals(Color.White))
                {
                    myBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    myBrush = new SolidBrush(Color.FromArgb(255 - myPen.Color.R, 255 - myPen.Color.G, 255 - myPen.Color.B));
                }
                
                Point[] lineOfResize =
                {
                        new Point(minX-5,minY-5),
                        new Point((minX + maxX) / 2, minY - 5),
                        new Point(maxX + 5,minY - 5),
                        new Point(maxX + 5,(minY + maxY) / 2 - 5),
                        new Point(maxX + 5, maxY + 5),
                        new Point((minX + maxX) / 2,maxY + 5),
                        new Point(minX - 5,maxY + 5),
                        new Point(minX - 5, (minY + maxY) / 2)
                };
                RectangleF[] resizePoints = new RectangleF[lPoint.Count];
                for (int i = 0; i < lPoint.Count; i++)
                {
                    resizePoints[i] = new RectangleF(lPoint[i].X - 5, lPoint[i].Y - 5, 10, 10);
                }
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                gp.DrawPolygon(PenOfLineResize, lineOfResize);
                gp.FillRectangles(myBrush, resizePoints);
                lPointsResize = lineOfResize.ToList();
            }
        }

        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            Point point = new Point(lPoint[pos].X + deltaX, lPoint[pos].Y + deltaY);
            lPoint[pos] = point;
        }

        public override int getPosZoom(int mouseDownX, int mouseDownY)
        {
            for (int i = 0; i < lPoint.Count(); i++)
            {
                if (mouseDownX >= lPoint[i].X - 10 && mouseDownX <= lPoint[i].X + 10 && mouseDownY >= lPoint[i].Y - 10 && mouseDownY <= lPoint[i].Y + 10)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

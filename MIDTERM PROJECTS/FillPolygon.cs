using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDTERM_PROJECTS
{
    public class FillPolygon: Graphic
    {
        public List<Point> lPoint;
        public Color myColor;
        public List<Point> lPointsResize = new List<Point>();
        public int minX, maxX, minY, maxY;
        public FillPolygon(List<Point> lPoint, Color myColor)
        {
            this.lPoint = lPoint;
            this.myColor = myColor;
        }
        public override void Move(int deltaX, int deltaY)
        {
            for (int i = 0; i < lPoint.Count; i++)
            {
                Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                lPoint[i] = p;
            }
           
        }
        public override void Draw(bool isSelected, PaintEventArgs e)
        {
            Brush myBrush = new SolidBrush(myColor);
            Point[] arrPoint = lPoint.ToArray();
            e.Graphics.FillPolygon(myBrush, arrPoint);
            int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
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
                
                RectangleF[] rectangles = new RectangleF[8];
                if (myColor.Equals(Color.Black) || myColor.Equals(Color.White))
                {
                    myBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    myBrush = new SolidBrush(Color.FromArgb(255 - myColor.R, 255 - myColor.G, 255 - myColor.B));
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
                e.Graphics.DrawPolygon(PenOfLineResize, lineOfResize);
                e.Graphics.FillRectangles(myBrush, resizePoints);


            }
        }

        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            if (pos >= 10)
            {
                Point point = new Point(lPoint[pos - 10].X + deltaX, lPoint[pos - 10].Y + deltaY);
                lPoint[pos - 10] = point;
            }
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

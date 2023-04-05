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
        public override void Draw(Graphics gp, bool isSelected)
        {
            Brush myBrush = new SolidBrush(myColor);
            Point[] arrPoint = lPoint.ToArray();
            gp.FillPolygon(myBrush, arrPoint);
            if (isSelected)
            {
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
                RectangleF[] resizePoints =
                {
                    new RectangleF(lineOfResize[0].X - 5,lineOfResize[0].Y - 5,10,10),
                    new RectangleF(lineOfResize[1].X ,lineOfResize[1].Y - 5,10,10),
                    new RectangleF(lineOfResize[2].X -5,lineOfResize[2].Y -5,10,10),
                    new RectangleF(lineOfResize[3].X - 5, lineOfResize[3].Y ,10,10),
                    new RectangleF(lineOfResize[4].X -5,lineOfResize[4].Y - 5,10,10),
                    new RectangleF(lineOfResize[5].X ,lineOfResize[5].Y - 5,10,10),
                    new RectangleF(lineOfResize[6].X - 5,lineOfResize[6].Y - 5,10,10),
                    new RectangleF(lineOfResize[7].X - 5,lineOfResize[7].Y ,10,10)

                };
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                gp.DrawPolygon(PenOfLineResize, lineOfResize);
                gp.FillRectangles(myBrush, resizePoints);


            }
        }
    }
}

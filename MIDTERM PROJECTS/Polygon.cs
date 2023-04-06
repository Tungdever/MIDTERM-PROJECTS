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
        public int minX, maxX, minY, maxY;
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
        }
        public override void Draw(Graphics gp, bool isSelected)
        {            
            gp.DrawPolygon(myPen, lPoint.ToArray());
            if (isSelected)
            {
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
                lPointsResize = lineOfResize.ToList();
            }
        }

        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            switch (pos)
            {
                case 0:
                    break;
                case 1:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == maxX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                            
                        }
                        else if (lPoint[i].Y == maxY)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == minX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }         
                        else if (lPoint[i].X == maxX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                        else if (lPoint[i].Y == maxY)
                        {
                            continue;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == minX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                        else if (lPoint[i].Y == maxY)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == maxX)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y );
                            lPoint[i] = p;
                        }
                        else if (lPoint[i].Y == minY)
                        {
                            continue;
                        }
                        else if (lPoint[i].X == minX)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == minX)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;

                        }
                        else if (lPoint[i].Y == minY)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].Y == minY)
                        {
                            continue;
                        }
                        else if (lPoint[i].X == minX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                        else if (lPoint[i].X == maxX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].Y == minY)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;

                        }
                        else if (lPoint[i].X == maxX)
                        {
                            Point p = new Point(lPoint[i].X, lPoint[i].Y + deltaY );
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < lPoint.Count; i++)
                    {
                        if (lPoint[i].X == minY)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;
                        }
                        else if (lPoint[i].X == maxX)
                        {
                            continue;
                        }
                        else if (lPoint[i].Y == maxY)
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y);
                            lPoint[i] = p;
                        }
                        else
                        {
                            Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                            lPoint[i] = p;
                        }
                    }
                    break;
                case 9:
                    break;
                default:
                    break;
            }
        }

        public override int getPosZoom(int mouseDownX, int mouseDownY)
        {
            for (int i = 0; i < lPointsResize.Count(); i++)
            {
                if (mouseDownX >= lPointsResize[i].X - 10 && mouseDownX <= lPointsResize[i].X + 10 && mouseDownY >= lPointsResize[i].Y - 10 && mouseDownY <= lPointsResize[i].Y + 10)
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}

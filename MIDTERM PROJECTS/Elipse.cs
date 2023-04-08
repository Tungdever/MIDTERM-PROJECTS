using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Elipse : Graphic
    {
        public Pen myPen;
        public List<Point> lPoints = new List<Point>();
        public Elipse(Pen myPen)
        {          
            this.myPen = myPen;
        }
        public PointF center = new PointF();
        public float a, b;
        public override void Draw(Graphics gp, bool isSelected)
        {
            RectangleF myRectangleF = new RectangleF();
            float centerX = (p1.X + p2.X) / 2;
            float centerY = (p1.Y + p2.Y) / 2;
            center.X = centerX;
            center.Y = centerY;
            if (p2.Y >= p1.Y)
            {
                if (p2.X > p1.X) myRectangleF = new RectangleF(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                else
                {
                    myRectangleF = new RectangleF(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
                }               
            }
            else if (p2.Y < p1.Y)
            {
                if (p2.X > p1.X) myRectangleF = new RectangleF(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
                else
                {
                    myRectangleF = new RectangleF(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
                }           
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(myRectangleF);
            RectangleF bounds = path.GetBounds();
            a = bounds.Width / 2;
            b = bounds.Height / 2;
            gp.DrawEllipse(this.myPen, myRectangleF);
            minX = (int)myRectangleF.Left;
            maxX = (int)myRectangleF.Right;
            minY = (int)myRectangleF.Top;
            maxY = (int)myRectangleF.Bottom;
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
                RectangleF[] resizePoints = new RectangleF[8];
                resizePoints[0] = new RectangleF(myRectangleF.Left - 5, myRectangleF.Top - 5  , 10, 10);           // Top-left
                resizePoints[1] = new RectangleF((int)(myRectangleF.Left + myRectangleF.Right) / 2 - 5, myRectangleF.Top - 5, 10, 10);   // Top-center
                resizePoints[2] = new RectangleF(myRectangleF.Right - 5, myRectangleF.Top - 5 , 10, 10);     // Top-right
                resizePoints[3] = new RectangleF(myRectangleF.Right - 5, (myRectangleF.Top + myRectangleF.Height / 2) - 5, 10, 10);   // Middle-right
                resizePoints[4] = new RectangleF(myRectangleF.Right - 5, myRectangleF.Bottom - 5, 10, 10);     // Bottom-right
                resizePoints[5] = new RectangleF((int)(myRectangleF.Left + myRectangleF.Right) / 2 - 5, myRectangleF.Bottom - 5, 10, 10);   // Bottom-center
                resizePoints[6] = new RectangleF(myRectangleF.Left - 5, myRectangleF.Bottom - 5, 10, 10);           // Bottom-left
                resizePoints[7] = new RectangleF(myRectangleF.Left - 5, (myRectangleF.Top + myRectangleF.Height / 2) - 5, 10, 10);        // Middle-left
                gp.FillRectangles(myBrush, resizePoints);
                Point[] lineOfResize = new Point[8];
                lineOfResize[0] = new Point((int)myRectangleF.Left, (int)myRectangleF.Top);
                lineOfResize[1] = new Point((int)((myRectangleF.Left + myRectangleF.Right) / 2), (int)myRectangleF.Top);
                lineOfResize[2] = new Point((int)myRectangleF.Right, (int)myRectangleF.Top);
                lineOfResize[3] = new Point((int)myRectangleF.Right, (int)(myRectangleF.Top + myRectangleF.Height / 2));
                lineOfResize[4] = new Point((int)myRectangleF.Right, (int)myRectangleF.Bottom);
                lineOfResize[5] = new Point((int)(myRectangleF.Left + myRectangleF.Right) / 2, (int)myRectangleF.Bottom);
                lineOfResize[6] = new Point((int)myRectangleF.Left, (int)myRectangleF.Bottom);
                lineOfResize[7] = new Point((int)myRectangleF.Left, (int)(myRectangleF.Top + myRectangleF.Height / 2));
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                
                gp.DrawPolygon(PenOfLineResize, lineOfResize);
                lPoints = lineOfResize.ToList();
            }
        }

        public override int getPosZoom(int mouseDownX, int mouseDownY)
        {
            for (int i = 0; i < lPoints.Count(); i++)
            {
                if (mouseDownX >= lPoints[i].X - 10 && mouseDownX <= lPoints[i].X + 10 && mouseDownY >= lPoints[i].Y - 10 && mouseDownY <= lPoints[i].Y + 10)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public override void Move(int deltaX, int deltaY)
        {
            p1.X += deltaX;
            p1.Y += deltaY;
            p2.X += deltaX;
            p2.Y += deltaY;

        }

        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            switch (pos)
            {
                case 0:
                    break;
                case 1:
                    p1.X += deltaX;
                    p1.Y += deltaY;
                    break;
                case 2:
                    p1.Y += deltaY;
                    break;
                case 3:
                    p1.Y += deltaY;
                    p2.X += deltaX;
                    break;
                case 4:
                    p2.X += deltaX;
                    break;
                case 5:
                    p2.X += deltaX;
                    p2.Y += deltaY;
                    break;
                case 6:
                    p2.Y += deltaY;
                    break;
                case 7:
                    p1.X += deltaX;
                    p2.Y += deltaY;
                    break;
                case 8:
                    p1.X += deltaX;
                    break;
                case 9:
                    break;
                default:
                    break;
            }
        }
    }
}

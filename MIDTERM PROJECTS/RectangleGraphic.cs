using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MIDTERM_PROJECTS
{
    public class RectangleGraphic : Graphic
    {
        public Pen myPen;
        Rectangle myRectangle;
        public RectangleGraphic(Pen myPen)
        {
            this.myPen = myPen;
        }
        public List<Point> lPoints = new List<Point>();
        public override void Draw(bool isSelected, PaintEventArgs e)
        {
            if (p2.Y >= p1.Y) 
            {
                if (p2.X> p1.X) myRectangle = new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                else
                {
                    myRectangle = new Rectangle(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
                    
                }
                e.Graphics.DrawRectangle(myPen, myRectangle);
            }
            else if (p2.Y< p1.Y) 
            {
                if (p2.X > p1.X) myRectangle = myRectangle = new Rectangle(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
                else
                {
                    myRectangle = new Rectangle(p2.X,p2.Y, p1.X - p2.X , p1.Y - p2.Y);
                }
                e.Graphics.DrawRectangle(myPen, myRectangle);
            }
            minX = myRectangle.Left;
            minY = myRectangle.Top;
            maxX = myRectangle.Right;
            maxY = myRectangle.Bottom;
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
                
                Point[] resizePoints = new Point[8];
                resizePoints[0] = new Point(myRectangle.X, myRectangle.Y);  // Top-left
                rectangles[0] = new RectangleF(resizePoints[0].X - 5, resizePoints[0].Y - 5, 10, 10);
                resizePoints[1] = new Point(myRectangle.X + myRectangle.Width / 2, myRectangle.Y);  // Top-center
                rectangles[1] = new RectangleF(resizePoints[1].X - 5, resizePoints[1].Y - 5, 10, 10);
                resizePoints[2] = new Point(myRectangle.Right, myRectangle.Y);  // Top-right
                rectangles[2] = new RectangleF(resizePoints[2].X - 5, resizePoints[2].Y - 5, 10, 10);          
                resizePoints[3] = new Point(myRectangle.Right, myRectangle.Y + myRectangle.Height / 2); // Middle-right
                rectangles[3] = new RectangleF(resizePoints[3].X - 5, resizePoints[3].Y - 5 , 10, 10);
                resizePoints[4] = new Point(myRectangle.Right, myRectangle.Bottom); // Bottom-right
                rectangles[4] = new RectangleF(resizePoints[4].X - 5, resizePoints[4].Y - 5, 10, 10);
                resizePoints[5] = new Point(myRectangle.X + myRectangle.Width / 2, myRectangle.Bottom);   // Bottom-center
                rectangles[5] = new RectangleF(resizePoints[5].X - 5, resizePoints[5].Y - 5, 10, 10);
                resizePoints[6] = new Point(myRectangle.X, myRectangle.Bottom);     // Bottom-left
                rectangles[6] = new RectangleF(resizePoints[6].X - 5, resizePoints[6].Y - 5, 10, 10);
                resizePoints[7] = new Point(myRectangle.X, myRectangle.Y + myRectangle.Height / 2); // Middle-left
                rectangles[7] = new RectangleF(resizePoints[7].X - 5, resizePoints[7].Y - 5, 10, 10);
                e.Graphics.FillRectangles(myBrush, rectangles);
                lPoints = resizePoints.ToList();                             
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

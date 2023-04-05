using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override void Draw(Graphics gp, bool isSelected)
        {
            if (p2.Y >= p1.Y) 
            {
                if (p2.X> p1.X) myRectangle = new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                else
                {
                    myRectangle = new Rectangle(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
                    
                }
                gp.DrawRectangle(myPen, myRectangle);
            }
            else if (p2.Y< p1.Y) 
            {
                if (p2.X > p1.X) myRectangle = myRectangle = new Rectangle(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
                else
                {
                    myRectangle = new Rectangle(p2.X,p2.Y, p1.X - p2.X , p1.Y - p2.Y);
                }
                gp.DrawRectangle(myPen, myRectangle);
            }
            if (isSelected)
            {
                Rectangle[] rectangles = new Rectangle[8];
                Brush myBrush = new SolidBrush(Color.FromArgb(255 - myPen.Color.R, 255 - myPen.Color.G, 255 - myPen.Color.B));
                Point[] resizePoints = new Point[8];
                resizePoints[0] = new Point(myRectangle.X, myRectangle.Y);
                rectangles[0] = new Rectangle(resizePoints[0].X - 2, resizePoints[0].Y - 2, 5, 5);
                resizePoints[1] = new Point(myRectangle.X + myRectangle.Width / 2, myRectangle.Y);
                rectangles[1] = new Rectangle(resizePoints[1].X , resizePoints[1].Y -2, 5, 5);
                resizePoints[2] = new Point(myRectangle.Right, myRectangle.Y);
                rectangles[2] = new Rectangle(resizePoints[2].X-2, resizePoints[2].Y - 2, 5, 5);          
                resizePoints[3] = new Point(myRectangle.Right, myRectangle.Y + myRectangle.Height / 2);
                rectangles[3] = new Rectangle(resizePoints[3].X -2, resizePoints[3].Y , 5, 5);
                resizePoints[4] = new Point(myRectangle.Right, myRectangle.Bottom);
                rectangles[4] = new Rectangle(resizePoints[4].X - 2, resizePoints[4].Y - 2, 5, 5);
                resizePoints[5] = new Point(myRectangle.X + myRectangle.Width / 2, myRectangle.Bottom);
                rectangles[5] = new Rectangle(resizePoints[5].X , resizePoints[5].Y -2, 5, 5);
                resizePoints[6] = new Point(myRectangle.X, myRectangle.Bottom);
                rectangles[6] = new Rectangle(resizePoints[6].X - 2, resizePoints[6].Y - 2, 5, 5);
                resizePoints[7] = new Point(myRectangle.X, myRectangle.Y + myRectangle.Height / 2);
                rectangles[7] = new Rectangle(resizePoints[7].X - 2, resizePoints[7].Y - 2, 5, 5);
                gp.FillRectangles(myBrush, rectangles);

            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            p1.X += deltaX;
            p1.Y += deltaY;
            p2.X += deltaX;
            p2.Y += deltaY;
        }
    }
}

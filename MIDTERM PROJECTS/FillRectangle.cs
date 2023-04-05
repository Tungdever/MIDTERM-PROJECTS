using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class FillRectangle : Graphic
    {
        public Color myColor;
        RectangleF myRectangleF;
        public FillRectangle(Color myColor)
        {
            this.myColor = myColor;
            
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            Brush myBrush = new SolidBrush(myColor);
            if (p2.Y >= p1.Y)
            {
                if (p2.X > p1.X) myRectangleF = new RectangleF(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                else
                {
                    myRectangleF = new RectangleF(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
                }
                gp.FillRectangle(myBrush, myRectangleF);
            }
            else if (p2.Y < p1.Y)
            {
                if (p2.X > p1.X) myRectangleF = new RectangleF(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
                else
                {
                    myRectangleF = new RectangleF(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
                }
                gp.FillRectangle(myBrush, myRectangleF);
            }
            if (isSelected)
            {
                myBrush = new SolidBrush(Color.FromArgb(255 - myColor.R, 255 - myColor.G, 255 - myColor.B));
                RectangleF[] rectangles = new RectangleF[8];                
                Point[] resizePoints = new Point[8];
                resizePoints[0] = new Point((int)myRectangleF.X, (int)myRectangleF.Y);
                rectangles[0] = new RectangleF(resizePoints[0].X - 5, resizePoints[0].Y - 5, 10, 10);
                resizePoints[1] = new Point((int)myRectangleF.X + (int)myRectangleF.Width / 2, (int)myRectangleF.Y);
                rectangles[1] = new RectangleF(resizePoints[1].X, resizePoints[1].Y - 5, 10, 10);
                resizePoints[2] = new Point((int)myRectangleF.Right, (int)myRectangleF.Y);
                rectangles[2] = new RectangleF(resizePoints[2].X - 5, resizePoints[2].Y - 5, 10, 10);
                resizePoints[3] = new Point((int)myRectangleF.Right, (int)myRectangleF.Y + (int)myRectangleF.Height / 2);
                rectangles[3] = new RectangleF(resizePoints[3].X - 5, resizePoints[3].Y, 10, 10);
                resizePoints[4] = new Point((int)myRectangleF.Right, (int)myRectangleF.Bottom);
                rectangles[4] = new RectangleF(resizePoints[4].X - 5, resizePoints[4].Y - 5, 10, 10);
                resizePoints[5] = new Point((int)myRectangleF.X + (int)myRectangleF.Width / 2, (int)myRectangleF.Bottom);
                rectangles[5] = new RectangleF(resizePoints[5].X, resizePoints[5].Y - 5, 10, 10);
                resizePoints[6] = new Point((int)myRectangleF.X, (int)myRectangleF.Bottom);
                rectangles[6] = new RectangleF(resizePoints[6].X - 5, resizePoints[6].Y - 5, 10, 10);
                resizePoints[7] = new Point((int)myRectangleF.X, (int)myRectangleF.Y + (int)myRectangleF.Height / 2);
                rectangles[7] = new RectangleF(resizePoints[7].X - 5, resizePoints[7].Y - 5, 10, 10);
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

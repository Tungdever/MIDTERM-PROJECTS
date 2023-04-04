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
        public Brush myBrush;
        public FillRectangle(Brush myBrush)
        {
            this.myBrush = myBrush;
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            RectangleF myRectangleF;
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
                    myRectangleF = new Rectangle(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
                }
                gp.FillRectangle(myBrush, myRectangleF);
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

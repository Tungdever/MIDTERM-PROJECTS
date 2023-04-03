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
        public Point p1;
        public Point p2;
        public Pen myPen;
        public RectangleGraphic(Pen myPen, Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.myPen = myPen;
        }
        public override void Draw(Graphics gp)
        {
            Rectangle myRectangle = new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            gp.DrawRectangle(myPen, myRectangle);
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

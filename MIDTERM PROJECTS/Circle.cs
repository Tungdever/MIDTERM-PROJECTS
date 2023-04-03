using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Circle : Graphic
    {
        public Pen myPen;
        public Circle(Pen myPen)
        {
            this.myPen = myPen;
        }
        public override void Draw(Graphics gp)
        {
            double rad = Form1.DistanceTo(p1, p2);
            gp.DrawEllipse(myPen, p1.X, p1.Y, (int)rad, (int)rad);
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

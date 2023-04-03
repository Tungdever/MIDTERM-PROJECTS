using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Line : Graphic
    {
        public Point p1;
        public Point p2;
        public Pen myPen;
        public Line(Point p1, Point p2, Pen myPen)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.myPen = myPen;
        }
        
        public override void Draw(Graphics gp)
        {
            gp.DrawLine(myPen, p1, p2);   
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

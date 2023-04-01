using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Line
    {
        public Point p1;
        public Point p2;
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public void draw(Graphics gp, Pen myPen)
        {
            gp.DrawLine(myPen, p1, p2);   
        }
    }
}

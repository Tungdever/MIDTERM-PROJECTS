using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Elipse
    {
        public Point p1;
        public Point p2;
        public Pen myPen;
        public Elipse(Pen myPen, Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.myPen = myPen;
        }
        public void draw(Graphics gp)
        {
            RectangleF myRectangleF = new RectangleF(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            gp.DrawEllipse(myPen, myRectangleF);
        }
    }
}

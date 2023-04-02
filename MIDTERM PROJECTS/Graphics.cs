using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Graphics : Line, Elipse
    {
        Point[] arrPoly;
        Point p1, p2;
        Pen myPen;
        public void drawElipse(Graphics gp)
        {
            RectangleF myRectangleF = new RectangleF(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            gp.DrawEllipse(myPen, myRectangleF);
        }

        public void DrawLine(Graphics gp)
        {
            gp.DrawLine(myPen, p1, p2);
        }
    }
}

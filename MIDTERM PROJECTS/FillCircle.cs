using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class FillCircle : Graphic
    {
        public Point p1;
        public Point p2;
        public Brush myBrush;
        public FillCircle(Brush myBrush, Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.myBrush = myBrush;
        }
        public override void Draw(Graphics gp)
        {
            double rad = Form1.DistanceTo(p1, p2);
            gp.FillEllipse(myBrush, p1.X, p1.Y, (int)rad, (int)rad);
        }
    }
}

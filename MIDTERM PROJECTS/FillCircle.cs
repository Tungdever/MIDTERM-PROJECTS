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

        public Brush myBrush;
        public FillCircle(Brush myBrush)
        {
            this.myBrush = myBrush;
        }
        public override void Draw(Graphics gp)
        {
            double rad = Form1.DistanceTo(p1, p2);
            gp.FillEllipse(myBrush, p1.X, p1.Y, (int)rad, (int)rad);
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Arc : Graphic
    {
        public Pen myPen;
        public Arc(Pen myPen)
        {
            this.myPen = myPen;
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            int centerX = p1.X;
            int centerY = p1.Y;
            int radius = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            int startAngle = (int)(Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * 180 / Math.PI);       
            try
            {
                gp.DrawArc(myPen, centerX - radius, centerY - radius, radius * 2, radius * 2, startAngle, 90);
            }
            catch 
            { 
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

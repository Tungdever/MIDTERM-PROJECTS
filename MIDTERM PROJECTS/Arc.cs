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
            int centerX = (p1.X + p2.X) / 2;
            int centerY = (p1.Y + p2.Y) / 2;
            int radius = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2;
            double startAngle = Math.Atan2(p1.Y - centerY, p1.X - centerX) * 180 / Math.PI;
            double endAngle = Math.Atan2(p2.Y - centerY, p2.X - centerX) * 180 / Math.PI;
            try
            {
                gp.DrawArc(myPen, centerX - radius, centerY - radius, radius * 2, radius * 2, (float)startAngle, (float)(endAngle - startAngle));
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

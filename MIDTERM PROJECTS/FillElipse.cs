using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class FillElipse : Graphic
    {
        public Brush myBrush;
        public FillElipse(Brush myBrush)
        {
            this.myBrush = myBrush;
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            RectangleF myRectangleF = new RectangleF(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
            gp.FillEllipse(myBrush, myRectangleF);
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

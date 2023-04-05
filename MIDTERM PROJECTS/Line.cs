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
        
        public Pen myPen;
        
        public Line(Pen myPen) 
        {
    
            this.myPen = myPen;
            
        }
 
        public override void Draw(Graphics gp, bool isSelected)
        {
            gp.DrawLine(myPen, p1, p2);
            Brush myBrush = new SolidBrush(Color.Blue);
            if (isSelected)
            {
                gp.FillEllipse(myBrush, p1.X - 2, p1.Y - 7, 13, 13);
                gp.FillEllipse(myBrush, p2.X - 2, p2.Y - 7, 13, 13);
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

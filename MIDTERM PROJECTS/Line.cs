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
            
            if (isSelected)
            {
                Brush myBrush;
                RectangleF[] rectangles = new RectangleF[8];
                if (myPen.Color.Equals(Color.Black) || myPen.Color.Equals(Color.White))
                {
                    myBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    myBrush = new SolidBrush(Color.FromArgb(255 - myPen.Color.R, 255 - myPen.Color.G, 255 - myPen.Color.B));
                }
                rectangles[0] = new RectangleF(p1.X - 5, p1.Y - 5, 10, 10);
                rectangles[1] = new RectangleF(p2.X - 5, p2.Y - 5, 10, 10);
                gp.FillRectangles(myBrush, rectangles);

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

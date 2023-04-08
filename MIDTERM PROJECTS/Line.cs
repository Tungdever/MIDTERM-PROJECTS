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
            minX = Math.Min(p1.X, p2.X);
            maxX = Math.Max(p1.X, p2.X);
            minY = Math.Min (p1.Y, p2.Y);
            maxY = Math.Max(p1.Y, p2.Y);
            if (isSelected)
            {
                Brush myBrush;
                RectangleF[] rectangles = new RectangleF[2];
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

        public override int getPosZoom(int mouseDownX, int mouseDownY)
        {
            if (mouseDownX >= p1.X - 10 && mouseDownX <= p1.X + 10 && mouseDownY >= p1.Y - 10 && mouseDownY <= p1.Y + 10) 
            {
                return 0;
            }
            else if (mouseDownX >= p2.X - 10 && mouseDownX <= p2.X + 10 && mouseDownY >= p2.Y - 10 && mouseDownY <= p2.Y + 10)
            {
                return 9;
            }
            return -1;
        }

        public override void Move(int deltaX, int deltaY)
        {
            p1.X += deltaX;
            p1.Y += deltaY;
            p2.X += deltaX;
            p2.Y += deltaY;
         
        }
        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            switch (pos)
            {
                case 0:
                    p1.X += deltaX;
                    p1.Y += deltaY;
                    break;
                case 1:
                    p1.X += deltaX;
                    p1.Y += deltaY;
                    break;
                case 2:
                    p1.Y += deltaY;
                    break;
                case 3:
                    p1.Y += deltaY;
                    p2.X += deltaX;
                    break;
                case 4:
                    p2.X += deltaX;
                    break;
                case 5:
                    p2.X += deltaX;
                    p2.Y += deltaY;
                    break;
                case 6:
                    p2.Y += deltaY;
                    break;
                case 7:
                    p1.X += deltaX;
                    p2.Y += deltaY;
                    break;
                case 8:
                    p1.X += deltaX;
                    break;
                case 9:
                    p2.X += deltaX;
                    p2.Y += deltaY;
                    break;
                default:
                    break;
            }
        }
    }
}

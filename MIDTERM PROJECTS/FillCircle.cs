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

        public Color myColor;
        public FillCircle(Color myColor)
        {
            this.myColor = myColor;
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            Brush myBrush = new SolidBrush(myColor);           
            int centerX = (p1.X + p2.X) / 2;
            int centerY = (p1.Y + p2.Y) / 2;
            int radius = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2;
            gp.FillEllipse(myBrush, centerX - radius, centerY - radius, radius * 2, radius * 2);
            if (isSelected)
            {
                if (myColor.Equals(Color.Black) || myColor.Equals(Color.White))
                {
                    myBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    myBrush = new SolidBrush(Color.FromArgb(255 - myColor.R, 255 - myColor.G, 255 - myColor.B));
                }
                int x = centerX - radius;
                int y = centerY - radius;
                int size = 2 * radius;
                RectangleF[] resizePoints = new RectangleF[8];
                resizePoints[0] = new RectangleF(x - 5, y - 5, 10, 10);           // Top-left
                resizePoints[1] = new RectangleF(x + radius - 5, y - 5, 10, 10);   // Top-center
                resizePoints[2] = new RectangleF(x + size - 5, y - 5, 10, 10);     // Top-right
                resizePoints[3] = new RectangleF(x + size - 5, y + radius - 5, 10, 10);   // Middle-right
                resizePoints[4] = new RectangleF(x + size - 5, y + size - 5, 10, 10);     // Bottom-right
                resizePoints[5] = new RectangleF(x + radius - 5, y + size - 5, 10, 10);   // Bottom-center
                resizePoints[6] = new RectangleF(x - 5, y + size - 5, 10, 10);           // Bottom-left
                resizePoints[7] = new RectangleF(x - 5, y + radius - 5, 10, 10);        // Middle-left
                gp.FillRectangles(myBrush, resizePoints);
                Point[] lineOfResize = new Point[8];
                lineOfResize[0] = new Point(x, y);
                lineOfResize[1] = new Point(x + radius, y);
                lineOfResize[2] = new Point(x + size, y);
                lineOfResize[3] = new Point(x + size, y + radius);
                lineOfResize[4] = new Point(x + size, y + size);
                lineOfResize[5] = new Point(x + radius, y + size);
                lineOfResize[6] = new Point(x, y + size);
                lineOfResize[7] = new Point(x, y + radius);
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                gp.DrawPolygon(PenOfLineResize, lineOfResize);
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

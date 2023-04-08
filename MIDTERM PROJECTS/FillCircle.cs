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
        public List<Point> lPoints = new List<Point>();
        public Point center = new Point();
        public int radius;
        public override void Draw(Graphics gp, bool isSelected)
        {
            Brush myBrush = new SolidBrush(myColor);
            int centerX = (p1.X + p2.X) / 2;
            int centerY = (p1.Y + p2.Y) / 2;
            center.X = centerX;
            center.Y = centerY;
            radius = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2;
            int x = centerX - radius;
            int y = centerY - radius;
            int size = 2 * radius;
            gp.FillEllipse(myBrush, x, y, size, size);
            minX = x;
            minY = y;
            maxX = x + size;
            maxY = y + size;

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
                lPoints = lineOfResize.ToList();
            }
        }

        public override int getPosZoom(int mouseDownX, int mouseDownY)
        {
            for (int i = 0; i < lPoints.Count(); i++)
            {
                if (mouseDownX >= lPoints[i].X - 10 && mouseDownX <= lPoints[i].X + 10 && mouseDownY >= lPoints[i].Y - 10 && mouseDownY <= lPoints[i].Y + 10)
                {
                    return i + 1;
                }
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
                    break;
                default:
                    break;
            }
        }
    }
}

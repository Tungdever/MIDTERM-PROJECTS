using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MIDTERM_PROJECTS
{
    public class Arc : Graphic
    {
        public Pen myPen;
        public Arc(Pen myPen)
        {
            this.myPen = myPen;
        }
        public List<Point> lPoints = new List<Point>();
        public PointF center = new PointF();
        public float radius;
        public float startAngle;
        public float endAngle;
        public GraphicsPath path;
        private static PointF PointOnEllipse(float cx, float cy, float rx, float ry, float theta)
        {
            float x = (float)(cx + rx * Math.Cos(theta));
            float y = (float)(cy + ry * Math.Sin(theta));
            return new PointF(x, y);
        }
        public override void Draw(bool isSelected, PaintEventArgs e)
        {
            float centerX = (p1.X + p2.X) / 2f;
            float centerY = (p1.Y + p2.Y) / 2f;
            radius = (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2f;
            startAngle = (float)(180 / Math.PI * Math.Atan2(p1.Y - centerY, p1.X - centerX));
            endAngle = (float)(180 / Math.PI * Math.Atan2(p2.Y - centerY, p2.X - centerX));
            try
            {
                e.Graphics.DrawArc(myPen, centerX - radius, centerY - radius, radius * 2f, radius * 2f, startAngle, endAngle);
               
            }
            catch 
            { 
            }
            path = new GraphicsPath();
            path.AddArc(centerX-radius,centerY-radius,radius*2f,radius*2f,startAngle,endAngle);           
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
                float x = centerX - radius;
                float y = centerY - radius;
                float size = 2 * radius;
                RectangleF[] resizePoints = new RectangleF[8];
                resizePoints[0] = new RectangleF(x - 5, y - 5, 10, 10);           // Top-left
                resizePoints[1] = new RectangleF(x + radius - 5, y - 5, 10, 10);   // Top-center
                resizePoints[2] = new RectangleF(x + size - 5, y - 5, 10, 10);     // Top-right
                resizePoints[3] = new RectangleF(x + size - 5, y + radius - 5, 10, 10);   // Middle-right
                resizePoints[4] = new RectangleF(x + size - 5, y + size - 5, 10, 10);     // Bottom-right
                resizePoints[5] = new RectangleF(x + radius - 5, y + size - 5, 10, 10);   // Bottom-center
                resizePoints[6] = new RectangleF(x - 5, y + size - 5, 10, 10);           // Bottom-left
                resizePoints[7] = new RectangleF(x - 5, y + radius - 5, 10, 10);        // Middle-left
                e.Graphics.FillRectangles(myBrush, resizePoints);
                Point[] lineOfResize = new Point[8];
                lineOfResize[0] = new Point((int)x, (int)y);
                lineOfResize[1] = new Point((int)(x + radius), (int)y);
                lineOfResize[2] = new Point((int)(x + size), (int)y);
                lineOfResize[3] = new Point((int)(x + size), (int)(y + radius));
                lineOfResize[4] = new Point((int)(x + size), (int)(y + size));
                lineOfResize[5] = new Point((int)(x + radius), (int)(y + size));
                lineOfResize[6] = new Point((int)x, (int)(y + size));
                lineOfResize[7] = new Point((int)x, (int)(y + radius));
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                e.Graphics.DrawPolygon(PenOfLineResize, lineOfResize);
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

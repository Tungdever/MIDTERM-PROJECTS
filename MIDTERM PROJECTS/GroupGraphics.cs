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
    public class GroupGraphics : Graphic
    {
        public List<Graphic> graphics= new List<Graphic>();
        public List<PointF> lPoints = new List<PointF>();
        
        public override void Draw(bool isSelected, PaintEventArgs e)
        {
            minX = int.MaxValue; maxX = int.MinValue; minY = int.MaxValue; maxY = int.MinValue;
            //MessageBox.Show(this.graphics.Count.ToString());
            foreach (Graphic g in graphics)
            {
                g.Draw(false, e);
                minX = Math.Min(minX, g.minX);
                maxX = Math.Max(maxX, g.maxX);
                minY = Math.Min(minY, g.minY);
                maxY = Math.Max(maxY, g.maxY);
            }
            
            if (isSelected)
            {
                float centerX = (minX + maxX) / 2;
                float centerY = (minY + maxY) / 2;
                Brush myBrush = new SolidBrush(Color.Blue);
                RectangleF[] rectangles = new RectangleF[8];
                RectangleF[] resizePoints = new RectangleF[8];
                resizePoints[0] = new RectangleF(minX - 5, minY - 5, 10, 10);           // Top-left
                resizePoints[1] = new RectangleF(centerX - 5, minY - 5, 10, 10);   // Top-center
                resizePoints[2] = new RectangleF(maxX - 5, minY - 5, 10, 10);     // Top-right
                resizePoints[3] = new RectangleF(maxX - 5 , centerY - 5, 10, 10);   // Middle-right
                resizePoints[4] = new RectangleF(maxX - 5, maxY - 5, 10, 10);     // Bottom-right
                resizePoints[5] = new RectangleF(centerX - 5, maxY - 5, 10, 10);   // Bottom-center
                resizePoints[6] = new RectangleF(minX - 5, maxY - 5, 10, 10);           // Bottom-left
                resizePoints[7] = new RectangleF(minX - 5, centerY - 5, 10, 10);        // Middle-left
                e.Graphics.FillRectangles(myBrush, resizePoints);
                PointF[] lineOfResize = new PointF[8];
                lineOfResize[0] = new PointF(minX, minY);
                lineOfResize[1] = new PointF(centerX, minY);
                lineOfResize[2] = new PointF(maxX, minY);
                lineOfResize[3] = new PointF(maxX, centerY);
                lineOfResize[4] = new PointF(maxX, maxY);
                lineOfResize[5] = new PointF(centerX, maxY);
                lineOfResize[6] = new PointF(minX, maxY);
                lineOfResize[7] = new PointF(minX, centerY);
                Pen PenOfLineResize = new Pen(Color.Black, 1);
                e.Graphics.DrawPolygon(PenOfLineResize, lineOfResize);
                lPoints = lineOfResize.ToList();
            }
        }
        public override void Move(int deltaX, int deltaY)
        {
            foreach (Graphic g in graphics)
            {
                g.Move(deltaX, deltaY);
            }
        }

        public override void Zoom(int pos, int deltaX, int deltaY)
        {
            foreach (Graphic g in graphics)
            {
                g.Zoom(pos, deltaX, deltaY);
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
    }
}

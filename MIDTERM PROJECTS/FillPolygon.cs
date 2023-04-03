using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class FillPolygon: Graphic
    {
        public List<Point> lPoint;
        public Brush myBrush;
        public FillPolygon(List<Point> lPoint, Brush myBrush)
        {
            this.lPoint = lPoint;
            this.myBrush = myBrush;
        }
        public override void Move(int deltaX, int deltaY)
        {
            for (int i = 0; i < lPoint.Count; i++)
            {
                Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                lPoint[i] = p;
            }
        }
        public override void Draw(Graphics gp)
        {
            Point[] arrPoint = lPoint.ToArray();
            gp.FillPolygon(myBrush, arrPoint);
        }
    }
}

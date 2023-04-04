using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public class Polygon :  Graphic
    {
        public List<Point> lPoint;
        public Pen myPen;
        public Polygon(List<Point> lPoint, Pen myPen)
        {
            this.lPoint = lPoint;
            this.myPen = myPen;
            
        }
        public override void Move(int deltaX, int deltaY)
        {
            for (int i = 0; i < lPoint.Count; i++)
            {
                Point p = new Point(lPoint[i].X + deltaX, lPoint[i].Y + deltaY);
                lPoint[i] = p;
            }
        }
        public override void Draw(Graphics gp, bool isSelected)
        {
            Point[] arrPoint = lPoint.ToArray();
            gp.DrawPolygon(myPen, arrPoint);
        }
    }
}

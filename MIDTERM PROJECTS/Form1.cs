using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.LinkLabel;

namespace MIDTERM_PROJECTS
{

    public partial class Form1 : Form
    {
        Graphics gp;
        Pen myPen;
        Color myColor;
        bool isLine = false;
        bool isEllipse = false;
        Point beginPoint = new Point();
        bool isStart = true;
        bool isClickColtrols = false;
        bool isFillElipse = false;
        bool isRectangle = false;
        bool isFillRectangle = false;
        bool isCircle = false;
        bool isFillCircle = false;
        bool isArc = false;
        bool isPolygon = false;
        bool isFillPolygon = false;
        int numSides;
        bool isSelected = false;       
        List<Point> lSides;
        List<Graphic> graphics = new List<Graphic>();
        int ItemSelected;
        int x, y;
        
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public Form1()
        {
            InitializeComponent();
            gp = this.pnlMain.CreateGraphics();
            this.cbbStyle.SelectedIndex = 0;
            this.cbbStyle.Hide();          
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.isLine = true;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;          
            isClickColtrols = true;
        }

        public static double DistanceTo(Point point1, Point point2)
        {
            double deltaX = point2.X - point1.X;
            double deltaY = point2.Y - point1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (isClickColtrols)
            {
                myColor = cldControls.Color;
                myPen = new Pen(myColor, 5);
                myPen.DashStyle = (DashStyle)this.cbbStyle.SelectedItem;

                if (this.isPolygon)
                {
                    Point newPoint = new Point(e.Location.X, e.Location.Y);
                    lSides.Add(newPoint);
                    if (this.lSides.Count == numSides)
                    {

                        Point[] arrPoint = lSides.ToArray();
                        gp.DrawPolygon(myPen, arrPoint);
                        this.isPolygon = false;
                        this.isClickColtrols = false;
                    }
                }
                else if (this.isFillPolygon)
                {
                    Point newPoint = new Point(e.Location.X, e.Location.Y);
                    lSides.Add(newPoint);
                    if (this.lSides.Count == numSides)
                    {
                        Point[] arrPoint = lSides.ToArray();
                        Brush myBrush = new SolidBrush(myColor);
                        gp.FillPolygon(myBrush, arrPoint);
                        this.isFillPolygon = false;
                        this.isClickColtrols = false;

                    }
                }
                else if (this.isStart)
                {
                    this.isStart = false;
                    this.beginPoint.X = e.X;
                    this.beginPoint.Y = e.Y;
                }
                else
                {
                    Point endPoint = new Point();
                    endPoint.X = e.X;
                    endPoint.Y = e.Y;
                    if (endPoint.X < beginPoint.X)
                    {
                        Point tmp = beginPoint;
                        beginPoint = endPoint;
                        endPoint = tmp;
                    }
                    if (this.isLine)
                    {
                        Line newLine = new Line(beginPoint, endPoint, myPen);                       
                        graphics.Add(newLine);
                        graphics[graphics.Count - 1].Draw(gp);                        
                        this.isLine = false;
                    }
                    else if (this.isEllipse)
                    {
                        Elipse newElipse = new Elipse(myPen, beginPoint, endPoint);                        
                        graphics.Add(newElipse);
                        graphics[graphics.Count - 1].Draw(gp);
                        this.isEllipse = false;
                    }
                    else if (this.isFillElipse)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        FillElipse newFillElipse = new FillElipse(myBrush, beginPoint, endPoint);
                        graphics.Add(newFillElipse);
                        graphics[graphics.Count - 1].Draw(gp);
                        this.isFillElipse = false;
                    }
                    else if (this.isRectangle)
                    {
                        RectangleGraphic newRectangle = new RectangleGraphic(myPen, beginPoint, endPoint);
                        graphics.Add(newRectangle);
                        graphics[graphics.Count - 1].Draw(gp);                      
                        this.isRectangle = false;
                    }
                    else if (this.isFillRectangle)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        FillRectangle newFillRectangle = new FillRectangle(myBrush, beginPoint, endPoint);
                        graphics.Add(newFillRectangle);
                        graphics[graphics.Count - 1].Draw(gp);
                        this.isFillRectangle = false;
                    }
                    else if (this.isCircle)
                    {
                        Circle newCircle = new Circle(myPen, beginPoint, endPoint);
                        graphics.Add(newCircle);
                        graphics[graphics.Count - 1].Draw(gp);
                        this.isCircle = false;
                    }
                    else if (this.isFillCircle)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        FillCircle newFillCircle = new FillCircle(myBrush, beginPoint, endPoint);
                        graphics.Add(newFillCircle);
                        graphics[graphics.Count - 1].Draw(gp);                       
                        this.isFillCircle = false;
                    }
                    else if (this.isArc)
                    {
                        int r = (int)Math.Sqrt((endPoint.X - beginPoint.X) * (endPoint.X - beginPoint.X) + (endPoint.Y - beginPoint.Y) * (endPoint.Y - beginPoint.Y));
                        int x = beginPoint.X - r;
                        int y = beginPoint.Y - r;
                        int width = 2 * r;
                        int height = 2 * r;
                        int startAngle = (int)(180 / Math.PI * Math.Atan2(endPoint.Y - beginPoint.Y, endPoint.X - beginPoint.X));
                        int endAngle = (int)(180 / Math.PI * Math.Atan2(endPoint.X - beginPoint.X, endPoint.X - beginPoint.X));
                        gp.DrawArc(myPen, x, y, width, height, startAngle, endAngle);
                        this.isArc = false;
                    }

                    this.isStart = true;
                    this.isClickColtrols = false;

                }
            }
            else
            {
                for (int i = graphics.Count() - 1 ; i >= 0; i--) 
                {
                    if (graphics[i] is Line line)
                    {
                        int x1 = line.p1.X;
                        int x2 = line.p2.X;
                        int y1 = line.p1.Y;
                        int y2 = line.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }                      
                    }
                    else if (graphics[i] is Elipse elipse)
                    {
                        int x1 = elipse.p1.X;
                        int x2 = elipse.p2.X;
                        int y1 = elipse.p1.Y;
                        int y2 = elipse.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is FillElipse fill_elipse)
                    {
                        int x1 = fill_elipse.p1.X;
                        int x2 = fill_elipse.p2.X;
                        int y1 = fill_elipse.p1.Y;
                        int y2 = fill_elipse.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is RectangleGraphic rectangle)
                    {
                        int x1 = rectangle.p1.X;
                        int x2 = rectangle.p2.X;
                        int y1 = rectangle.p1.Y;
                        int y2 = rectangle.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is FillRectangle fill_rectangle)
                    {
                        int x1 = fill_rectangle.p1.X;
                        int x2 = fill_rectangle.p2.X;
                        int y1 = fill_rectangle.p1.Y;
                        int y2 = fill_rectangle.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is Circle circle)
                    {
                        int x1 = circle.p1.X;
                        int x2 = circle.p2.X;
                        int y1 = circle.p1.Y;
                        int y2 = circle.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is FillCircle fill_circle)
                    {
                        int x1 = fill_circle.p1.X;
                        int x2 = fill_circle.p2.X;
                        int y1 = fill_circle.p1.Y;
                        int y2 = fill_circle.p2.Y;
                        if (x1 > x2) Swap(ref x1, ref x2);
                        if (y1 > y2) Swap(ref y1, ref y2);
                        if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }

                }
            }

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
           this.graphics.Clear();           
           Refresh();
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = true;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols=true;
        }

        private void btnFilled_Ellipse_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = true;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
            
        }

        private void btnrectangle_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = true;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
        }

        private void btnFilled_Rectangle_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = true;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
            
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = true;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
        }

        private void btnFilled_Circle_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = true;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
            
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = true;
            this.isPolygon = false;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
        }

        private void btnpPolygon_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of sides:", "Polygon", "5");
            if (!int.TryParse(input, out numSides))
            {
                MessageBox.Show("Invalid input!");
                return;
            }
            if (numSides < 3)
            {
                MessageBox.Show("Invalid input!");
                return;
            }
            lSides = new List<Point>();
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = true;
            this.isFillPolygon = false;
            this.isClickColtrols = true;
        }

        private void btnFilled_Polygon_Click(object sender, EventArgs e)
        {            
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of sides:", "Polygon", "5");
            if (!int.TryParse(input, out numSides))
            {
                MessageBox.Show("Invalid input!");
                return;
            }
            if (numSides < 3)
            {
                MessageBox.Show("Invalid input!");
                return;
            }
            lSides = new List<Point>();
            this.isLine = false;
            this.isEllipse = false;
            this.isFillElipse = false;
            this.isRectangle = false;
            this.isFillRectangle = false;
            this.isCircle = false;
            this.isFillCircle = false;
            this.isArc = false;
            this.isPolygon = false;
            this.isFillPolygon = true;
            this.isClickColtrols = true;
            
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            this.cldControls.ShowDialog();
        }

        private void cldControls_HelpRequest(object sender, EventArgs e)
        {
            if (cldControls.ShowDialog() == DialogResult.OK)
            {
                myColor = cldControls.Color; 
            }
        }
        private void btnStyle_Click(object sender, EventArgs e)
        {
            this.cbbStyle.Show();

        }
        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            this.cbbStyle.Hide(); 
            
        }

        private void pnlControls_Click(object sender, EventArgs e)
        {
            this.cbbStyle.Hide();
            
        }
        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelected)
            {
                int deltaX = e.X - x;
                int deltaY = e.Y - y;
                if (graphics[ItemSelected] is Line lineObject)
                {
                    lineObject.p1.X += deltaX;
                    lineObject.p1.Y += deltaY;
                    lineObject.p2.X += deltaX;
                    lineObject.p2.Y += deltaY;
                }
             
                else if (graphics[ItemSelected] is Elipse elipseObject)
                {
                    elipseObject.p1.X += deltaX;
                    elipseObject.p1.Y += deltaY;
                    elipseObject.p2.X += deltaX;
                    elipseObject.p2.Y += deltaY;
                }
                else if (graphics[ItemSelected] is FillElipse fillElipseObject)
                {
                    fillElipseObject.p1.X += deltaX;
                    fillElipseObject.p1.Y += deltaY;
                    fillElipseObject.p2.X += deltaX;
                    fillElipseObject.p2.Y += deltaY;
                }
                else if (graphics[ItemSelected] is RectangleGraphic rectangleObject)
                {
                    rectangleObject.p1.X += deltaX;
                    rectangleObject.p1.Y += deltaY;
                    rectangleObject.p2.X += deltaX;
                    rectangleObject.p2.Y += deltaY;
                }
                else if (graphics[ItemSelected] is FillRectangle fillRectangleObject)
                {
                    fillRectangleObject.p1.X += deltaX;
                    fillRectangleObject.p1.Y += deltaY;
                    fillRectangleObject.p2.X += deltaX;
                    fillRectangleObject.p2.Y += deltaY;
                }
                else if (graphics[ItemSelected] is Circle circleObject)
                {
                    circleObject.p1.X += deltaX;
                    circleObject.p1.Y += deltaY;
                    circleObject.p2.X += deltaX;
                    circleObject.p2.Y += deltaY;
                }
                else if (graphics[ItemSelected] is FillCircle fillCircleObject)
                {
                    fillCircleObject.p1.X += deltaX;
                    fillCircleObject.p1.Y += deltaY;
                    fillCircleObject.p2.X += deltaX;
                    fillCircleObject.p2.Y += deltaY;
                }
                    x = e.X; y = e.Y;
                Refresh(); 
            }
        }
        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            foreach (Graphic graphic in graphics)
            {
                graphic.Draw(gp);
            }
        }
    }
}

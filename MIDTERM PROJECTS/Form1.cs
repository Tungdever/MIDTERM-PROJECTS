﻿using System;
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
        Color myColor;
        bool isLine = false;
        bool isEllipse = false;
        Point beginPoint = new Point();
        bool isPress = false;
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
        bool isSolid = true;
        bool isDash = false;
        bool isDot = false;
        bool isDashDot = false;
        bool isDashDotDot = false;
        List<Point> lSides;
        List<Graphic> graphics = new List<Graphic>();
        int ItemSelected;
        int posSelected = -1;
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
                Pen myPen = new Pen(myColor, 5);
                if (isSolid) myPen.DashStyle = DashStyle.Solid;
                else if (isDash) myPen.DashStyle = DashStyle.Dash;
                else if (isDot) myPen.DashStyle = DashStyle.Dot;
                else if (isDashDot) myPen.DashStyle = DashStyle.DashDot;
                else if (isDashDotDot) myPen.DashStyle|= DashStyle.DashDotDot;
                if (this.isPolygon)
                {
                    Point newPoint = new Point(e.Location.X, e.Location.Y);
                    lSides.Add(newPoint);
                    if (this.lSides.Count == numSides)
                    {
                        Polygon newPolygon = new Polygon(lSides, myPen);
                        graphics.Add(newPolygon);
                        graphics[graphics.Count - 1].Draw(gp);
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
                        Brush myBrush = new SolidBrush(myColor);
                        FillPolygon newFillPolygon = new FillPolygon(lSides, myBrush);
                        graphics.Add(newFillPolygon);
                        graphics[graphics.Count - 1].Draw(gp);
                        this.isFillPolygon = false;
                        this.isClickColtrols = false;
                    }
                }                
                else
                {
                    //Point endPoint = new Point();
                    //endPoint.X = e.X;
                    //endPoint.Y = e.Y;
                    //if (endPoint.X < beginPoint.X)
                    //{
                    //    Point tmp = beginPoint;
                    //    beginPoint = endPoint;
                    //    endPoint = tmp;
                    //}
                    isPress = true;
                    if (this.isLine)
                    {
                        Graphic newLine = new Line(myPen);
                        newLine.p1 = e.Location;
                        graphics.Add(newLine);                          
                    }
                    else if (this.isEllipse)
                    {
                        Graphic newElipse = new Elipse(myPen);
                        newElipse.p1 = e.Location;
                        graphics.Add(newElipse);                        
                    }
                    else if (this.isFillElipse)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        Graphic newFillElipse = new FillElipse(myBrush);
                        newFillElipse.p1 = e.Location;
                        graphics.Add(newFillElipse);
                        
                    }
                    else if (this.isRectangle)
                    {
                        Graphic newRectangle = new RectangleGraphic(myPen);
                        newRectangle.p1 = e.Location;
                        graphics.Add(newRectangle);
                        
                    }
                    else if (this.isFillRectangle)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        Graphic newFillRectangle = new FillRectangle(myBrush);
                        newFillRectangle.p1 = e.Location;
                        graphics.Add(newFillRectangle);                       
                    }
                    else if (this.isCircle)
                    {
                        Graphic newCircle = new Circle(myPen);
                        newCircle.p1 = e.Location;
                        graphics.Add(newCircle);
                        
                    }
                    else if (this.isFillCircle)
                    {
                        Brush myBrush = new SolidBrush(myColor);
                        Graphic newFillCircle = new FillCircle(myBrush);
                        newFillCircle.p1 = e.Location;
                        graphics.Add(newFillCircle);
                       
                    }
                    //else if (this.isArc)
                    //{
                    //    int r = (int)Math.Sqrt((endPoint.X - beginPoint.X) * (endPoint.X - beginPoint.X) + (endPoint.Y - beginPoint.Y) * (endPoint.Y - beginPoint.Y));
                    //    int x = beginPoint.X - r;
                    //    int y = beginPoint.Y - r;
                    //    int width = 2 * r;
                    //    int height = 2 * r;
                    //    int startAngle = (int)(180 / Math.PI * Math.Atan2(endPoint.Y - beginPoint.Y, endPoint.X - beginPoint.X));
                    //    int endAngle = (int)(180 / Math.PI * Math.Atan2(endPoint.X - beginPoint.X, endPoint.X - beginPoint.X));
                    //    gp.DrawArc(myPen, x, y, width, height, startAngle, endAngle);
                    //    this.isArc = false;
                    //}
                }
            }
            else
            {
                for (int i = graphics.Count() - 1 ; i >= 0; i--) 
                {
                    if (graphics[i] is Line line)
                    {

                        if (e.X >= line.p1.X - 10 && e.X <= line.p1.X + 10 && e.Y >= line.p1.Y - 10 && e.Y <= line.p1.Y + 10)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            posSelected = 0;
                            x = e.X; y = e.Y;
                            break;
                        }
                        else if (e.X >= line.p2.X - 10 && e.X <= line.p2.X + 10 && e.Y >= line.p2.Y - 10 && e.Y <= line.p2.Y + 10)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            posSelected = 1;
                            x = e.X; y = e.Y;
                            break;
                        }
                        else 
                        {
                            int x1 = line.p1.X;
                            int x2 = line.p2.X;
                            int y1 = line.p1.Y;
                            int y2 = line.p2.Y;
                            if (x1 > x2) Swap(ref x1, ref x2);
                            if (y1 > y2) Swap(ref y1, ref y2);
                            if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                                if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                                {
                                    ItemSelected = i;
                                    isSelected = true;
                                    x = e.X; y = e.Y;
                                    break;
                                }
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
                    else if (graphics[i] is Polygon polygon)
                    {
                        int xMin = int.MaxValue;
                        int xMax = 0;
                        int yMin = int.MaxValue;
                        int yMax = 0;
                        foreach(Point point in polygon.lPoint)
                        {
                            if (point.X < xMin) xMin = point.X;
                            if (point.X > xMax) xMax = point.X;
                            if (point.Y < yMin) yMin = point.Y;
                            if (point.Y > yMax) yMax = point.Y;
                        }
                        if (e.X >= xMin && e.X <= xMax && e.Y >= yMin && e.Y <= yMax)
                        {
                            ItemSelected = i;
                            isSelected = true;
                            x = e.X; y = e.Y;
                            break;
                        }
                    }
                    else if (graphics[i] is FillPolygon fill_polygon)
                    {
                        int xMin = int.MaxValue;
                        int xMax = 0;
                        int yMin = int.MaxValue;
                        int yMax = 0;
                        foreach (Point point in fill_polygon.lPoint)
                        {
                            if (point.X < xMin) xMin = point.X;
                            if (point.X > xMax) xMax = point.X;
                            if (point.Y < yMin) yMin = point.Y;
                            if (point.Y > yMax) yMax = point.Y;
                        }
                        if (e.X >= xMin && e.X <= xMax && e.Y >= yMin && e.Y <= yMax)
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
            this.pnlMain.Refresh();
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
        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelected)
            {
                int deltaX = e.X - x;
                int deltaY = e.Y - y;
                if (graphics[ItemSelected] is Line lineObject)
                {

                    lineObject.Move(deltaX, deltaY);
                }          
                else if (graphics[ItemSelected] is Elipse elipseObject)
                {
                    elipseObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is FillElipse fillElipseObject)
                {
                    fillElipseObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is RectangleGraphic rectangleObject)
                {
                   rectangleObject.Move(deltaX, deltaY);    
                }
                else if (graphics[ItemSelected] is FillRectangle fillRectangleObject)
                {
                    fillRectangleObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is Circle circleObject)
                {
                    circleObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is FillCircle fillCircleObject)
                {
                    fillCircleObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is Polygon polygonObject)
                {
                    polygonObject.Move(deltaX, deltaY);
                }
                else if (graphics[ItemSelected] is FillPolygon fillPolygonObject)
                {
                    fillPolygonObject.Move(deltaX, deltaY);
                }
                x = e.X; y = e.Y;
                this.pnlMain.Refresh();
            }
            else if (isPress)
            {
                this.graphics[this.graphics.Count - 1].p2 = e.Location;
                this.pnlMain.Refresh();
            }
        }
        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;                      
            if (isPress)
            {
                this.graphics[this.graphics.Count - 1].p2 = e.Location;
                this.pnlMain.Refresh();
                isClickColtrols = false;
                isPress = false;
                isLine = false;
                isCircle = false;
                isArc = false;
                isEllipse = false;
                isFillCircle = false;
                isFillElipse = false;
                isFillPolygon = false;
                isFillRectangle = false;
                isPolygon = false;
                isRectangle = false;
            }           
            
            
        }

        private void ptbColor_Click(object sender, EventArgs e)
        {
            this.cldControls.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            this.graphics.Clear();
            this.pnlMain.Refresh();
        }

        

        private void btnDashType_Click(object sender, EventArgs e)
        {
            isDash = true; isSolid = false; isDot = false; isDashDot = false; isDashDotDot = false;
            btnsplitStyle.Text = btnDashType.Text;
            btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_64px;
        }

        private void btnDotType_Click(object sender, EventArgs e)
        {
            isDash = false; isSolid = false; isDot = true; isDashDot = false; isDashDotDot = false;
            btnsplitStyle.Text = btnDotType.Text;
            btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.dotted_barline;
        }

        private void btnDashDotType_Click(object sender, EventArgs e)
        {
            isDash = false; isSolid = false; isDot = false; isDashDot = false; isDashDotDot = false;
            btnsplitStyle.Text = btnDashDotType.Text;
            btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_240px;
        }

        private void btnDashDotDotType_Click(object sender, EventArgs e)
        {
            isDash = false; isSolid = false; isDot = false; isDashDot = false; isDashDotDot = true;
            btnsplitStyle.Text = btnDashDotDotType.Text;
            btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_240px1;
        }

        private void btnSolidType_Click(object sender, EventArgs e)
        {
            isDash = false; isSolid = true; isDot = false; isDashDot = false; isDashDotDot = false;
            btnsplitStyle.Text = btnSolidType.Text;
            btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.line_64px;
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

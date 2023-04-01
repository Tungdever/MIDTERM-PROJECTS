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
        bool isLineSelected = false;
        bool isPaint = true;
        List<Point> lSides;
        List<Line> lines = new List<Line>();
        int lineItemSelected;
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
            isClickColtrols = true;
        }

        public double DistanceTo(Point point1, Point point2)
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
                        this.isPolygon= false;
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
                    if (this.isLine)
                    {
                        gp.DrawLine(myPen, beginPoint, endPoint);
                        Line newLine = new Line(beginPoint, endPoint);
                        lines.Add(newLine);
                        this.isLine = false;
                    }
                    else if (this.isEllipse)
                    {
                        RectangleF myRectangleF = new RectangleF(beginPoint, new Size(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y));
                        gp.DrawEllipse(myPen, myRectangleF);
                        this.isEllipse= false;
                    }
                    else if (this.isFillElipse)
                    {
                        RectangleF myRectangleF = new RectangleF(beginPoint, new Size(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y));
                        Brush myBrush = new SolidBrush(myColor);                      
                        gp.FillEllipse(myBrush, myRectangleF);
                        this.isFillElipse= false;
                    }
                    else if (this.isRectangle)
                    {
                        Rectangle myRectangle = new Rectangle(beginPoint, new Size(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y));
                        gp.DrawRectangle(myPen, myRectangle);
                        this.isRectangle= false;
                    }
                    else if (this.isFillRectangle)
                    {
                        Rectangle myRectangle = new Rectangle(beginPoint, new Size(endPoint.X - beginPoint.X, endPoint.Y - beginPoint.Y));
                        Brush myBrush = new SolidBrush(myColor);
                        gp.FillRectangle(myBrush, myRectangle);
                        this.isFillRectangle = false;
                    }
                    else if (this.isCircle) 
                    {                 
                        double rad = DistanceTo(beginPoint, endPoint);                        
                        gp.DrawEllipse(myPen, beginPoint.X,beginPoint.Y, (int)rad, (int)rad);
                        this.isCircle = false;
                    }
                    else if (this.isFillCircle)
                    {
                        double rad = DistanceTo(beginPoint, endPoint);
                        Brush myBrush = new SolidBrush(myColor);
                        gp.FillEllipse(myBrush, beginPoint.X, beginPoint.Y, (int)rad, (int)rad);
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
                        gp.DrawArc(myPen,x, y, width, height, startAngle, endAngle);
                        this.isArc = false;
                    }
                    
                    this.isStart = true;
                    this.isClickColtrols = false;
                   
                }
            }
            else
            {
                for (int i = 0; i < lines.Count(); i++)
                {
                    int x1 = lines[i].p1.X;
                    int x2 = lines[i].p2.X;
                    int y1 = lines[i].p1.Y;
                    int y2 = lines[i].p2.Y;
                    if (x1 > x2) Swap(ref x1, ref x2);
                    if (y1 > y2) Swap(ref y1, ref y2);
                    if (e.X >= x1 && e.X <= x2 && e.Y >= y1 && e.Y <= y2)
                    {
                        lineItemSelected = i;
                        isLineSelected = true;
                        x = e.X; y = e.Y;
                    }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.isPaint = false;
            this.pnlMain.Refresh();
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            this.isEllipse = true;
            this.isClickColtrols=true;
        }

        private void btnFilled_Ellipse_Click(object sender, EventArgs e)
        {
            this.isFillElipse = true;
            this.isClickColtrols = true;
            bool isBrush = true;
        }

        private void btnrectangle_Click(object sender, EventArgs e)
        {
            this.isRectangle = true;
            this.isClickColtrols = true;
        }

        private void btnFilled_Rectangle_Click(object sender, EventArgs e)
        {
            this.isFillRectangle = true;
            this.isClickColtrols = true;
            bool isBrush = true;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.isCircle = true;
            this.isClickColtrols = true;
        }

        private void btnFilled_Circle_Click(object sender, EventArgs e)
        {
            this.isFillCircle = true;
            this.isClickColtrols = true;
            bool isBrush = true;
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            this.isArc = true;
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
            this.isPolygon = true;
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
            this.isFillPolygon = true;
            this.isClickColtrols = true;
            bool isBrush = true;
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
            if (isLineSelected)
            {
                int deltaX = e.X - x;
                int deltaY = e.Y - y;
                lines[lineItemSelected].p1.X += deltaX;
                lines[lineItemSelected].p1.Y += deltaY;
                lines[lineItemSelected].p2.X += deltaX;
                lines[lineItemSelected].p2.Y += deltaY;
                x = e.X; y = e.Y;
                Refresh(); // Invalidate the control to update the display
            }
        }
        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isLineSelected = false;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            if (isPaint)
            {
                foreach (Line line in lines)
                {
                    line.draw(gp, myPen);
                }
            }
        }
    }
}

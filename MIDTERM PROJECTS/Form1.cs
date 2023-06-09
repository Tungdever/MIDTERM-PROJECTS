﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MIDTERM_PROJECTS
{
    public partial class Form1 : Form
    {
        Color myColor;
        // các biến check cho các buttton chọn hình vẽ
        bool isLine = false;
        bool isEllipse = false;
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
        // số đỉnh của polygon 
        int numSides;
        // có hình đang được chọn hay không
        bool isSelected = false;
        // các kiểu style của pen
        bool isSolid = true;
        bool isDash = false;
        bool isDot = false;
        bool isDashDot = false;
        bool isDashDotDot = false;
        // list chứa đỉnh của polygon
        List<Point> lSides;
        // list chứa các hình đã vẽ trên pnl main
        List<Graphic> graphics = new List<Graphic>();
        // list đang hình đang được focus
        List<Graphic> selected = new List<Graphic>();
        // toạ đọ của vị trí chuột mousedown
        int x, y;
        // vị trí zoom hình
        int posZoom;
        public Form1()
        {
            InitializeComponent();
            this.pnlMain.SetDoubleBuffered();         
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
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the number of sides:", "Filled Polygon", "5");
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
        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (isClickColtrols)
            {
                // setup pen
                myColor = cldControls.Color;
                Pen myPen = new Pen(myColor, int.Parse(txtThickness.Text));
                if (isSolid) myPen.DashStyle = DashStyle.Solid;
                else if (isDash) myPen.DashStyle = DashStyle.Dash;
                else if (isDot) myPen.DashStyle = DashStyle.Dot;
                else if (isDashDot) myPen.DashStyle = DashStyle.DashDot;
                else if (isDashDotDot) myPen.DashStyle = DashStyle.DashDotDot;
                if (this.isPolygon)
                {
                    Point newPoint = new Point(e.Location.X, e.Location.Y);
                    lSides.Add(newPoint);
                    if (this.lSides.Count == numSides)
                    {
                        Graphic newPolygon = new Polygon(lSides, myPen);
                        graphics.Add(newPolygon);
                        selected.Clear();
                        selected.Add(this.graphics[this.graphics.Count - 1]);
                        this.isPolygon = false;
                        this.isClickColtrols = false;
                        this.pnlMain.Refresh();
                    }
                }
                else if (this.isFillPolygon)
                {
                    Point newPoint = new Point(e.Location.X, e.Location.Y);
                    lSides.Add(newPoint);
                    if (this.lSides.Count == numSides)
                    {
                        FillPolygon newFillPolygon = new FillPolygon(lSides, myColor);
                        graphics.Add(newFillPolygon);
                        selected.Clear();
                        selected.Add(this.graphics[this.graphics.Count - 1]);
                        this.isFillPolygon = false;
                        this.isClickColtrols = false;
                        this.pnlMain.Refresh();
                    }
                }
                else
                {                  
                    isPress = true;
                    if (this.isLine)
                    {
                        Line newLine = new Line(myPen);
                        newLine.p1 = e.Location;
                        graphics.Add(newLine);
                    }
                    else if (this.isEllipse)
                    {
                        Elipse newElipse = new Elipse(myPen);
                        newElipse.p1 = e.Location;
                        graphics.Add(newElipse);
                    }
                    else if (this.isFillElipse)
                    {
                        FillElipse newFillElipse = new FillElipse(myColor);
                        newFillElipse.p1 = e.Location;
                        graphics.Add(newFillElipse);

                    }
                    else if (this.isRectangle)
                    {
                        RectangleGraphic newRectangle = new RectangleGraphic(myPen);
                        newRectangle.p1 = e.Location;
                        graphics.Add(newRectangle);

                    }
                    else if (this.isFillRectangle)
                    {
                        FillRectangle newFillRectangle = new FillRectangle(myColor);
                        newFillRectangle.p1 = e.Location;
                        graphics.Add(newFillRectangle);
                    }
                    else if (this.isCircle)
                    {
                        Circle newCircle = new Circle(myPen);
                        newCircle.p1 = e.Location;
                        graphics.Add(newCircle);

                    }
                    else if (this.isFillCircle)
                    {

                        FillCircle newFillCircle = new FillCircle(myColor);
                        newFillCircle.p1 = e.Location;
                        graphics.Add(newFillCircle);

                    }
                    else if (this.isArc)
                    {
                        Arc newArc = new Arc(myPen);
                        newArc.p1 = e.Location;
                        graphics.Add(newArc);
                    }
                }
            }
            else
            {
                for (int i = graphics.Count() - 1; i >= 0; i--)
                {
                    if (graphics[i] is Line line)
                    {
                        int mouseX = e.X;
                        int mouseY = e.Y;
                        // Tính toán hệ số góc và hệ số y tại điểm click để kiểm tra xem nó có nằm trên đường thẳng không
                        float slope = (line.p2.Y - line.p1.Y) / (float)(line.p2.X - line.p1.X);
                        float yIntercept = line.p1.Y - slope * line.p1.X;
                        float expectedY = slope * mouseX + yIntercept;

                        // Kiểm tra xem vị trí click của chuột có nằm trên đường thẳng không
                        posZoom = line.getPosZoom(e.X, e.Y);
                        if (Math.Abs(mouseY - expectedY) < 5)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }                            
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled= false;
                                    ctmGroup.Show(pnlMain,e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                        
                    }
                    else if (graphics[i] is Elipse elipse)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        double dx = e.X - elipse.center.X;
                        double dy = e.Y - elipse.center.Y;
                        double distance = Math.Pow(dx / elipse.a, 2) + Math.Pow(dy / elipse.b, 2);
                        posZoom = elipse.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(elipse))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        else if (distance <= 1.1)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is FillElipse fill_elipse)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        double dx = e.X - fill_elipse.center.X;
                        double dy = e.Y - fill_elipse.center.Y;
                        double distance = Math.Pow(dx / fill_elipse.a, 2) + Math.Pow(dy / fill_elipse.b, 2);
                        posZoom = fill_elipse.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(fill_elipse))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        else if (distance <= 1)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is RectangleGraphic rectangle)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        int xMin = Math.Min(rectangle.p1.X, rectangle.p2.X);
                        int yMin = Math.Min(rectangle.p1.Y, rectangle.p2.Y);
                        int width = Math.Abs(rectangle.p2.X - rectangle.p1.X);
                        int height = Math.Abs(rectangle.p2.Y - rectangle.p1.Y);                      
                        posZoom = rectangle.getPosZoom(e.X, e.Y);
                        if (e.X >= xMin - 10 && e.X <= xMin + width + 10 && e.Y >= yMin - 10 && e.Y <= yMin + height + 10)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is FillRectangle fill_rectangle)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        int xMin = Math.Min(fill_rectangle.p1.X, fill_rectangle.p2.X);
                        int yMin = Math.Min(fill_rectangle.p1.Y, fill_rectangle.p2.Y);
                        int width = Math.Abs(fill_rectangle.p2.X - fill_rectangle.p1.X);
                        int height = Math.Abs(fill_rectangle.p2.Y - fill_rectangle.p1.Y);
                        posZoom = fill_rectangle.getPosZoom(e.X, e.Y);
                        if (e.X >= xMin - 10 && e.X <= xMin + width + 10 && e.Y >= yMin - 10 && e.Y <= yMin + height + 10)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is Circle circle)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        double distance = Math.Sqrt(Math.Pow(e.X - circle.center.X, 2) + Math.Pow(e.Y - circle.center.Y, 2));
                        posZoom = circle.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(circle))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        else if (distance <= circle.radius + 5)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is FillCircle fill_circle)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        double distance = Math.Sqrt(Math.Pow(e.X - fill_circle.center.X, 2) + Math.Pow(e.Y - fill_circle.center.Y, 2));
                        posZoom = fill_circle.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(fill_circle))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        else if (distance <= fill_circle.radius + 5)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is Arc arc)
                    {                                            
                        posZoom = arc.getPosZoom(e.X, e.Y);                        
                        if (posZoom != -1 && selected.Contains(arc))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        else if (arc.path.IsVisible(e.Location))
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;

                        }
                    }
                    else if (graphics[i] is Polygon polygon)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
                        foreach (Point point in polygon.lPoint)
                        {
                            if (point.X < minX)
                            {
                                minX = point.X;
                            }
                            if (point.X > maxX)
                            {
                                maxX = point.X;
                            }
                            if (point.Y < minY)
                            {
                                minY = point.Y;
                            }
                            if (point.Y > maxY)
                            {
                                maxY = point.Y;
                            }
                        }
                        posZoom = polygon.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(polygon))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        if (e.X >= minX && e.X <= maxX && e.Y >= minY && e.Y <= maxY)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is FillPolygon fill_polygon)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;
                        foreach (Point point in fill_polygon.lPoint)
                        {
                            if (point.X < minX)
                            {
                                minX = point.X;
                            }
                            if (point.X > maxX)
                            {
                                maxX = point.X;
                            }
                            if (point.Y < minY)
                            {
                                minY = point.Y;
                            }
                            if (point.Y > maxY)
                            {
                                maxY = point.Y;
                            }
                        }
                        posZoom = fill_polygon.getPosZoom(e.X, e.Y);
                        if (posZoom != -1 && selected.Contains(fill_polygon))
                        {
                            isSelected = true;
                            x = e.X; y = e.Y;
                            return;
                        }
                        if (e.X >= minX && e.X <= maxX && e.Y >= minY && e.Y <= maxY)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right)
                                {
                                    ctmItemUngroup.Enabled = false;
                                    ctmGroup.Show(pnlMain, e.Location);
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                // thêm hình được focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                // nếu không ấn ctrl + chuột trái thì đây là hình được focus
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                    else if (graphics[i] is GroupGraphics gg)
                    {
                        // tính vị trí click chuột có focus vào hình không
                        posZoom = gg.getPosZoom(e.X, e.Y);
                        if (e.X >= gg.minX - 10 && e.X <= gg.maxX + 10 && e.Y >= gg.minY - 10 && e.Y <= gg.maxY + 10)
                        {
                            if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Right)
                            {
                                if (selected.Count == 0)
                                {
                                    MessageBox.Show("Make a selection first.");
                                }
                                else MessageBox.Show("This is not a valid selection.");
                            }
                            else if (selected.Contains(graphics[i]))
                            {
                                // Remove focus
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Remove(graphics[i]);
                                else if (e.Button == MouseButtons.Right )
                                {
                                    ctmItemUngroup.Enabled = true;
                                    ctmGroup.Show(pnlMain, e.Location);
                                    ctmGroup.Tag = gg;
                                }
                                isSelected = true;
                                x = e.X; y = e.Y;
                            }
                            else
                            {
                                isSelected = true;
                                x = e.X; y = e.Y;
                                if (ModifierKeys == Keys.Control && e.Button == MouseButtons.Left) selected.Add(graphics[i]);
                                else
                                {
                                    selected.Clear();
                                    selected.Add(graphics[i]);
                                }
                            }
                            return;
                        }
                    }
                }
                selected.Clear();
            }

        }
        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {            
            if (isSelected)
            {
                if (posZoom != -1)
                {
                    int deltaX = e.X - x;
                    int deltaY = e.Y - y;
                    foreach (Graphic obj in selected)
                    {
                        int index = graphics.IndexOf(obj);
                        graphics[index].Zoom(posZoom, deltaX, deltaY);
                    }                   
                }
                else
                {
                    int deltaX = e.X - x;
                    int deltaY = e.Y - y;
                    foreach (Graphic obj in selected)
                    {
                        int index = graphics.IndexOf(obj);
                        graphics[index].Move(deltaX, deltaY);
                    }                    
                    
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
            posZoom = -1;
            if (isPress)
            {
                this.graphics[this.graphics.Count - 1].p2 = e.Location;               
                this.pnlMain.Refresh();
                selected.Clear();
                selected.Add(this.graphics[this.graphics.Count - 1]);
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
            isSelected = false;
            this.pnlMain.Refresh();
        }
        private void ptbColor_Click(object sender, EventArgs e)
        {
            this.cldControls.ShowDialog();
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
            isDash = false; isSolid = false; isDot = false; isDashDot = true; isDashDotDot = false;
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.graphics.Clear();
            this.pnlMain.Refresh();
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (Graphic gp in selected)
            {
                graphics.Remove(gp);
            }
            this.pnlMain.Refresh();
        }

        private void txtThickness_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThickness.Text)) // Nếu TextBox trống
            {
                txtThickness.Text = "3";            
            }
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txtThickness.Text)) // Nếu TextBox trống
            {
                txtThickness.Text = "3";
            }
        }

        private void ctmItemGroup_Click(object sender, EventArgs e)
        {
            // Group
            // tạo 1 hình hỗn hợp chứa list các hình con
            GroupGraphics polyOjb = new GroupGraphics();
            foreach (Graphic item in selected)
            {
                polyOjb.graphics.Add(item);
            }
            // thêm hình hỗn hợp mới tạo vào danh sách các hình được vẽ 
            graphics.Add(polyOjb);
            // xoá các hình là con của hình con hợp ra khỏi danh sách các hình được vẽ
            foreach (Graphic item in selected)
            {
                graphics.Remove(item);
            }
            // hình được focus là hình hỗn hợp
            selected.Clear();
            selected.Add(polyOjb);
            this.pnlMain.Refresh();
        }

        private void ctmItemUngroup_Click(object sender, EventArgs e)
        {
            // Ungroup
            selected.Clear();
            foreach (Graphic item in (ctmGroup.Tag as GroupGraphics).graphics)
            {
                graphics.Add(item);
                selected.Add(item);
            }
            graphics.Remove(ctmGroup.Tag as GroupGraphics);
            this.pnlMain.Refresh();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            foreach (Graphic graphic in graphics)
            {
                if (selected.Contains(graphic))  graphic.Draw(true, e);
                else graphic.Draw(false, e);
            }
        }
    }
}

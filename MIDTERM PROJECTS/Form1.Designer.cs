using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MIDTERM_PROJECTS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControls = new System.Windows.Forms.Panel();
            this.cbbStyle = new System.Windows.Forms.ComboBox();
            this.btnStyle = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFilled_Polygon = new System.Windows.Forms.Button();
            this.btnpPolygon = new System.Windows.Forms.Button();
            this.btnArc = new System.Windows.Forms.Button();
            this.btnFilled_Circle = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnFilled_Rectangle = new System.Windows.Forms.Button();
            this.btnrectangle = new System.Windows.Forms.Button();
            this.btnFilled_Ellipse = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.cldControls = new System.Windows.Forms.ColorDialog();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.cbbStyle);
            this.pnlControls.Controls.Add(this.btnStyle);
            this.pnlControls.Controls.Add(this.BtnClear);
            this.pnlControls.Controls.Add(this.btnRemove);
            this.pnlControls.Controls.Add(this.btnColor);
            this.pnlControls.Controls.Add(this.btnFilled_Polygon);
            this.pnlControls.Controls.Add(this.btnpPolygon);
            this.pnlControls.Controls.Add(this.btnArc);
            this.pnlControls.Controls.Add(this.btnFilled_Circle);
            this.pnlControls.Controls.Add(this.btnCircle);
            this.pnlControls.Controls.Add(this.btnFilled_Rectangle);
            this.pnlControls.Controls.Add(this.btnrectangle);
            this.pnlControls.Controls.Add(this.btnFilled_Ellipse);
            this.pnlControls.Controls.Add(this.btnEllipse);
            this.pnlControls.Controls.Add(this.btnLine);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(425, 449);
            this.pnlControls.TabIndex = 0;
            this.pnlControls.Click += new System.EventHandler(this.pnlControls_Click);
            // 
            // cbbStyle
            // 
            this.cbbStyle.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStyle.FormattingEnabled = true;
            this.cbbStyle.Items.AddRange(new object[] {
            System.Drawing.Drawing2D.DashStyle.Solid,
            System.Drawing.Drawing2D.DashStyle.Dash,
            System.Drawing.Drawing2D.DashStyle.Dot,
            System.Drawing.Drawing2D.DashStyle.DashDot,
            System.Drawing.Drawing2D.DashStyle.DashDotDot});
            this.cbbStyle.Location = new System.Drawing.Point(224, 330);
            this.cbbStyle.Name = "cbbStyle";
            this.cbbStyle.Size = new System.Drawing.Size(186, 37);
            this.cbbStyle.TabIndex = 0;
            // 
            // btnStyle
            // 
            this.btnStyle.Location = new System.Drawing.Point(224, 330);
            this.btnStyle.Name = "btnStyle";
            this.btnStyle.Size = new System.Drawing.Size(186, 38);
            this.btnStyle.TabIndex = 13;
            this.btnStyle.Text = "Style";
            this.btnStyle.UseVisualStyleBackColor = true;
            this.btnStyle.Click += new System.EventHandler(this.btnStyle_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(224, 385);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(186, 38);
            this.BtnClear.TabIndex = 11;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(17, 385);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(186, 38);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(17, 330);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(186, 38);
            this.btnColor.TabIndex = 12;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFilled_Polygon
            // 
            this.btnFilled_Polygon.Location = new System.Drawing.Point(224, 270);
            this.btnFilled_Polygon.Name = "btnFilled_Polygon";
            this.btnFilled_Polygon.Size = new System.Drawing.Size(186, 38);
            this.btnFilled_Polygon.TabIndex = 9;
            this.btnFilled_Polygon.Text = "Filled Polygon";
            this.btnFilled_Polygon.UseVisualStyleBackColor = true;
            this.btnFilled_Polygon.Click += new System.EventHandler(this.btnFilled_Polygon_Click);
            // 
            // btnpPolygon
            // 
            this.btnpPolygon.Location = new System.Drawing.Point(224, 205);
            this.btnpPolygon.Name = "btnpPolygon";
            this.btnpPolygon.Size = new System.Drawing.Size(186, 38);
            this.btnpPolygon.TabIndex = 8;
            this.btnpPolygon.Text = "Polygon";
            this.btnpPolygon.UseVisualStyleBackColor = true;
            this.btnpPolygon.Click += new System.EventHandler(this.btnpPolygon_Click);
            // 
            // btnArc
            // 
            this.btnArc.Location = new System.Drawing.Point(224, 143);
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(186, 38);
            this.btnArc.TabIndex = 7;
            this.btnArc.Text = "Arc";
            this.btnArc.UseVisualStyleBackColor = true;
            this.btnArc.Click += new System.EventHandler(this.btnArc_Click);
            // 
            // btnFilled_Circle
            // 
            this.btnFilled_Circle.Location = new System.Drawing.Point(224, 77);
            this.btnFilled_Circle.Name = "btnFilled_Circle";
            this.btnFilled_Circle.Size = new System.Drawing.Size(186, 38);
            this.btnFilled_Circle.TabIndex = 6;
            this.btnFilled_Circle.Text = "Filled Circle";
            this.btnFilled_Circle.UseVisualStyleBackColor = true;
            this.btnFilled_Circle.Click += new System.EventHandler(this.btnFilled_Circle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(224, 12);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(186, 38);
            this.btnCircle.TabIndex = 5;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnFilled_Rectangle
            // 
            this.btnFilled_Rectangle.Location = new System.Drawing.Point(17, 270);
            this.btnFilled_Rectangle.Name = "btnFilled_Rectangle";
            this.btnFilled_Rectangle.Size = new System.Drawing.Size(186, 38);
            this.btnFilled_Rectangle.TabIndex = 4;
            this.btnFilled_Rectangle.Text = "Filled Rectangle";
            this.btnFilled_Rectangle.UseVisualStyleBackColor = true;
            this.btnFilled_Rectangle.Click += new System.EventHandler(this.btnFilled_Rectangle_Click);
            // 
            // btnrectangle
            // 
            this.btnrectangle.Location = new System.Drawing.Point(17, 205);
            this.btnrectangle.Name = "btnrectangle";
            this.btnrectangle.Size = new System.Drawing.Size(186, 38);
            this.btnrectangle.TabIndex = 3;
            this.btnrectangle.Text = "Rectangle";
            this.btnrectangle.UseVisualStyleBackColor = true;
            this.btnrectangle.Click += new System.EventHandler(this.btnrectangle_Click);
            // 
            // btnFilled_Ellipse
            // 
            this.btnFilled_Ellipse.Location = new System.Drawing.Point(17, 143);
            this.btnFilled_Ellipse.Name = "btnFilled_Ellipse";
            this.btnFilled_Ellipse.Size = new System.Drawing.Size(186, 38);
            this.btnFilled_Ellipse.TabIndex = 2;
            this.btnFilled_Ellipse.Text = "Filled Ellipse";
            this.btnFilled_Ellipse.UseVisualStyleBackColor = true;
            this.btnFilled_Ellipse.Click += new System.EventHandler(this.btnFilled_Ellipse_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(17, 77);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(186, 38);
            this.btnEllipse.TabIndex = 1;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(17, 12);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(186, 38);
            this.btnLine.TabIndex = 0;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // cldControls
            // 
            this.cldControls.AllowFullOpen = false;
            this.cldControls.FullOpen = true;
            this.cldControls.HelpRequest += new System.EventHandler(this.cldControls_HelpRequest);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(425, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(873, 449);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            this.pnlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseClick);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            this.pnlMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 449);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlControls);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnFilled_Rectangle;
        private System.Windows.Forms.Button btnrectangle;
        private System.Windows.Forms.Button btnFilled_Ellipse;
        private System.Windows.Forms.Button btnFilled_Polygon;
        private System.Windows.Forms.Button btnpPolygon;
        private System.Windows.Forms.Button btnArc;
        private System.Windows.Forms.Button btnFilled_Circle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColorDialog cldControls;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ComboBox cbbStyle;
        private System.Windows.Forms.Button btnStyle;
        private Panel pnlMain;
    }
}


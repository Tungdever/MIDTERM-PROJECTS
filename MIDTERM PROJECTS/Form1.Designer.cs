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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnsplitStyle = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSolidType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDashType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDotType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDashDotType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDashDotDotType = new System.Windows.Forms.ToolStripMenuItem();
            this.ptbColor = new System.Windows.Forms.PictureBox();
            this.pnlControls.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFilled_Polygon
            // 
            this.btnFilled_Polygon.Location = new System.Drawing.Point(237, 65);
            this.btnFilled_Polygon.Name = "btnFilled_Polygon";
            this.btnFilled_Polygon.Size = new System.Drawing.Size(113, 38);
            this.btnFilled_Polygon.TabIndex = 9;
            this.btnFilled_Polygon.Text = "Filled Polygon";
            this.btnFilled_Polygon.UseVisualStyleBackColor = true;
            this.btnFilled_Polygon.Click += new System.EventHandler(this.btnFilled_Polygon_Click);
            // 
            // btnpPolygon
            // 
            this.btnpPolygon.Location = new System.Drawing.Point(123, 65);
            this.btnpPolygon.Name = "btnpPolygon";
            this.btnpPolygon.Size = new System.Drawing.Size(108, 38);
            this.btnpPolygon.TabIndex = 8;
            this.btnpPolygon.Text = "Polygon";
            this.btnpPolygon.UseVisualStyleBackColor = true;
            this.btnpPolygon.Click += new System.EventHandler(this.btnpPolygon_Click);
            // 
            // btnArc
            // 
            this.btnArc.Location = new System.Drawing.Point(24, 65);
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(93, 38);
            this.btnArc.TabIndex = 7;
            this.btnArc.Text = "Arc";
            this.btnArc.UseVisualStyleBackColor = true;
            this.btnArc.Click += new System.EventHandler(this.btnArc_Click);
            // 
            // btnFilled_Circle
            // 
            this.btnFilled_Circle.Location = new System.Drawing.Point(465, 65);
            this.btnFilled_Circle.Name = "btnFilled_Circle";
            this.btnFilled_Circle.Size = new System.Drawing.Size(132, 38);
            this.btnFilled_Circle.TabIndex = 6;
            this.btnFilled_Circle.Text = "Filled Circle";
            this.btnFilled_Circle.UseVisualStyleBackColor = true;
            this.btnFilled_Circle.Click += new System.EventHandler(this.btnFilled_Circle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(356, 65);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(103, 38);
            this.btnCircle.TabIndex = 5;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnFilled_Rectangle
            // 
            this.btnFilled_Rectangle.Location = new System.Drawing.Point(465, 21);
            this.btnFilled_Rectangle.Name = "btnFilled_Rectangle";
            this.btnFilled_Rectangle.Size = new System.Drawing.Size(132, 38);
            this.btnFilled_Rectangle.TabIndex = 4;
            this.btnFilled_Rectangle.Text = "Filled Rectangle";
            this.btnFilled_Rectangle.UseVisualStyleBackColor = true;
            this.btnFilled_Rectangle.Click += new System.EventHandler(this.btnFilled_Rectangle_Click);
            // 
            // btnrectangle
            // 
            this.btnrectangle.Location = new System.Drawing.Point(356, 21);
            this.btnrectangle.Name = "btnrectangle";
            this.btnrectangle.Size = new System.Drawing.Size(103, 38);
            this.btnrectangle.TabIndex = 3;
            this.btnrectangle.Text = "Rectangle";
            this.btnrectangle.UseVisualStyleBackColor = true;
            this.btnrectangle.Click += new System.EventHandler(this.btnrectangle_Click);
            // 
            // btnFilled_Ellipse
            // 
            this.btnFilled_Ellipse.Location = new System.Drawing.Point(237, 21);
            this.btnFilled_Ellipse.Name = "btnFilled_Ellipse";
            this.btnFilled_Ellipse.Size = new System.Drawing.Size(113, 38);
            this.btnFilled_Ellipse.TabIndex = 2;
            this.btnFilled_Ellipse.Text = "Filled Ellipse";
            this.btnFilled_Ellipse.UseVisualStyleBackColor = true;
            this.btnFilled_Ellipse.Click += new System.EventHandler(this.btnFilled_Ellipse_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(123, 21);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(108, 38);
            this.btnEllipse.TabIndex = 1;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(24, 21);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(93, 38);
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
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1298, 708);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            this.pnlMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseUp);
            // 
            // pnlControls
            // 
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControls.Controls.Add(this.toolStrip3);
            this.pnlControls.Controls.Add(this.toolStrip2);
            this.pnlControls.Controls.Add(this.toolStrip1);
            this.pnlControls.Controls.Add(this.btnrectangle);
            this.pnlControls.Controls.Add(this.btnFilled_Rectangle);
            this.pnlControls.Controls.Add(this.btnArc);
            this.pnlControls.Controls.Add(this.ptbColor);
            this.pnlControls.Controls.Add(this.btnFilled_Ellipse);
            this.pnlControls.Controls.Add(this.btnpPolygon);
            this.pnlControls.Controls.Add(this.btnCircle);
            this.pnlControls.Controls.Add(this.btnFilled_Polygon);
            this.pnlControls.Controls.Add(this.btnLine);
            this.pnlControls.Controls.Add(this.btnFilled_Circle);
            this.pnlControls.Controls.Add(this.btnEllipse);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1298, 121);
            this.pnlControls.TabIndex = 14;
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear});
            this.toolStrip3.Location = new System.Drawing.Point(611, 65);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(93, 38);
            this.toolStrip3.TabIndex = 17;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(611, 21);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(161, 38);
            this.toolStrip2.TabIndex = 16;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(119, 35);
            this.toolStripButton1.Text = "Remove";
            this.toolStripButton1.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsplitStyle});
            this.toolStrip1.Location = new System.Drawing.Point(763, 65);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(104, 38);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnsplitStyle
            // 
            this.btnsplitStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnsplitStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsplitStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSolidType,
            this.btnDashType,
            this.btnDotType,
            this.btnDashDotType,
            this.btnDashDotDotType});
            this.btnsplitStyle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsplitStyle.Image = global::MIDTERM_PROJECTS.Properties.Resources.line_64px;
            this.btnsplitStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsplitStyle.Name = "btnsplitStyle";
            this.btnsplitStyle.Size = new System.Drawing.Size(101, 35);
            this.btnsplitStyle.Text = "Style";
            // 
            // btnSolidType
            // 
            this.btnSolidType.Image = global::MIDTERM_PROJECTS.Properties.Resources.line_64px;
            this.btnSolidType.Name = "btnSolidType";
            this.btnSolidType.Size = new System.Drawing.Size(227, 36);
            this.btnSolidType.Text = "Solid";
            this.btnSolidType.Click += new System.EventHandler(this.btnSolidType_Click);
            // 
            // btnDashType
            // 
            this.btnDashType.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_64px;
            this.btnDashType.Name = "btnDashType";
            this.btnDashType.Size = new System.Drawing.Size(227, 36);
            this.btnDashType.Text = "Dash";
            this.btnDashType.Click += new System.EventHandler(this.btnDashType_Click);
            // 
            // btnDotType
            // 
            this.btnDotType.Image = global::MIDTERM_PROJECTS.Properties.Resources.dotted_barline;
            this.btnDotType.Name = "btnDotType";
            this.btnDotType.Size = new System.Drawing.Size(227, 36);
            this.btnDotType.Text = "Dot";
            this.btnDotType.Click += new System.EventHandler(this.btnDotType_Click);
            // 
            // btnDashDotType
            // 
            this.btnDashDotType.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_240px1;
            this.btnDashDotType.Name = "btnDashDotType";
            this.btnDashDotType.Size = new System.Drawing.Size(227, 36);
            this.btnDashDotType.Text = "DashDot";
            this.btnDashDotType.Click += new System.EventHandler(this.btnDashDotType_Click);
            // 
            // btnDashDotDotType
            // 
            this.btnDashDotDotType.Image = global::MIDTERM_PROJECTS.Properties.Resources.dashed_line_240px;
            this.btnDashDotDotType.Name = "btnDashDotDotType";
            this.btnDashDotDotType.Size = new System.Drawing.Size(227, 36);
            this.btnDashDotDotType.Text = "DashDotDot";
            this.btnDashDotDotType.Click += new System.EventHandler(this.btnDashDotDotType_Click);
            // 
            // ptbColor
            // 
            this.ptbColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbColor.BackgroundImage")));
            this.ptbColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbColor.Location = new System.Drawing.Point(763, 21);
            this.ptbColor.Name = "ptbColor";
            this.ptbColor.Size = new System.Drawing.Size(86, 38);
            this.ptbColor.TabIndex = 13;
            this.ptbColor.TabStop = false;
            this.ptbColor.Click += new System.EventHandler(this.ptbColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 708);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.ColorDialog cldControls;
        private Panel pnlMain;
        private PictureBox ptbColor;
        private Panel pnlControls;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton btnsplitStyle;
        private ToolStripMenuItem btnSolidType;
        private ToolStripMenuItem btnDashType;
        private ToolStripMenuItem btnDotType;
        private ToolStripMenuItem btnDashDotType;
        private ToolStripMenuItem btnDashDotDotType;
        private ToolStrip toolStrip2;
        private ToolStrip toolStrip3;
        private ToolStripButton btnClear;
        private ToolStripButton toolStripButton1;
    }
}


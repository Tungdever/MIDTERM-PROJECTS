﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public abstract class Graphic
    {
        public Point p1;
        public Point p2;
        public int maxX, maxY, minX, minY;
        public abstract void Draw(Graphics gp, bool isSelected);
        public abstract void Move(int deltaX, int deltaY);

        public abstract void Zoom(int pos, int deltaX, int deltaY);
        public abstract int getPosZoom(int mouseDownX, int mouseDownY);
    }
}

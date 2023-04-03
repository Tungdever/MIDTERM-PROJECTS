using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTERM_PROJECTS
{
    public abstract class Graphic
    {

        public abstract void Draw(Graphics gp);
        public abstract void Move(int deltaX, int deltaY);
    }
}

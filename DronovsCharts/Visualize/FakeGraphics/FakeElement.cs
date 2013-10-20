using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DronovsCharts.Visualize.FakeGraphics
{
    public abstract class FakeElement
    {
        public Pen Pen { get; set; }
        virtual public int X { get; set; }
        virtual public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Render(Graphics g);
    }
}

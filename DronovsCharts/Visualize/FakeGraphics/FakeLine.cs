using System;
using System.Drawing;

namespace DronovsCharts.Visualize.FakeGraphics
{
    class FakeLine: FakeElement
    {
        private int _x1, _y1;
        private int _x2, _y2;
        public int X1
        {
            get { return _x1; }
            set 
            { 
                _x1 = value;
                _update();
            }
        }
        public int Y1
        {
            get { return _y1; }
            set 
            {
                _y1 = value;
                _update();
            }
        }

        public int X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                _update();
            }
        }
        public int Y2
        {
            get { return _y2; }
            set
            {
                _y2 = value;
                _update();
            }
        }

        private void _update()
        {
            X = Math.Min(_x1, _x2);
            Y = Math.Min(_y1, _y2);
            Width = Math.Abs(_x1 - _x2);
            Height = Math.Abs(_y1 - _y2);
        }

        public override void Render(Graphics g)
        {
            g.DrawLine(Pen, X1, Y1, X2, Y2);
        }
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;

namespace DronovsCharts.Visualize
{
    static class GraphicsExtension
    {
        public static void DrawEntryRect(this FakeGraphics.FakeGraphics g, Pen pen, int x, int y, int w, int h)
        {
            //todo: make it perfect
            g.DrawArc(pen, x, y, h, h, 90, 180);
            g.DrawArc(pen, x + w - h, y, y + h, y + h, -90, 180);
            g.DrawLine(pen, x + h / 2, y + 3, w - h / 2, y + 3);
            g.DrawLine(pen, x + h / 2, y + h, w - h / 2, h);
        }

        public static void DrawParallelogram(this FakeGraphics.FakeGraphics g, Pen pen, int x, int y, int w, int h)
        {
            g.DrawLine(pen, x + h / 2, y, x, y + h);
            g.DrawLine(pen, x + w, y, x + w - h / 2, y + h);

            g.DrawLine(pen, x + h / 2, y + 3, x + w, y + 3);
            g.DrawLine(pen, x, y + h, x + w - h / 2, y + h);
        }

        public static void DrawOutputRect(this FakeGraphics.FakeGraphics g, Pen pen, int x, int y, int w, int h)
        {
            g.DrawArc(pen, x, y, h, h, 90, 180);

            g.DrawLine(pen, x + w - h / 2, y, x + w, y + h / 2);
            g.DrawLine(pen, x + w, y + h / 2, x + w - h / 2, y + h);

            g.DrawLine(pen, x + h / 2, y + 3, w - h / 2, y + 3);
            g.DrawLine(pen, x + h / 2, y + h, w - h / 2, h);
        }

        public static void DrawArrow(this FakeGraphics.FakeGraphics g, Pen pen, int x1, int y1, int x2, int y2)
        {
            Pen p = (Pen)pen.Clone();
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Flat;
            g.DrawLine(pen, x1, y1, x2, y2);
            p.Width = 5;
            p.EndCap = LineCap.ArrowAnchor;
            int xx=x2, yy=y2;
            if (x1 == x2)
            {
                if (y1 > y2)
                    yy += 5;
                else
                    yy -= 5;
            }
            else
            {
                if (x1 > x2)
                    xx += 5;
                else
                    xx -= 5;
            }
            g.DrawLine(p, xx, yy, x2, y2);
        }

        public static void DrawRombus(this FakeGraphics.FakeGraphics g, Pen pen, int x, int y, int width, int height)
        {
            g.DrawLines(pen, new Point[]
                {
                    new Point(x, y + height / 2),
                    new Point(x+width / 2, y),
                    new Point(x + width, y + height / 2),
                    new Point(x + width/2, y + height),
                    new Point(x, y + height / 2), 
                });
        }

        public static void DrawHexagon(this FakeGraphics.FakeGraphics g, Pen pen, int x, int y, int w, int h)
        {
            g.DrawLine(pen, x + h/2, y, x, y + h/2);
            g.DrawLine(pen, x, y + h/2, x + h/2, y + h);

            g.DrawLine(pen, x + w - h / 2, y, x + w, y + h / 2);
            g.DrawLine(pen, x + w, y + h / 2, x + w - h / 2, y + h);

            g.DrawLine(pen, x + h / 2, y + 3, w - h / 2, y + 3);
            g.DrawLine(pen, x + h / 2, y + h, w - h / 2, h);            
        }
    }
}

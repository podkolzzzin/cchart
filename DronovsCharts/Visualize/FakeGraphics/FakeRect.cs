using System.Drawing;

namespace DronovsCharts.Visualize.FakeGraphics
{
    class FakeRect:FakeElement
    {
        public override void Render(Graphics g)
        {
            g.DrawRectangle(this.Pen, X,Y,Width,Height);
        }
    }
}

using System.Drawing;

namespace DronovsCharts.Visualize.FakeGraphics
{
    class FakeArc: FakeElement
    {
        public override void Render(Graphics g)
        {
            g.DrawArc(Pen,X,Y,Width,Height,StartAngle,  SweepAngle);
        }

        public int StartAngle { get; set; }
        public int SweepAngle { get; set; }
    }
}

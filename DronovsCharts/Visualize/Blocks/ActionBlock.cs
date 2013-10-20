using System.Drawing;

namespace DronovsCharts.Visualize.Blocks
{
    class ActionBlock : Block
    {
        public ActionBlock()
        {
            Width = 12;
            Height = 2;
        }

        protected override void GetImage()
        {
            Graphics.DrawRectangle(BlockPen, 3, 3, RWidth, RHeight);
            DrawText();
        }
    }
}

namespace DronovsCharts.Visualize.Blocks
{
    class InputBlock : Block
    {
        public InputBlock()
        {
            Width = 14;
            Height = 2;
        }

        protected override void GetImage()
        {
            Graphics.DrawParallelogram(BlockPen, 0,0,RWidth, RHeight);
            DrawText();
        }
    }
}

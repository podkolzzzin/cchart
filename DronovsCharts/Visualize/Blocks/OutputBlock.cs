namespace DronovsCharts.Visualize.Blocks
{
    class OutputBlock:Block
    {
        public OutputBlock()
        {
            Width = 14;
            Height = 2;
        }

        protected override void GetImage()
        {
            Graphics.DrawOutputRect(BlockPen, 0, 0, RWidth, RHeight);
            DrawText();
        }
    }
}

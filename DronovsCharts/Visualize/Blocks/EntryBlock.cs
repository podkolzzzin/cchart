namespace DronovsCharts.Visualize.Blocks
{
    class EntryBlock : Block
    {
        public EntryBlock()
        {
            Width = 10;
            Height = 2;
        }

        protected override void GetImage()
        {
            Graphics.DrawEntryRect(BlockPen, 0,0, RWidth, RHeight);
            DrawText();
        }
    }
}

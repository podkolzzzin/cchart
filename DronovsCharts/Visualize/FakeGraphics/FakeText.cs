using System.Drawing;

namespace DronovsCharts.Visualize.FakeGraphics
{
    class FakeText: FakeElement
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                if(Font!=null)
                    Width = (int)Font.Size*_text.Length;
            }
        }
        public Font Font { get; set; }
        public Brush Brush { get; set; }

        public override void Render(Graphics g)
        {
            g.DrawString(Text, Font, Brush, new RectangleF(X,Y,Width,Height), Format);
        }

        public StringFormat Format { get; set; }
    }
}

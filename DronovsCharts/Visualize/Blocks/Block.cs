using System;
using System.Collections.Generic;
using System.Drawing;
using DronovsCharts.Analyze;
using DronovsCharts.Visualize.FakeGraphics;

namespace DronovsCharts.Visualize.Blocks
{
    class Block
    {
        private const int SIZE = 20;

        protected COperator _operator;
        public List<Block> Blocks { get; set; }
        public static Font Default = new Font(new FontFamily("Arial"), 10);
        public static StringFormat Centered = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        public static Pen BlockPen = new Pen(Brushes.Black) { Width = 6 };
        public static Pen ArrowPen = new Pen(Brushes.Black) {Width = 2};



        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int RX 
        { get
        {
            if(!_haveToCenter)
                return X * SIZE;
            else
            {
                return (_parentRWidth - X*SIZE - RWidth)/2;
            }
        } 
        }
        public int RY { get { return Y * SIZE; } }
        public int RWidth { get
        {
            return Width * SIZE;
        } }
        public int RHeight { get { return Height * SIZE; } }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Width = Math.Max((int)(value.Length/2.2) + 5, 8);
            }
        }

        virtual protected void GetImage()
        {
            return;
        }



        private FakeGraphics.FakeGraphics _graphics;
        public FakeGraphics.FakeGraphics Graphics
        {
            get
            {
                if (_graphics == null)
                {
                    _graphics = new FakeGraphics.FakeGraphics();
                }
                return _graphics;
            }
        }

        public FakeGraphics.FakeGraphics Image
        {
            get
            {
                GetImage();
                return _graphics;
            }
        }
        
        private bool _haveToCenter;
        private int _parentRWidth;

        public Block()
        {

        }

        public int GetX(int x)
        {
            return X + x;
        }

        public int GetY(int y)
        {
            return Y + y;
        }

        public int GetRX(int rx)
        {
            return RX + rx;
        }

        public int GetRY(int ry)
        {
            return RY + ry;
        }

        protected void DrawText()
        {
            Graphics.DrawString(Text, Default, Brushes.Black, new RectangleF(0, 0, RWidth, RHeight), Centered);
        }


        public void CenterIt(int rWidth)
        {
            _haveToCenter = true;
            _parentRWidth = rWidth;
        }
    }
}

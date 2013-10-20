using System;
using System.Collections.Generic;
using System.Linq;
using DronovsCharts.Analyze;

namespace DronovsCharts.Visualize.Blocks
{
    class CycleBlock:Block
    {
        private Block _block;
        public CycleBlock(COperator c)
        {
            _operator = c;
            _draw();
        }

        private void _draw()
        {
            _block = new CycleSpecBlock() {Text = _operator.Text, X = 2};
            Width = _block.Width + 4;
            _findSizes();
            _block.CenterIt(RWidth);
            //_block.X = (Width - _block.Width) / 2;           
            Width = Math.Max(_block.Width, Width) + 6;
            Height += _block.Height + 4;
            Block prev = _block;
            foreach (var b in Blocks)
            {
                b.CenterIt(RWidth);
                b.X = 4;
                b.Y = prev.Y + prev.Height + 2;
                Graphics.DrawImage(b.Image, b.RX, b.RY);

                Graphics.DrawArrow(ArrowPen, prev.RX + prev.RWidth/2, prev.RY + prev.RHeight,
                                   prev.RX + prev.RWidth / 2, b.RY);

                prev = b;
            }

        }

        private void _findSizes()
        {
            Blocks = new List<Block>();
            foreach (var op in _operator.PDown)
            {
                var go = new GraphicOperator(op);
                Height += go.Height + 2;
                Width = Math.Max(go.Width, Width);
                
                Blocks.Add(go);
            }
        }

        protected override void GetImage()
        {
            Graphics.DrawImage(_block.Image, _block.RX, _block.RY);
            var l = Blocks.Last();
            Graphics.DrawLine(ArrowPen, l.RX+l.RWidth/2, l.RY+l.RHeight ,l.RX + l.RWidth / 2, l.RY + l.RHeight + 20);

            Graphics.DrawLine(ArrowPen, l.RX + l.RWidth / 2, l.RY+l.RHeight + 20,
                3, l.RY + l.RHeight + 20);

            Graphics.DrawLine(ArrowPen, 3, l.RY + l.RHeight + 20,
                3, _block.RY+_block.RHeight / 2);

            Graphics.DrawArrow(ArrowPen, 3, _block.RY + _block.RHeight / 2,
                _block.RX, _block.RY + _block.RHeight / 2);
            
            Graphics.DrawLine(ArrowPen, _block.RX+_block.RWidth, _block.RY+ _block.RHeight / 2,
                RWidth , _block.RY + _block.RHeight / 2);

            Graphics.DrawLine(ArrowPen, RWidth, _block.RY + _block.RHeight/2,
                              RWidth, RHeight);

            Graphics.DrawLine(ArrowPen, RWidth, RHeight,
                                RWidth/2, RHeight);

        }

        private class CycleSpecBlock : Block
        {
            public CycleSpecBlock()
            {
                Width = 20;
                Height = 2;
            }

            protected override void GetImage()
            {
                Graphics.DrawHexagon(BlockPen, 0, 0, RWidth, RHeight);
                DrawText();
            }
        }
    }


}

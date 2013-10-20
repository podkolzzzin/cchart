using System.Drawing;
using DronovsCharts.Analyze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronovsCharts.Visualize.Blocks
{
    class CaseBlock: Block
    {
        public CaseBlock(COperator ooperator)
        {
            Height = 2;
            Width = 4;
            _operator = ooperator;
            Blocks = new List<Block>();
            foreach (var o in _operator.PLeft)
            {
                Blocks.Add(new GraphicOperator(o){Text = o.Text, X = Width});
                Width += Blocks.Last().Width + 2;
            }
        }

        protected override void GetImage()
        {
            int x1;
            foreach (var block in Blocks)
            {
                if (block == Blocks.First())
                    x1 = block.RX - 80;
                else
                    x1 = block.RX - 40;
                Graphics.DrawArrow(ArrowPen, x1, block.RY + block.RHeight / 2,
                                             block.RX,      block.RY + block.RHeight / 2);
                Graphics.DrawImage(block.Image, block.RX, block.RY);
            }

            Graphics.DrawString(_operator.Text, Default, Brushes.Black, Blocks.First().RX - 60, Blocks.First().RY);
        }
    }
}

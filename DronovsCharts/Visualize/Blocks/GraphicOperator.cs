using System;
using System.Collections.Generic;
using System.Linq;
using DronovsCharts.Analyze;

namespace DronovsCharts.Visualize.Blocks
{
    class GraphicOperator:Block
    {
        public GraphicOperator(COperator c)
        {
            Width = 10;
            Height = 2;
            Blocks = new List<Block>();

            switch (c.Type)
            {
                case OperatorType.Switch:
                    Blocks.Add(new ConditionalBlock(c));
                    break;
                case OperatorType.Case:
                    Blocks.Add(new CaseBlock(c));
                    break;
                case OperatorType.StartEnd:
                    Blocks.Add(new EntryBlock {Text = c.Text});
                    break;
                case OperatorType.Output:
                    Blocks.Add(new OutputBlock() {Text = c.Text});
                    break;
                case OperatorType.Input:
                    Blocks.Add(new InputBlock() {Text = c.Text});
                    break;
                case OperatorType.Cycle:
                    Blocks.Add(new CycleBlock(c));
                    break;
                case OperatorType.If:
                    Blocks.Add(new ConditionalBlock(c));
                    break;
                case OperatorType.Action:
                    Blocks.Add(new ActionBlock() {Text = c.Text});
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Width = Blocks.First().Width;
            Height = Blocks.First().Height;
        }

        protected override void GetImage()
        {
            int prevY = -2;
            foreach (var block in Blocks)
            {
                block.Y = prevY + 2;
                prevY = block.Y;
                Graphics.DrawImage(block.Image, block.RX, block.RY);
            }          
        }

       
    }
}

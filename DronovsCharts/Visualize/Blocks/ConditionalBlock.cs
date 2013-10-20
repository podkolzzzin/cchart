using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DronovsCharts.Analyze;

namespace DronovsCharts.Visualize.Blocks
{
    class ConditionalBlock : Block
    {
        private List<Block> _leftBranch, _rightBranch;
        private ConditionalSpecBlock _block;
        public ConditionalBlock(COperator o)
        {
            _operator = o;
            _findRelativePositions();
        }

        private void _findRelativePositions()
        {
            if (_operator.Type == OperatorType.If)
            {
                _ifCondition();
            }
            else
            {
                _switchCondition();
            }
        }

        private void _switchCondition()
        {
            /*
             Complex operators in switch will kill program
             */
            _block = new ConditionalSpecBlock() { Text = _operator.Text, X = 0, Y = 0};
            Blocks = new List<Block>();
            Block prev = _block;
            
            Width = _block.Width;
            Height = _block.Height;
            foreach (var o in _operator.PDown)
            {
                Block graph = new GraphicOperator(o) { X = X + _block.Width / 2, Y = prev.Y + prev.Height + 2};
                Graphics.DrawImage(graph.Image, graph.RX, graph.RY);
                
                Height += graph.Height + 2;
                prev = graph;
                Width = Math.Max(Width, graph.Width + _block.Width/2);
                Blocks.Add(graph);
            }

            Graphics.DrawArrow(ArrowPen, _block.RX + _block.RWidth / 2, _block.RY+_block.RHeight,
                                         _block.RX + _block.RWidth / 2, RHeight + 40);

            foreach (var o in _operator.PDefault)
            {
                Block graph = new GraphicOperator(o) { X = X, Y = prev.Y + prev.Height + 2 };
                Graphics.DrawImage(graph.Image, graph.RX, graph.RY);

                Height += graph.Height + 2;
                prev = graph;
                Width = Math.Max(Width, graph.Width + _block.Width / 2);               
            }
            Height += 2;
        }

        private void _ifCondition()
        {
            Size left, right;
            _leftBranch = _preBuildBranch(_operator.PLeft, out left);
            _rightBranch = _preBuildBranch(_operator.PRight, out right);

            Height = Math.Max(left.Height, right.Height) + 8;
            _block = new ConditionalSpecBlock() { Text = _operator.Text };
            int w = Math.Max(left.Width, right.Width) * 2 + _block.Width / 2;
            if (w < 40) w = 3 * _block.Width;
            _block.X = (w - _block.Width) / 2;
            Width = w;


            _postionizeBranchOnImage(_leftBranch, 0, 6, w / 2);
            _postionizeBranchOnImage(_rightBranch, w / 2, 6, w / 2);
            Blocks = new List<Block>();
            Blocks.AddRange(_leftBranch);
            Blocks.AddRange(_rightBranch);
        }

        private void _postionizeBranchOnImage(List<Block> branch, int offsetX, int offsetY, int branchWidth)
        {
            Block prev = new Block() { X = offsetX, Y = offsetY, Width = 0, Height = 0 };
            foreach (var block in branch)
            {
                block.X = offsetX + (branchWidth - block.Width) / 2;
                block.Y = prev.Y + prev.Height + 2;
                Graphics.DrawImage(block.Image, block.RX, block.RY);
                if (block != branch.First())
                {
                    Graphics.DrawArrow(ArrowPen, prev.RX + prev.RWidth / 2, prev.RY + prev.RHeight,
                                                prev.RX + prev.RWidth / 2, block.RY);
                }
                prev = block;            
            }
            if (branch.Count > 0)
            {
                var l = branch.Last();
                Graphics.DrawLine(ArrowPen, l.RX + l.RWidth/2, l.RY + l.RHeight,
                                  l.RX + l.RWidth/2, RHeight);

                Graphics.DrawArrow(ArrowPen, l.RX + l.RWidth/2, RHeight,
                                   RWidth/2, RHeight);
            }
            else
            {
                Graphics.DrawLine(ArrowPen, (offsetX + 14) * 20, offsetY * 20, (offsetX + 14) * 20, RHeight);
                Graphics.DrawArrow(ArrowPen, (offsetX + 14) * 20, RHeight,
                   RWidth / 2, RHeight);
            }
        }

        private List<Block> _preBuildBranch(IEnumerable<COperator> operators, out Size s)
        {
            s = new Size();
            List<Block> branch = new List<Block>();
            if (operators == null) return branch;
            foreach (COperator o in operators)
            {
                var graph = new GraphicOperator(o);
                if (graph.Width > s.Width)
                    s.Width = graph.Width;
                s.Height += graph.Height + 2;
                branch.Add(graph);
            }

            return branch;
        }

        protected override void GetImage()
        {
            if (_operator.Type == OperatorType.If)
            {
                Graphics.DrawImage(_block.Image, _block.RX, _block.RY);//draw rombus of condition
                Block fl = _leftBranch.First(); 

                Graphics.DrawLine(ArrowPen, _block.RX, _block.RY + _block.RHeight/2,
                                  fl.RX + fl.RWidth/2, _block.RY + _block.RHeight/2);

                Graphics.DrawArrow(ArrowPen, fl.RX + fl.RWidth/2, _block.RY + _block.RHeight/2,
                                   fl.RX + fl.RWidth/2, fl.RY);//connect condition with left branch

                Graphics.DrawString(_operator.LeftText, Default, Brushes.Black,
                                    new Rectangle(_block.RX - 60, RY + 20, 60, 20), Centered);
                Graphics.DrawString(_operator.RightText, Default, Brushes.Black,
                                    new Rectangle(_block.RX + _block.RWidth + 20, RY + 20, 60, 20), Centered);

                if (_rightBranch.Count > 0)
                {
                    Block fr = _rightBranch.First();
                    Graphics.DrawLine(ArrowPen, _block.RX + _block.RWidth, _block.RY + _block.RHeight/2,
                                      fr.RX + fr.RWidth/2, _block.RY + _block.RHeight/2);

                    Graphics.DrawArrow(ArrowPen, fr.RX + fr.RWidth/2, _block.RY + _block.RHeight/2,
                                       fr.RX + fr.RWidth/2, fr.RY);//connect condition with right branch
                }
                else
                {
                    Graphics.DrawLine(ArrowPen, _block.RX + _block.RWidth, _block.RY + _block.RHeight/2,
                                      RWidth/2 + 14*20, _block.RY + _block.RHeight/2);
                    Graphics.DrawLine(ArrowPen, RWidth/2 + 14*20, _block.RY + _block.RHeight/2,
                                      RWidth/2 + 14*20, _block.RY + _block.RHeight + 4*20);//if else condition is empty draw lines to connect with the end of left branch
                }
            }
            else //switch
            {
                foreach (var graph in Blocks)
                {
                    if(graph!=Blocks.First())
                        Graphics.DrawArrow(ArrowPen, graph.RX + graph.RWidth - 40, graph.RY + graph.RHeight / 2,
                           RWidth, graph.RY + graph.RHeight / 2);
                    else
                    {
                        Graphics.DrawLine(ArrowPen, graph.RX + graph.RWidth - 40, graph.RY + graph.RHeight / 2,
                           RWidth, graph.RY + graph.RHeight / 2);                        
                    }
                    if (graph != Blocks.First())
                    {
                        Graphics.DrawArrow(ArrowPen, RWidth, graph.RY,
                                                     RWidth, graph.RY + graph.RHeight/2);
                    }
                }

                Graphics.DrawLine(ArrowPen, RWidth,Blocks.First().RY + Blocks.First().RHeight / 2,
                                            RWidth, RHeight);

                Graphics.DrawArrow(ArrowPen, RWidth, RHeight,
                                            _block.RX + _block.RWidth / 2, RHeight);

                Graphics.DrawArrow(ArrowPen, _block.RX + _block.RWidth / 2, RHeight - 40,
                    _block.RX + _block.RWidth / 2, RHeight);

                Graphics.DrawImage(_block.Image, _block.RX, _block.RY);
                
                var g = new FakeGraphics.FakeGraphics();
                g.DrawImage(Graphics, RWidth / 2 - _block.RWidth / 2, 0);
                

                Width += Width/2 - _block.Width/2;
            }
        }


        private class ConditionalSpecBlock : Block
        {
            public ConditionalSpecBlock()
            {
                Width = 16;
                Height = 4;
            }
            protected override void GetImage()
            {
                Graphics.DrawRombus(BlockPen, 0, 0, RWidth, RHeight);
                DrawText();
            }
        }
    }
}

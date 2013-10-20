using System;
using System.Collections.Generic;
using DronovsCharts.Analyze;
using System.Drawing;
using DronovsCharts.Visualize.Blocks;

namespace DronovsCharts.Visualize
{
    public class Visualizer
    {
        private List<COperator> _operators;
        public Image Image { get; set; }

        public Visualizer(List<COperator> operators)
        {
            _operators = operators;
            _draw();
        }

        private void _draw()
        {
            FakeGraphics.FakeGraphics g = new FakeGraphics.FakeGraphics();
            
            Block fake = new Block() { X = 0, Y = 0 };

            Block prev = null;
            foreach (COperator c in _operators)
            {

                var graph = new GraphicOperator(c) {X = 150};
                if (prev != null)
                {
                    graph.Y = prev.Y + prev.Height + 2;
                    Console.WriteLine(graph.Width);
                    graph.X = prev.X + prev.Width/2 - graph.Width/2;
                    g.DrawImage(graph.Image, graph.RX, graph.RY);


                    g.DrawArrow(Block.ArrowPen, prev.RX + prev.RWidth / 2 , prev.RY + prev.RHeight,
                                                prev.RX + prev.RWidth / 2, graph.RY);
                }
                else
                    g.DrawImage(graph.Image, graph.RX, 0);

                GC.Collect();
                
                prev = graph;
            }
            Image = g.Save();
        }

        
    }
}

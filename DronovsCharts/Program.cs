using System;
using System.IO;
using System.Text;
using DronovsCharts.Analyze;
using DronovsCharts.Visualize;
using System.Diagnostics;

namespace DronovsCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 6; i++)
            {
                GC.Collect();
                DateTime start = DateTime.Now;
                var c = new CPPFileAnalyzer(File.ReadAllText(i + ".cpp", Encoding.Default));
                var v = new Visualizer(c.Result);
                v.Image.Save(i+".png");
                Console.WriteLine((DateTime.Now-start).TotalMilliseconds);
                Process.Start(i + ".png");
                return;
            }
        }
    }
}

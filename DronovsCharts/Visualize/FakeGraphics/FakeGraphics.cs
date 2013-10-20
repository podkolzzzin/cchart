using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DronovsCharts.Visualize.FakeGraphics
{
    public class FakeGraphics:FakeElement
    {
        public List<FakeElement> Elements { get; set; }
        public static bool first = true;
        public bool f = false;
        private int _minX=int.MaxValue, _minY=int.MaxValue, _maxX, _maxY;
        public FakeGraphics()
        {
            if (first)
            {
                f = true;
                first = false;
            }
            Elements=new List<FakeElement>();
        }
        private void _update(FakeElement fake)
        {
            _minX = Math.Min(_minX, fake.X);
            _minY = Math.Min(_minY, fake.Y);
            _maxX = Math.Max(_maxX, fake.X + fake.Width);
            _maxY = Math.Max(_maxY, fake.Y + fake.Height);
        }

        public void DrawLine(Pen pen,int x1, int y1, int x2, int y2)
        {
            var line = new FakeLine() {Pen = pen,X1 = x1, Y1 = y1, X2 = x2, Y2 = y2};         
            Elements.Add(line);
            _update(Elements.Last());
        }

        public void DrawRectangle(Pen pen, int x, int y, int width, int height)
        {
            Elements.Add(new FakeRect() {Pen = pen,X = x, Y = y, Width = width, Height = height });
            _update(Elements.Last());
        }

        public void DrawArc(Pen pen,int x, int y, int w, int h, int startAngle, int sweepAngle)
        {
            Elements.Add(new FakeArc(){Pen = pen, X=x, Y=y,Width = w, Height = h, StartAngle = startAngle, SweepAngle = sweepAngle});
            _update(Elements.Last());
        }

        public void DrawString(string text, Font font, Brush brush, RectangleF rect, StringFormat format)
        {
            Elements.Add(new FakeText()
                {
                    Text = text,
                    Font = font,
                    Brush = brush,
                    Height = (int) rect.Height,
                    Width = (int) rect.Width,
                    X = (int) rect.X,
                    Y = (int) rect.Y,
                    Format = format
                });
        }

        public void DrawLines(Pen pen, params Point[] points)
        {
            for (int i = 1; i < points.Length; i++)
            {
                Elements.Add(new FakeLine()
                    {
                        Pen = pen,
                        X1 = points[i - 1].X,
                        Y1 = points[i - 1].Y,
                        X2 = points[i].X,
                        Y2 = points[i].Y
                    });
            }
        }

        public void DrawImage(FakeGraphics image, int x, int y)
        {
            foreach (var fakeElement in image.Elements)
            {
                if (fakeElement.GetType() != typeof (FakeLine))
                {
                    fakeElement.X += x;
                    fakeElement.Y += y;
                }
                else
                {
                    FakeLine fl = fakeElement as FakeLine;
                    fl.X1 += x;
                    fl.X2 += x;
                    fl.Y1 += y;
                    fl.Y2 += y;
                }
                Elements.Add(fakeElement);
                _update(Elements.Last());
            }
        }

        public Bitmap Save()
        {
            Bitmap bmp = new Bitmap(_maxX - _minX, _maxY - _minY);
            Graphics graphics = Graphics.FromImage(bmp);
            foreach (var fakeElement in Elements)
            {
                if (fakeElement.GetType() != typeof (FakeLine))
                {
                    fakeElement.X -= _minX;
                    fakeElement.Y -= _minY;
                }
                else
                {
                    FakeLine fl=fakeElement  as FakeLine;
                    fl.X1 -= _minX;
                    fl.X2 -= _minX;

                    fl.Y1 -= _minY;
                    fl.Y2 -= _minY;
                }
                fakeElement.Render(graphics);
            }
            return bmp;
        }

        public StringFormat Format { get; set; }

        internal void DrawString(string text, Font font, Brush brush, int x, int y)
        {
            Elements.Add(new FakeText() {Brush = brush, Font = font, X = x, Y = y, Text = text});
        }

        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}

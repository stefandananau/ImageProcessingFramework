using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Algorithms.Utilities
{
    public class Component
    {
        private List<Point> _points;

        private byte[] _color;

        public byte[] Color
        {
            get { return _color; }
        }

        public Component(byte b, byte g, byte r)
        {
            _points = new List<Point>();
            _color = new byte[3];
            _color[0] = b;
            _color[1] = g;
            _color[2] = r;
        }

        public bool Contains(Point point)
        {
            return _points.Any(p => point.X == p.X && point.Y == p.Y);
        }

        public void AddPoint(Point point)
        {
            _points.Add(point);
        }

        public int Size()
        {
            return _points.Count;
        }

        public Point LeftUp()
        {
            var x = _points.First().X;
            var y = _points.First().Y;
            foreach(var point in _points)
            {
                if(point.X < x)
                {
                    x = point.X;
                }
                if(point.Y < y)
                {
                    y = point.Y;
                }
            }
            return new Point(x, y);
        }

        public Point RightDown()
        {
            var x = _points.First().X;
            var y = _points.First().Y;
            foreach (var point in _points)
            {
                if (point.X > x)
                {
                    x = point.X;
                }
                if (point.Y > y)
                {
                    y = point.Y;
                }
            }
            return new Point(x, y);
        }
    }
}

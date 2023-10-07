using System.Windows;

namespace Framework.Utilities
{
    public static class PointHelper
    {
        private static double GetLower(double a, double b)
        {
            if (a < b) return a;
            return b;
        }

        private static double GetHigher(double a, double b)
        {
            if (a > b) return a;
            return b;
        }

        public static Point GetLeftTop(Point p1, Point p2)
        {
            return new Point(GetLower(p1.X, p2.X), GetLower(p1.Y, p2.Y));
        }

        public static Point GetRightBottom(Point p1, Point p2)
        {
            return new Point(GetHigher(p1.X, p2.X), GetHigher(p1.Y, p2.Y));
        }
    }
}

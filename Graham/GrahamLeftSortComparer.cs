using System.Collections.Generic;

namespace Graham
{
    public class GrahamLeftSortComparer : IComparer<Point>
    {
        private readonly Point _point0;

        public GrahamLeftSortComparer(Point point0)
        {
            _point0 = point0;
        }

        public int Compare(Point x, Point y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            var d = ((_point0.X - x.X) * (y.Y - x.Y)) - ((_point0.Y - x.Y) * (y.X - x.X));
            return d < 0.0 ? -1 : 1;
        }
    }
}

using System;

namespace Core.Model
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Point point && (Math.Abs(point.X - X) < 0.00001 && Math.Abs(point.Y - Y) < 0.00001);
        }

        protected bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return X.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + Y.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
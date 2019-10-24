using System;
using Core.Model;

namespace LongestLineInTheSet
{
    public class Slope : Point
    {
        public Slope(double xDif, double yDif) : base(Math.Round(xDif, 2), Math.Round(yDif, 2))
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;

namespace LongestLineInTheSet
{
    public class Counter
    {
        public List<Point> GetMaxPointsOnTheSameLine(IEnumerable<Point> points)
        {
            var pointsArrayed = points.ToArray();
            var pointsQuantity = pointsArrayed.Length;
            if (pointsQuantity < 2)
            {
                return pointsArrayed.ToList();
            }
            var slopesContainer = new Dictionary<double, List<Point>>();
            for (var i = 0; i < pointsQuantity; i++)
            {
                for (var j = i + 1; j < pointsQuantity; j++)
                {
                    var secondPoint = pointsArrayed[j];
                    var firstPoint = pointsArrayed[i];

                    var yDif = secondPoint.Y - firstPoint.Y;
                    var xDif = secondPoint.X - firstPoint.X;

                    
                    yDif = Math.Round(yDif, 3);
                    xDif = Math.Round(xDif, 3);
                    var slope = Math.Round(yDif / xDif, 3);

                    if (!slopesContainer.ContainsKey(slope))
                    {
                        var pointsPair = new List<Point> { firstPoint, secondPoint };
                        slopesContainer.Add(slope, pointsPair);
                    }
                    else
                    {
                        var pointsMappedToSlope = slopesContainer[slope];
                        if (!pointsMappedToSlope.Contains(firstPoint))
                        {
                            pointsMappedToSlope.Add(firstPoint);
                        }
                        if (!pointsMappedToSlope.Contains(secondPoint))
                        {
                            pointsMappedToSlope.Add(secondPoint);
                        }

                        slopesContainer[slope] = pointsMappedToSlope;
                    }
                }
            }

            var maxCollinearPointsSet = slopesContainer.Values.OrderByDescending(x => x.Count).FirstOrDefault();
            return maxCollinearPointsSet;
        }

    }
}

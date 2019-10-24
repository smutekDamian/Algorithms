using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Model;
using Core.Utils;

namespace Graham
{
    public class Graham
    {
        private const string PointsCsvFilePath = @"App_Data\punktyPrzykladowe.csv";
        private const string ResultFilePath = @"App_Data\result.csv";

        private static void Main()
        {
            var pointsParser = new PointsParser();
            var points = pointsParser.ParseFromFile(PointsCsvFilePath).ToList();
            var envelope = GetEnvelope(points);

            var enumerable = envelope.ToList();
            foreach (var point in enumerable)
            {
                Console.WriteLine(point);
            }
            pointsParser.WritePointsToFile(enumerable, ResultFilePath);

            Console.WriteLine($"Results ready in file {ResultFilePath}");
            Console.ReadKey();
        }


        public static IEnumerable<Point> GetEnvelope(IEnumerable<Point> points)
        {
            points = points.ToList();
            var farestDownPoint = GetFarestDownPoint(points);
            var sortedPoints = AngleSort(points, farestDownPoint).ToArray();

            var pointsLength = sortedPoints.Length;
            var stack = new Stack<Point>();
            stack.Push(sortedPoints[0]);
            stack.Push(sortedPoints[1]);
            stack.Push(sortedPoints[2]);

            for (var i = 3; i < pointsLength; i++)
            {
                while (IsStrictlyRight(stack.ElementAt(0), stack.ElementAt(1), sortedPoints[i]))
                {
                    stack.Pop();
                }
                stack.Push(sortedPoints[i]);
            }

            return stack.Reverse().ToList();
        }

        public static Point GetFarestDownPoint(IEnumerable<Point> points)
        {
            return points.Aggregate((min, point) => min.Y < point.Y ? min : point);
        }

        public static IEnumerable<Point> AngleSort(IEnumerable<Point> source, Point point0)
        {
            var comparer = new GrahamLeftSortComparer(point0);
            var angleSort = source.ToList();
            angleSort.Remove(point0);
            angleSort.Sort(comparer);
            var result = new List<Point>()
            {
                point0
            };
            result.AddRange(angleSort);
            return result;
        }

        private static bool IsStrictlyRight(Point pt1, Point pt2, Point point)
        {
            return GetDeterminant(pt1, pt2, point) < 0.0;
        }

        private static double GetDeterminant(Point firstPointOfStretch, Point secondPointOfStretch, Point pointToCalculateDet)
        {
            var det = (pointToCalculateDet.X - firstPointOfStretch.X) * (secondPointOfStretch.Y - firstPointOfStretch.Y) -
                   (pointToCalculateDet.Y - firstPointOfStretch.Y) * (secondPointOfStretch.X - firstPointOfStretch.X);
            return det;
        }
    }
}

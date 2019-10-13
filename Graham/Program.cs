using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Core.Helper;
using Core.Model;

namespace Graham
{
    public class Program
    {
        private const string PointsCsvFilePath = @"App_Data\punktyPrzykladowe.csv";
        private const string ResultFilePath = @"App_Data\result.csv";

        private static void Main()
        {
            var points = GetPointsFromFile(PointsCsvFilePath).ToList();
            var envelope = GetEnvelope(points);

            foreach (var point in envelope)
            {
                Console.WriteLine(point);
            }
            WriteResultToFile(envelope);

            Console.WriteLine($"Results ready in file {ResultFilePath}");
            Console.ReadKey();
        }
        private static IEnumerable<Point> GetPointsFromFile(string filePath)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            var fileContent = FileHelper.GetFromFile(path);
            foreach (var line in fileContent)
            {
                var pointCoordinates = line.Replace(" ", string.Empty).Split(',');
                if (pointCoordinates.FirstOrDefault(x => x.Equals(string.Empty)) != null)
                {
                    continue;
                }
                yield return new Point
                {
                    X = double.Parse(pointCoordinates[0], CultureInfo.InvariantCulture),
                    Y = double.Parse(pointCoordinates[1], CultureInfo.InvariantCulture)
                };
            }
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

        private static void WriteResultToFile(IEnumerable<Point> envelope)
        {
            envelope = envelope.ToList();
            using (var writer = new StreamWriter(ResultFilePath))
            {
                writer.WriteLine("X,Y");
                writer.Flush();
                foreach (var point in envelope)
                {
                    writer.WriteLine(point.ToString());
                    writer.Flush();
                }

                writer.WriteLine(envelope.First().ToString());
            }
        }
    }
}

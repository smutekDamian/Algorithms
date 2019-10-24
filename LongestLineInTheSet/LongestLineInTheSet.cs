using System;
using System.Linq;
using Core.Utils;

namespace LongestLineInTheSet
{
    public class LongestLineInTheSet
    {
        private const string PointsCsvFilePath = @"App_Data\test_points.csv";
        private const string LargeSetFilePath = @"App_Data\points.csv";
        private const string ResultFilePath = @"App_Data\result.csv";

        public static void Main(string[] args)
        {
            var pointsParser = new PointsParser(';');
            var points = pointsParser.ParseFromFile(PointsCsvFilePath).ToList();
            var counter = new Counter();
            var resultsPoints = counter.GetMaxPointsOnTheSameLine(points);

            foreach (var point in resultsPoints)
            {
                Console.WriteLine(point);
            }

            pointsParser.WritePointsToFile(resultsPoints, ResultFilePath);
            Console.WriteLine($"Result points have been written into {ResultFilePath}");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Core.Helper;
using Core.Model;

namespace Core.Utils
{
    public class PointsParser
    {
        private char separator;

        public PointsParser(char separator)
        {
            this.separator = separator;
        }

        public PointsParser()
        {
            separator = ',';
        }

        public IEnumerable<Point> ParseFromFile(string filePath)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            var fileContent = FileHelper.GetFromFile(path);
            foreach (var line in fileContent)
            {
                var pointCoordinates = line.Replace(" ", string.Empty).Split(separator);
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
    }
}

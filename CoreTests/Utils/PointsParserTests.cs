using System.IO;
using System.Linq;
using Core.Utils;
using Xunit;

namespace CoreTests.Utils
{
    public class PointsParserTests
    {
        [Fact]
        public void ShouldThrowExceptionWhenFileNotExists()
        {
            //Arrange
            const string incorrectFilePath = "wrong/filepath";
            var pointsParser = new PointsParser();

            //Act
            void Action()
            {
                var unused = pointsParser.ParseFromFile(incorrectFilePath).ToList();
            }

            //Assert
            Assert.Throws<FileNotFoundException>(Action);
        }

        [Fact]
        public void ShouldParsePointsCorrectly()
        {
            //Arrange
            const string testPointsFilePath = @"App_Data/test_points.csv";
            var pointsParser = new PointsParser(';');

            //Act
            var points = pointsParser.ParseFromFile(testPointsFilePath).ToArray();

            //Assert
            Assert.True(points.Count() == 35);
            Assert.True(points[16].X.Equals(600.2090200277408));
            Assert.True(points[16].Y.Equals(-5338.249399114086));
        }
    }
}

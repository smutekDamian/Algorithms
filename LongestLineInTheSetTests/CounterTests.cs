using System.Linq;
using Core.Model;
using Core.Utils;
using LongestLineInTheSet;
using Xunit;

namespace LongestLineInTheSetTests
{
    public class CounterTests
    {
        #region Points

        private readonly Point _p1 = new Point(-1.0,1.0);
        private readonly Point _p2 = new Point(0.0,0.0);
        private readonly Point _p3 = new Point(1.0,1.0);
        private readonly Point _p4 = new Point(2.0,2.0);
        private readonly Point _p5 = new Point(3.0,3.0);
        private readonly Point _p6 = new Point(3.0,4.0);
        #endregion

        [Fact]
        public void ShouldFindMaximumNumberOfPointsOnTheSameLine()
        {
            //Arrange
            var points = new[]
            {
                _p1, _p2, _p3, _p4, _p5, _p6
            };
            var counter = new Counter();

            //Act
            var result = counter.GetMaxPointsOnTheSameLine(points).ToList();

            //Assert
            Assert.True(result.Count.Equals(4));
            Assert.Contains(_p2, result);
            Assert.Contains(_p3, result);
            Assert.Contains(_p4, result);
            Assert.Contains(_p5, result);
        }

        [Fact]
        public void ShouldFindMaximumNumberOfCollinearPointsFromSmallTestDataSet()
        {
            //Arrange
            var testFilePath = @"App_Data\test_points.csv";
            var counter = new Counter();
            var pointParser = new PointsParser(';');
            var points = pointParser.ParseFromFile(testFilePath);

            //Act 
            var result = counter.GetMaxPointsOnTheSameLine(points).ToList();

            //Assert
            Assert.True(result.Count.Equals(9));
            Assert.Contains(new Point(711.0444231193819, 2587.785776220059), result);
            Assert.Contains(new Point(804.6479386984755, 2931.0296915527624), result);
            Assert.Contains(new Point(525.6395474043396, 1907.906446170427), result);
            Assert.Contains(new Point(918.6941461280686, 3349.236919398833), result);
            Assert.Contains(new Point(61.87015807447116, 207.2649689757887), result);
            Assert.Contains(new Point(159.200240530608, 564.1741980278756), result);
            Assert.Contains(new Point(47.91801491298253, 156.1024862805192), result);
            Assert.Contains(new Point(754.9464792405877, 2748.774533329994), result);
            Assert.Contains(new Point(529.3712249217416, 1921.59050059838), result);
        }
    }
}

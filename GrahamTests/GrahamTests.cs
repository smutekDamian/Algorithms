using System.Linq;
using Graham;
using NUnit.Framework;

namespace GrahamTests
{
    [TestFixture]
    public class GrahamTests
    {
        private static readonly Point P1 = new Point
        {
            X = -1.0,
            Y = 1.2
        };
        private static readonly Point P2 = new Point
        {
            X = 1.0,
            Y = 1.1
        };
        private static readonly Point P3 = new Point
        {
            X = -3.2,
            Y = 0.6
        };
        private static readonly Point P4 = new Point
        {
            X = 3.0,
            Y = -1.2
        };
        private static readonly Point P5 = new Point
        {
            X = -0.3,
            Y = -3.2
        };
        private static readonly Point P6 = new Point
        {
            X = -12.0,
            Y = 0.2
        };

        private readonly Point[] _points = {
            P1,
            P2,
            P3,
            P4,
            P5,
            P6
        };
        [Test]
        public void ShouldGetFarestPoint()
        {
            //Arrange

            //Act
            var resultPoint = Program.GetFarestDownPoint(_points);

            //Asset
            Assert.IsTrue(resultPoint.X.Equals(-0.3));
            Assert.IsTrue(resultPoint.Y.Equals(-3.2));
        }

        [Test]
        public void ShouldSortByAngle()
        {
            //Arrange
            var p0 = Program.GetFarestDownPoint(_points);


            //Act
            var sorted = Program.AngleSort(_points, p0).ToArray();

            //Assert
            Assert.IsTrue(sorted[0].X.Equals(p0.X));
            Assert.IsTrue(sorted[0].Y.Equals(p0.Y));

            Assert.IsTrue(sorted[1].X.Equals(P4.X));
            Assert.IsTrue(sorted[1].Y.Equals(P4.Y));

            Assert.IsTrue(sorted[2].X.Equals(P2.X));
            Assert.IsTrue(sorted[2].Y.Equals(P2.Y));

            Assert.IsTrue(sorted[3].X.Equals(P1.X));
            Assert.IsTrue(sorted[3].Y.Equals(P1.Y));

            Assert.IsTrue(sorted[4].X.Equals(P3.X));
            Assert.IsTrue(sorted[4].Y.Equals(P3.Y));

            Assert.IsTrue(sorted[5].X.Equals(P6.X));
            Assert.IsTrue(sorted[5].Y.Equals(P6.Y));
        }

        [Test]
        public void GetEnvelopeTest()
        {
            //Arrange

            #region Points
            var a = new Point
            {
                X = -3.0,
                Y = -1.0
            };
            var b = new Point
            {
                X = 3.0,
                Y = -0.5
            };
            var c = new Point
            {
                X = 1.0,
                Y = -0.5
            };
            var d = new Point
            {
                X = 2.0,
                Y = 1.0
            };
            var e = new Point
            {
                X = 2.5,
                Y = 2.5
            };
            var f = new Point
            {
                X = 1.5,
                Y = 3.0
            };
            var g = new Point
            {
                X = 1.0,
                Y = 5.0
            };
            var h = new Point
            {
                X = -0.5,
                Y = 1.0
            };
            var i = new Point
            {
                X = -1.5,
                Y = 4.5
            };
            var j = new Point
            {
                X = -2.0,
                Y = 3.5
            };
            #endregion

            var points = new[]
            {
                a,
                b,
                c,
                d,
                e,
                f,
                g,
                h,
                i,
                j
            };

            var resultEnvelop = new[]
            {
                a,
                b,
                e,
                g,
                i,
                j
            };

            //Act 
            var envelop = Program.GetEnvelope(points).ToArray();

            //Assert
            Assert.IsTrue(envelop.Length.Equals(resultEnvelop.Length));
            Assert.IsTrue(envelop[0].Equals(resultEnvelop[0]));
            Assert.IsTrue(envelop[1].Equals(resultEnvelop[1]));
            Assert.IsTrue(envelop[2].Equals(resultEnvelop[2]));
            Assert.IsTrue(envelop[3].Equals(resultEnvelop[3]));
            Assert.IsTrue(envelop[4].Equals(resultEnvelop[4]));
            Assert.IsTrue(envelop[5].Equals(resultEnvelop[5]));
        }
    }
}

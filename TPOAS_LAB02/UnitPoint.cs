using STP_LAB02;

namespace TPOAS_LAB02
{
    [TestClass]
    public class UnitPoint
    {
        [TestMethod]
        public void TestConvertFI()
        {
            // Arrange
            double negativeFI = -3.5 * Math.PI;
            double positiveFI = 4.5 * Math.PI;
            double normalFI = Math.PI / 2;


            // Act
            Point point1 = new Point(1, negativeFI);
            Point point2 = new Point(1, positiveFI);
            Point point3 = new Point(1, normalFI);

            // Assert
            Assert.AreEqual(point1.pFI, point2.pFI);
            Assert.AreEqual(point1.pFI, point3.pFI);
        }

        [TestMethod]
        public void TestConvertR()
        {
            // Arrange
            double negativeR = -3.5;
            double positiveR = 4.5;
            double zeroR = 0;


            // Act
            Point point1 = new Point(negativeR, 1);
            Point point2 = new Point(positiveR, 1);
            Point point3 = new Point(zeroR, 1);

            // Assert
            Assert.AreEqual(point1.pR, zeroR);
            Assert.AreEqual(point2.pR, positiveR);
            Assert.AreEqual(point3.pR, zeroR);
        }

        [TestMethod]
        public void TestDistOX() 
        {
            // Arrange
            double r = 10 * Math.Sqrt(2);
            double fi = Math.PI / 4;
            double expect = 10;

            // Act
            Point point1 = new Point(r, fi);
            Point point2 = new Point(r, -fi);
            Point point3 = new Point(r, Math.PI - fi);
            Point point4 = new Point(r, Math.PI + fi);

            // Assert
            Assert.AreEqual(expect, point1.distOX(), 0.0001);
            Assert.AreEqual(expect, point2.distOX(), 0.0001);
            Assert.AreEqual(expect, point3.distOX(), 0.0001);
            Assert.AreEqual(expect, point4.distOX(), 0.0001);
        }

        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, -1);

            // Act
            Point actual1 = point1.add(point1, point2);
            Point actual2 = point2.add(point2, point1);

            bool isEqualVar = (actual1.pR == 2) && (Math.PI - actual1.pFI < 0.00001);
            bool isEqualObj = (actual1.pR == actual2.pR) && (actual1.pR == actual2.pR);
            // Assert
            Assert.IsTrue(isEqualVar);
            Assert.IsTrue(isEqualObj);
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange
            Point point = new Point();
            

            // Act
            bool isEqualVar = (point.pR == 0) && (point.pFI == 0);
            
            // Assert
            Assert.IsTrue(isEqualVar);

        }
    }
}
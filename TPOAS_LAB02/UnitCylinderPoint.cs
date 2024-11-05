// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using STP_LAB02;

namespace TPOAS_LAB02
{
    [TestClass]
    public class UnitCylinderPoint
    {
        [TestMethod]
        public void TestConvertFI()
        {
            // Arrange
            double negativeFI = -3.5 * Math.PI;
            double positiveFI = 4.5 * Math.PI;
            double normalFI = Math.PI / 2;


            // Act
            CylinderPoint point1 = new CylinderPoint(1, negativeFI, 1);
            CylinderPoint point2 = new CylinderPoint(1, positiveFI, 1);
            CylinderPoint point3 = new CylinderPoint(1, normalFI, 1);

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
            CylinderPoint point1 = new CylinderPoint(negativeR, 1, 1);
            CylinderPoint point2 = new CylinderPoint(positiveR, 1, 1);
            CylinderPoint point3 = new CylinderPoint(zeroR, 1, 1);

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
            double z = 10;
            double expect = 10 * Math.Sqrt(2);

            // Act
            CylinderPoint point1 = new CylinderPoint(r, fi, z);
            CylinderPoint point2 = new CylinderPoint(r, -fi, z);
            CylinderPoint point3 = new CylinderPoint(r, fi, -z);
            CylinderPoint point4 = new CylinderPoint(r, -fi , -z);

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
            CylinderPoint point1 = new CylinderPoint(1, 1, 1);
            CylinderPoint point2 = new CylinderPoint(1, -1, 1);

            // Act
            CylinderPoint actual1 = point1.add(point1, point2);
            CylinderPoint actual2 = point2.add(point2, point1);

            bool isEqualVar = (actual1.pR == 2) && (Math.PI - actual1.pFI < 0.00001) && (actual1.pZ == 2);
            bool isEqualObj = (actual1.pR == actual2.pR) && (actual1.pR == actual2.pR) && (actual1.pZ == actual2.pZ);
            // Assert
            Assert.IsTrue(isEqualVar);
            Assert.IsTrue(isEqualObj);
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange
            CylinderPoint point = new CylinderPoint();


            // Act
            bool isEqualVar = (point.pR == 0) && (point.pFI == 0) && (point.pZ == 0);

            // Assert
            Assert.IsTrue(isEqualVar);

        }
    }
}

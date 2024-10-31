using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_LAB02
{
    public class CylinderPoint : Point
    {
        private double z;
        public CylinderPoint()
        {
            r = 0;
            fi = 0;
            z = 0;
        }
        public CylinderPoint(double R, double FI, double Z) : base(R, FI)
        {
            z = Z;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Координаты относительно плоскости: {0:0.##}", z);
        }
        public void Init(double R, double FI, double Z)
        {
            base.Init(R, FI);
            z = Z;
        }
        public override double distOX()
        {
            double y = base.distOX();
            double d = Math.Sqrt(Math.Pow(y, 2) + Math.Pow(z, 2));
            return d;
        }
        public double pZ
        {
            get => z;
            set => z = value;
        }

        public CylinderPoint add(CylinderPoint p1, CylinderPoint p2)
        {
            double r = p1.pR + p2.pR;
            double fi = p1.pFI + p2.pFI;
            double z = p1.pZ + p2.pZ;
            CylinderPoint cylinderPoint = new CylinderPoint(r, fi, z);
            return cylinderPoint;
        }
    }
}

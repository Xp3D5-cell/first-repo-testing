using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_LAB02
{
        public class Point
        {
            protected double r;
            protected double fi;

            public Point()
            {
                r = 0;
                fi = 0;
            }
            public Point(double R, double FI)
            {
                r = convertRadius(R);
                fi = convertFib(FI);
            }

            public double pFI { get => fi; }
            public double pR { get => r; }

            public void Init(double R, double FI)
            {
                r = convertRadius(R);
                fi = convertFib(FI);
            }

            public void Read()
            {
                double R, FI;
                System.Console.Write("Введите радиус от точки O: ");
                R = double.Parse(Console.ReadLine());
                if (R < 0)
                {
                    R = convertRadius(R);
                    System.Console.Write("Радиус меньше 0. Он приведен к значению 0.");
                }
                System.Console.Write("Введите угол в радианах: ");
                FI = double.Parse(Console.ReadLine()); ;
                if ((FI < 0) || (FI > 2 * Math.PI))
                {
                    FI = convertFib(FI);
                    System.Console.Write("Угол не входит в диапазон [0; 2 * PI]. Угол приведен к значению : ");
                }

                r = R;
                fi = FI;
            }

            public virtual void Display()
            {
                System.Console.WriteLine("Растояние от точки O: {0:0.##}", r);
                System.Console.WriteLine("Угол: {0:0.00}", fi);
            }

            public Point add(Point p1, Point p2)
            {
                Point result = new Point();
                double R = p1.pR + p2.pR;
                double FI = p1.pFI + p2.pFI;
                result.Init(R, FI);
                return result;
            }

            public virtual double distOX()
            {
                return r * Math.Sin(fi);
            }

            private double convertFib(double FI)
            {
                double PI = Math.PI;
                if (FI < 0.1)
                {
                    while (FI <= -2 * PI) FI += 2 * PI;
                    FI = 2 * PI + FI;
                }
                else
                {
                    while (FI > 2 * PI) FI -= 2 * PI;
                }
                return FI;
            }

            private double convertRadius(double R)
            {
                if (R < 0) R = 0;
                return R;
            }
        }
}


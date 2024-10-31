using System.Drawing;

namespace STP_LAB02
{
    /*!
   @brief Главный класс, имеющий функцию Main.


*/
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int cP = 15;
            int cC = 15;

            List<Point> arrayP = new List<Point>();

            int r;
            for (int i = 0; i < 30; i++)
            {
                r = random.Next() % 2;
                if (r == 1 && cP != 0)
                {
                    Point point = new Point(5 + i, (i * Math.PI) / 24);
                    arrayP.Add(point);
                    cP--;
                }
                else if (r == 0 && cC != 0)
                {
                    CylinderPoint point = new CylinderPoint(5 + i, (i * Math.PI) / 24, i - 15);
                    arrayP.Add(point);
                    cC--;
                }
                else if (cC != 0)
                {
                    CylinderPoint point = new CylinderPoint(5 + i, (i * Math.PI) / 24, i - 15);
                    arrayP.Add(point);
                    cC--;
                }
                else
                {
                    Point point = new Point(5 + i, (i * Math.PI) / 24);
                    arrayP.Add(point);
                    cP--;
                }
            }
            int n = 1;
            cP = 0;
            cC = 0;
            double sumDistOXPoints = 0;
            double sumDistOXCylinderPoints = 0;
            foreach (Point point in arrayP)
            {
                Console.WriteLine("===== Точка {0} =====", n);
                point.Display();
                n++;
                Type type = point.GetType();
                if (type.Name == "Point")
                {
                    cC++;
                    sumDistOXCylinderPoints += point.distOX();
                }
                else
                {
                    cP++;
                    sumDistOXPoints += point.distOX();
                }
            }
            Console.WriteLine("Количество объектов базового класса: {0}", cP);
            Console.WriteLine("Cумма расстояний от оси OX точек базового класса: {0:0.##}", sumDistOXPoints);
            Console.WriteLine("Количество объектов производного класса: {0}", cC);
            Console.WriteLine("Cумма расстояний от оси OX точек производного класса: {0:0.##}", sumDistOXCylinderPoints);

        }
    }
}

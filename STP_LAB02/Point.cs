using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_LAB02
{
    /*!
	@brief Класс точки, заданной в полярных координатах.
    
    Данный класс создан для работы с точками, заданными в полярной системе координат. Имеется возможность их сложения и измерения расстояния до оси OX.
    
    @image html shema_point1.jpg
    @todo
    Реализовать метод измерения расстояния между точками.
	
*/
    public class Point
    {
        /// Длина радиус-вектора от начала координат (0,0) до точки.
        protected double r;
        /// Угол между радиус-вектором и осью OX (в радианах).
        protected double fi;
        /*!
        @brief Конструктор класса по умолчанию, задающий длину радиус-вектора и угла.
        @return Возвращает точку, с координатами (0,0)
         */
        public Point()
        {
            r = 0;
            fi = 0;
        }
        /*!
        @brief Конструктор класса, задающий длину радиус-вектора и угла.
        @param[in] R Длина радиус-вектора.
        @param[in] FI Угол между радиус-вектором и осью OX (в радианах).
         */
        public Point(double R, double FI)
        {
            r = convertRadius(R);
            fi = convertFib(FI);
        }
        /*!
         @brief Свойство, для получения значения длины радиус-вектора.
         */
        public double pFI { get => fi; }
        /*!
         @brief Свойство, для получения значения угла.
         */
        public double pR { get => r; }

        /*!
        @brief Процедура, присваивающая длину радиус-вектора и угла.
        @param[in] R Длина радиус-вектора.
        @param[in] FI Угол между радиус-вектором и осью OX (в радианах).
         */
        public void Init(double R, double FI)
        {
            r = convertRadius(R);
            fi = convertFib(FI);
        }

        /*!
        @brief Процедура интерактивного создания точки.

        Данная процедура используется в программе класса Program для задания пользователем точек.
        */
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

        /*!
        @brief Процедура вывода параметров точки.

        Данная процедура используется в программе класса Program для вывода значений точек пользователю на экран.
        */
        public virtual void Display()
        {
            System.Console.WriteLine("Растояние от точки O: {0:0.##}", r);
            System.Console.WriteLine("Угол: {0:0.00}", fi);
        }

        /*!
         @brief Функция сложения точек
        
        @param[in] p1 Первая точка.
        @param[in] p2 Вторая точка.
        @return Точка в полярной системе координат, длина радиус-вектора которого равна сумме длин радиус-векторов двух точек, угол которого равен сумме углов двух точек.
         */
        public Point add(Point p1, Point p2)
        {
            Point result = new Point();
            double R = p1.pR + p2.pR;
            double FI = p1.pFI + p2.pFI;
            result.Init(R, FI);
            return result;
        }

        /*!
         @brief Функция вычисления расстояния точки от оси OX.
        Расстояние точки от оси OX, вычисляемое по формуле 
        \f[y=\left|r*\sin(\phi)  \right|\f]
        @return Растояние точки от оси OX.

         */
        public virtual double distOX()
        {
            return Math.Abs(r * Math.Sin(fi));
        }

        /*!
         @brief Функция приведения угла.
        Вспомогательная функция, необходимая для приведения угла выходящего за полуинтервал [0;2*PI)
        @param[in] FI Неприведенный угол между радиус-вектором и осью OX (в радианах).
         @return Приведенный угол между радиус-вектором и осью OX (в радианах).
         */
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

        /*!
          @brief Функция приведения длины радиус-вектора.
        Вспомогательная функция, необходимая для приведения длины радиус-вектора к неотрицательным значениям [0; +Inf).
        @param[in] R Неприведенная длина радиус-вектора.
         @return Приведенная длина радиус-вектора.
         */
        private double convertRadius(double R)
        {
            if (R < 0) R = 0;
            return R;
        }
    }
}


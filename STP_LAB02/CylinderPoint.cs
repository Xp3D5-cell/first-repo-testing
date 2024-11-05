// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP_LAB02
{
    /*!
   @brief Класс точки, заданной в полярных координатах

   Данный класс создан для работы с точками, заданными в цилиндрической системе координат. Имеется возможность их сложения и измерения расстояния до оси OX.
   @image html shema_point2.jpg
   @todo
   Реализовать метод измерения расстояния между точками.

*/
    public class CylinderPoint : Point
    {
        /// Расстояние относительно плоскости XOY (высота)
        private double z;
        /*!
        @brief Конструктор класса по умолчанию, задающий длину радиус-вектора, угла и высоту.
        @return Возвращает точку, с координатами (0,0,0)
         */
        public CylinderPoint()
        {
            r = 0;
            fi = 0;
            z = 0;
        }
        /*!
        @brief Конструктор класса, задающий длину радиус-вектора, угла и высоты.
        @param[in] R Длина радиус-вектора.
        @param[in] FI Угол между радиус-вектором и осью OX (в радианах).
        @param[in] Z Расстояние относительно плоскости XOY (высота)
         */
        public CylinderPoint(double R, double FI, double Z) : base(R, FI)
        {
            z = Z;
        }
        /*!
       @brief Процедура вывода параметров точки.

       Данная процедура используется в программе класса Program для вывода значений точек пользователю на экран.
       */
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Координаты относительно плоскости: {0:0.##}", z);
        }
        /*!
        @brief Процедура, присваивающая длину радиус-вектора и угла.
        @param[in] R Длина радиус-вектора.
        @param[in] FI Угол между радиус-вектором и осью OX (в радианах).
        @param[in] Z Расстояние относительно плоскости XOY (высота)
         */
        public void Init(double R, double FI, double Z)
        {
            base.Init(R, FI);
            z = Z;
        }
        /*!
         @brief Функция вычисления расстояния точки от оси OX.
         @return Растояние точки от оси OX.
         */
        public override double distOX()
        {
            double y = base.distOX();
            double d = Math.Sqrt(Math.Pow(y, 2) + Math.Pow(z, 2));
            return d;
        }
        /*!
         @brief Свойство, для получения значения высоты.
         */
        public double pZ
        {
            get => z;
        }
        /*!
         @brief Функция сложения точек
        
        @param[in] p1 Первая точка.
        @param[in] p2 Вторая точка.
        @return Точка в цилиндрической системе координат, длина радиус-вектора которого равна сумме длин радиус-векторов двух точек, угол которого равен сумме углов двух точек, высота равна сумме высот двух точек.
         */
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

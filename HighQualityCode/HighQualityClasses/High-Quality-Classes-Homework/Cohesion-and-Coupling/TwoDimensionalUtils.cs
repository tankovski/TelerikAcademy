using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    class TwoDimensionalUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDiagonalXY(double width,double height)
        {
            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            double distance = CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            double distance = CalcDistance2D(0, 0, height, depth);
            return distance;
        }
    }
}

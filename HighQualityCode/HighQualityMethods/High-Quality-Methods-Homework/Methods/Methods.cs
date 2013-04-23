using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }
            double semiperimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));

            return area;
        }

        static string DigitLikeWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("This is not a digit!");
            }
        }

        static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("The array is null or empty");
            }

            int max = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        private static void PrintAligned(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        private static void PrintLikePercents(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        private static void PrintWithFixedPoints(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        private static bool CheckLineBetweenTwoPointsIsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        private static bool CheckLineBetweenTwoPointsIsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitLikeWord(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintWithFixedPoints(1.3);
            PrintLikePercents(0.75);
            PrintAligned(2.30);

            var point1 = new { x = 3, y =-1};
            var point2 = new { x = 3, y = 2.5 };
            Console.WriteLine(CalcDistance(point1.x, point1.y, point2.x, point2.y));
            Console.WriteLine("Horizontal? " + CheckLineBetweenTwoPointsIsHorizontal(point1.y,point2.y));
            Console.WriteLine("Vertical? " + CheckLineBetweenTwoPointsIsVertical(point1.x,point2.x));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, ComparePeople.FindWhoIsOlder(peter,stella));
        }
    }
}

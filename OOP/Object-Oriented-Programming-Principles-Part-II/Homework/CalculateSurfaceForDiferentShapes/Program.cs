using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSurfaceForDiferentShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make a circle and print the width and height to see, are they equal to radius.
            Circle circle = new Circle(5);
            Console.WriteLine(circle.Width);
            Console.WriteLine(circle.Height);         

            //Make triangle.
            Triangle triangle = new Triangle(5, 6);

            //Make rectangle
            Rectangle rectangle = new Rectangle(5, 4);

            //Make array with shapes and calculate their surfaces
            Console.WriteLine("------------------------------------");
            Shape[] array = { circle, triangle, rectangle };
            foreach (Shape shape in array)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}

using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle()
        {
        }

        public Rectangle(double width, double height)
        {
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Width must be a positive number bigger than zero!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be a positive number bigger than zero!");
                }
                this.height = value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = this.Width * this.Height;

            return surface;
        }
    }
}

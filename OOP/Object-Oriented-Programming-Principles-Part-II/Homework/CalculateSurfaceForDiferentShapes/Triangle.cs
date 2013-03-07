using System;

public class Triangle:Shape
{
    //Constructor
    public Triangle(double width, double height)
        : base(width, height)
    { }

    //Method
    public override double CalculateSurface()
    {
        return (this.Height * this.Width) / 2;
    }
}


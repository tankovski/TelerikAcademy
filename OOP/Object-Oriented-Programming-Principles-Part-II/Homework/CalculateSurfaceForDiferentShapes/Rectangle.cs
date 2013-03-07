using System;

public class Rectangle:Shape
{
    //Constructor
    public Rectangle(double width, double height)
        : base(width, height)
    { }

    //Method
    public override double CalculateSurface()
    {
        return this.Height * this.Width;
    }
}


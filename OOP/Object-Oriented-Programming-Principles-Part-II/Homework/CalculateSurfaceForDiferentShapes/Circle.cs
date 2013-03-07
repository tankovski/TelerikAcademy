using System;

public class Circle:Shape
{
    //Fields
    private double radius;

    //Properties
    public double Radius
    {
        get { return this.radius; }
        set 
        {
            if (value<=0)
            {
                throw new ArgumentException("The radius must be bigger than zero!");
            }
            this.radius = value;
        }
    }

    //Constructor
    public Circle(double radius):base(radius,radius)
    {
        this.Radius = radius;
        
        
    }

    //Method
    public override double CalculateSurface()
    {
        return Math.PI * (radius * radius);
    }
}


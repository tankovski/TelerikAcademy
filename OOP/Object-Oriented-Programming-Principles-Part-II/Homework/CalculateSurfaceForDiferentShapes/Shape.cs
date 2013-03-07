using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Shape
{
    //Fields
    private double width;
    private double height;

    //Properties
    public double Width
    {
        get { return this.width; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("The width must be bigger than zero!");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The height must be bigger than zero!");
            }
            this.height = value;
        }
    }
    

    //Constructor
    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    //Method
    public abstract double CalculateSurface();
}


using System;

class Display
{
    //Fields
    private int? size;
    private int? numberOfColors;


    //Constructor
    public Display(int? size = null, int? numberOfColors = null)
    {
        this.Size = size;
        this.NumberOfColors = numberOfColors;
    }
    
    //Properties
    public int? Size
    {
        get { return this.size; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The size can't be negative number or zero!");
            }
            if (value > 5000)
            {
                throw new ArgumentException("The size must be les than 5000!");
            }
            this.size = value;
        }
    }
    public int? NumberOfColors
    {
        get { return this.numberOfColors; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The number of colors can't be negative number or zero!");
            }
            if (value > 150000)
            {
                throw new ArgumentException("The size must be less than 150000!");
            }
            this.numberOfColors = value;
        }
    }

    //Metods
    public string GetDisplayInfo()
    {
        string displayInfo = "Display-size: " + size + "\n" + "Display-number of colors: " + numberOfColors;
        return displayInfo;
    }
}


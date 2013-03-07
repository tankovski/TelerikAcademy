using System;


public abstract class Customer
{
    //Fields
    private string name;

    //Properties
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    //Constructor
    public Customer(string name)
    {
        this.Name = name;
    }
}


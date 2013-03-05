using System;


public abstract class Animal
{
    //Fields
    private int age;
    private string name;
    private Sex sexx;


    //Properties
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The age must be a positive number!");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public Sex sex
    {
        get {return this.sexx; }
    }
    //Constructor
    public Animal(int age, string name,Sex sex)
    {
        this.Age = age;
        this.Name = name;
        this.sexx=sex;
    }

    
}


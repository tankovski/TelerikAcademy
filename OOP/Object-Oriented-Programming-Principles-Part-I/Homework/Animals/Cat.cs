using System;


public abstract class Cat:Animal,ISound
{

    //Constructor
    public Cat(int age, string name,Sex sex)
        : base(age, name,sex)
    { }

    //Interface method
    public void ProduceSound()
    {
        Console.WriteLine("Miauu");
    }


}


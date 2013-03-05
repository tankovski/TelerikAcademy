using System;

class Dog:Animal,ISound
{

    //Constructor
    public Dog(int age, string name, Sex sex)
        : base(age, name, sex)
    { }

    //Interface method
    public void ProduceSound()
    {
        Console.WriteLine("Baau");
    }
}


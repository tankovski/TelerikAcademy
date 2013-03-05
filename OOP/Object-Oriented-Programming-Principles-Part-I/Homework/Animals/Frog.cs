using System;

class Frog : Animal,ISound
{
    //Constructor
    public Frog(int age, string name, Sex sex)
        : base(age, name, sex)
    { }

    //Methods
    public void ProduceSound()
    {
        Console.WriteLine("Crrrr");
    }
}


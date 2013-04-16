using System;

class ProduceHumans
{
    static void Main()
    {
        Human Adam = MakeHuman(22);
        Console.WriteLine(Adam.Name);
        Console.WriteLine(Adam.Sex);
        Console.WriteLine(Adam.Age);
    }

    enum Sex
    {
        male,
        female
    }
    class Human
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static Human MakeHuman(int ssn) //SSN-Social Security Number
    {
        Human human = new Human();
        human.Age = ssn;
        if (ssn % 2 == 0)
        {
            human.Name = "MaleName";
            human.Sex = Sex.male;
        }
        else
        {
            human.Name = "FemaleName";
            human.Sex = Sex.female;
        }

        return human;
    }
}


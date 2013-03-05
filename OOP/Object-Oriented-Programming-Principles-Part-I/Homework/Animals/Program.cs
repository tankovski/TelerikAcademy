using System;

class Program
{
    static void Main(string[] args)
    {

        //Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful 
        //constructors and methods. Dogs, frogs and cats are Animals. All animals
        //can produce sound (specified by the ISound interface). Kittens and 
        //tomcats are cats. All animals are described by age, name and sex. Kittens
        //can be only female and tomcats can be only male. Each animal produces a specific
        //sound. Create arrays of different kinds of animals and calculate the average 
        //age of each kind of animal using a static method (you may use LINQ).


        //Make some animals and test their properties
        Kitten kitty = new Kitten(3, "Kitty");//the sex is aways female
        Console.WriteLine(kitty.Name + "-" + kitty.Age + "-" + kitty.sex);
        kitty.ProduceSound();
        Tomkat tom = new Tomkat(5, "Tom");//the sex is aways male
        Console.WriteLine(tom.Name + "-" + tom.Age + "-" + tom.sex);
        tom.ProduceSound();
        Dog doggy = new Dog(8, "Doggy", Sex.male);
        Console.WriteLine(doggy.Name + "-" + doggy.Age + "-" + doggy.sex);
        doggy.ProduceSound();
        Frog froggy = new Frog(1, "Froggy", Sex.female);
        Console.WriteLine(froggy.Name + "-" + froggy.Age + "-" + froggy.sex);
        froggy.ProduceSound();

        //Make array with diferent animals and calculate the average age for every animal type in the array
        Animal[] animals = {kitty,tom,froggy,doggy,
                                   new Kitten(4,"Keit"),
                                   new Tomkat(5,"Tomas"),
                                   new Dog(11,"Rex",Sex.male),
                                   new Frog(3,"Curmit",Sex.male)};
        CalculateEveryAnimalAverageAge(animals);

    }

    private static void CalculateEveryAnimalAverageAge(Animal[] animals)
    {
        int frogYears = 0, frogs = 0;
        int tomcatYears = 0, tomcats = 0;
        int kittenYears = 0, kittens = 0;
        int dogYears = 0, dogs = 0;

        foreach (Animal animal in animals)
        {
            switch (animal.GetType().ToString())
            {
                case "Kitten": kittenYears += animal.Age;
                    kittens++;
                    break;
                case "Frog": frogYears += animal.Age;
                    frogs++;
                    break;
                case "Tomkat": tomcatYears += animal.Age;
                    tomcats++;
                    break;
                case "Dog": dogYears += animal.Age;
                    dogs++;
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine("Dogs average age is {0}", (decimal)dogYears / dogs);
        Console.WriteLine("Kittens average age is {0}", (decimal)kittenYears / kittens);
        Console.WriteLine("Tomcats average age is {0}", (decimal)tomcatYears / tomcats);
        Console.WriteLine("Frogs average age is {0}", (decimal)frogYears / frogs);
    }
}


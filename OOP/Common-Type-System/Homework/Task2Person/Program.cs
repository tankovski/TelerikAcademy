using System;

class Program
{
    static void Main()
    {

        //Create a class Person with two fields – name and age. Age can be
        //left unspecified (may contain null value. Override ToString() to 
        //display the information of a person and if age is not specified – 
        //to say so. Write a program to test this functionality.

        //Create two persons and print their names and ages
        Person peter = new Person("Peter", 27);
        Person ivan = new Person("Ivan");
        Console.WriteLine(ivan);
        Console.WriteLine();
        Console.WriteLine(peter);
    }
}


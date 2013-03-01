using System;
using System.Linq;

class StudentWhossFirstNameIsAlphabeticallyBeforeLast
{

    //Write a method that from a given array of students 
    //finds all students whose first name is before its last
    //name alphabetically. Use LINQ query operators.
    static void Main(string[] args)
    {
        var students = new[]
            {
                new{firstName="Petur", lastName="Ivanov"},
                new{firstName = "Atanas", lastName="Petrow"},
                new{firstName="Zdravko", lastName="Georgiev"},
                new{firstName="Atanas", lastName="Georgiev"}
            };
        var ourStudents =
            from student in students
            where student.firstName.CompareTo(student.lastName) == -1
            select student;

        foreach (var student in ourStudents)
        {
            Console.WriteLine(student.firstName + " " + student.lastName);
        }
    }
}


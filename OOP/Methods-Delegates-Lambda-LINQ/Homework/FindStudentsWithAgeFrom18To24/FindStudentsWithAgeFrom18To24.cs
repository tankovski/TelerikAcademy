using System;
using System.Linq;

class FindStudentsWithAgeFrom18To24
{
    static void Main(string[] args)
    {

        //Write a LINQ query that finds the first name
        //and last name of all students with age between 18 and 24.

        var students = new[]
            {
                new{firstName="Petur", lastName="Ivanov", age=19},
                new{firstName = "Atanas", lastName="Petrow", age = 17},
                new{firstName="Zdravko", lastName="Georgiev", age = 24},
                new{firstName="Atanas", lastName="Georgiev", age = 32}
            };

        var ourStudents =
            from student in students
            where student.age >= 18 && student.age <= 24
            select student;

        foreach (var student in ourStudents)
        {
            Console.WriteLine(student.firstName + " " + student.lastName);
        }
    }
}


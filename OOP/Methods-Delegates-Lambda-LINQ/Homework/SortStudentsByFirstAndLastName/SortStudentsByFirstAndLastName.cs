using System;
using System.Linq;

class SortStudentsByFirstAndLastName
{
    static void Main(string[] args)
    {
        //Using the extension methods OrderBy() and 
        //ThenBy() with lambda expressions sort the 
        //students by first name and last name in descending
        //order. Rewrite the same with LINQ.



        //With lambda
        var students = new[]
            {
                new{firstName="Petur", lastName="Ivanov", age=19},
                new{firstName = "Atanas", lastName="Petrow", age = 17},
                new{firstName="Zdravko", lastName="Georgiev", age = 24},
                new{firstName="Atanas", lastName="Zdravkov", age = 32}
            };

        //var sortedStudents = students.OrderByDescending(student => student.firstName).ThenByDescending(student=>student.lastName);
        //foreach (var student in sortedStudentsByFirstName)
        //{
        //    Console.WriteLine(student.firstName + " "+ student.lastName);
        //}

        //With LINQ

        var sortedStudents =
            from student in students
            orderby student.firstName descending, student.lastName descending
            select student;
        foreach (var student in sortedStudents)
        {
            Console.WriteLine(student.firstName + " " + student.lastName);
        }


    }
}


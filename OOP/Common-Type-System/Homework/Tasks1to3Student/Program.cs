using System;

class Program
{
    static void Main(string[] args)
    {

        //Define a class Student, which contains data about a student – first, middle and last name,
        //SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use 
        //an enumeration for the specialties, universities and faculties. Override the standard methods,
        //inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
        //Add implementations of the ICloneable interface. The Clone() method should deeply copy all
        //object's fields into a new object of type Student.
        //Implement the  IComparable<Student> interface to compare students by names (as first criteria,
        //in lexicographic order) and by social security number (as second criteria, in increasing order).



        //Making student and test override ToString method
        Student peter = new Student("Peter", "Ivanov", "Petrov", 12764397, "Sofia,Mladost1,Al. Malinov str.", 0889888888,
            "email@abv.bg", 2, Universities.SofiaUniversity, Faculties.HistoryFaculty, Specialties.History);
        Console.WriteLine(peter);
        Console.WriteLine();

        //Make second student who is deep clone of the first one and test this
        Student ivo = peter.Clone();
        Console.WriteLine(ivo);
        ivo.FirstName = "Joro";
        Console.WriteLine(ivo.FirstName);
        Console.WriteLine(peter.FirstName);
        Console.WriteLine();

        //Testing override method CompareTo
        Console.WriteLine(peter.CompareTo(ivo));
        ivo.FirstName = "Peter";
        Console.WriteLine(peter.CompareTo(ivo));
    }
}


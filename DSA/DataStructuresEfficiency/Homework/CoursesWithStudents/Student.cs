using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Student : IComparable<Student>
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        private set { }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set { }
    }

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public int CompareTo(Student otherStudent)
    {
        int result = this.lastName.CompareTo(otherStudent.lastName);
        if (result == 0)
        {
            result = this.firstName.CompareTo(otherStudent.firstName);
        }

        return result;
    }
}


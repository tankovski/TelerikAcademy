using System;


public class Student : Human
{
    //Fields
    private int grade;

    //Properties
    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The grade nust be a number bigger than zero!");
            }
            this.grade = value;
        }
    }

    //Constructor
    public Student(string firstName, string lastName, int grade):base(firstName,lastName)
    {
        this.Grade = grade;
    }

    
}


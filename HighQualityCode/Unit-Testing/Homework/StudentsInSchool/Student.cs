using System;

public class Student
{
    private string name;
    private int uniqueNumber;

    public Student(string name, int uniqueNumber)
    {
        this.Name = name;
        this.UniqueNumber = uniqueNumber;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value==null || value==String.Empty)
            {
                throw new ArgumentNullException("Student name can't be null or empty");
            }
            this.name = value;
        }
    }

    public int UniqueNumber
    {
        get
        {
            return this.uniqueNumber;
        }
        set
        {
            if (value<10000 || value>99999)
            {
                throw new ArgumentOutOfRangeException("Unique number must be between 10000 and 99999!");
            }
            this.uniqueNumber = value;
        }
    }
}


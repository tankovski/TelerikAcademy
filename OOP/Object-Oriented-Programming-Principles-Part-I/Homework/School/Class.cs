using System;
using System.Collections.Generic;
using System.Text;



public class Class:IOptionalComment
{
    //Fields
    private List<Teacher> setOfTeachers = new List<Teacher>();
    private List<Student> setOfStudents = new List<Student>();
    private string uniqueTextIdentifier;
    private string optionalComment;

    //Prperties
    public string UniqueTextIdentifier
    {
        get { return this.uniqueTextIdentifier; }
        set { this.uniqueTextIdentifier = value; }
    }

    public List<Teacher> SetOfTeachers
    {
        get { return this.setOfTeachers; }
    }

    public List<Student> SetOfStudents
    {
        get { return this.setOfStudents; }
    }


    //Constructor
    public Class(string uniqueTextIdentifier)
    {
        this.UniqueTextIdentifier = uniqueTextIdentifier;
    }

    //Method

    public string Teachers()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Teacher teacher in setOfTeachers)
        {
            sb.Append("Mr. " + teacher.Name + " teaches: " + teacher.Disciplines());
        }
        return sb.ToString();
    }

    public string Students()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Student student in setOfStudents)
        {
            sb.Append(student.Name + " " + student.UniqueNumber + Environment.NewLine);
        }
        return sb.ToString();
    }

    public void AddComment(string comment)
    {
        this.optionalComment = comment;
    }
    public string ShowComment()
    {
        return this.optionalComment;
    }
}


using System;
using System.Collections.Generic;
using System.Text;


public class Teacher:Human,IOptionalComment
{
    //Fields
    private List<Discipline> setOfDisciplines = new List<Discipline>();
    private string optionalComment;

    //Properties
    public List<Discipline> SetOfDisciplines
    {
        get { return this.setOfDisciplines; }
    }

    //Constructor
    public Teacher(string name)
        : base(name)
    {
    }



    //Methods

    public string Disciplines()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Discipline discipline in setOfDisciplines)
        {
            sb.Append("Discipline-"+discipline.Name+", Number of lectures-"+discipline.NumberOfLectures
                + ", Number of exercises-" + discipline.NumberOfExercises+Environment.NewLine);
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


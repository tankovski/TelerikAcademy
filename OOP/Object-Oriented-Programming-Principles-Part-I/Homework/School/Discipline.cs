using System;


public class Discipline:IOptionalComment
{
    //Fields
    private string name;
    private int numberOfLectures;
    private int numberOfExercises;
    private string optionalComment;



    //Prperties
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int NumberOfLectures
    {
        get { return this.numberOfLectures; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("The number of lectures must be a positive number!");
            }
            this.numberOfLectures = value;
        }
    }

    public int NumberOfExercises
    {
        get { return this.numberOfExercises; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The number of exercises must be a positive number!");
            }
            this.numberOfExercises = value;
        }
    }



    //Construcotr
    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.NumberOfExercises = numberOfExercises;
    }

    //Methods
    public void AddComment(string comment)
    {
        this.optionalComment = comment;
    }
    public string ShowComment()
    {
        return this.optionalComment;
    }
}


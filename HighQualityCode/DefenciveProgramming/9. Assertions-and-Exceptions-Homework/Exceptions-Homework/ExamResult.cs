using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade must be a positive number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Min grade must be a positive number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Min grade must be smaller than max grade");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("The coment can't be empty or null!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}

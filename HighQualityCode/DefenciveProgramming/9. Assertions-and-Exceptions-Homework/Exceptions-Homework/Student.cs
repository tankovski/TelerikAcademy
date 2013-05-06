using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName 
    {
        get
        {
            return this.FirstName;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new ArgumentNullException("First name can not be null or empty");
            }
        }
    }
    public string LastName { 
        get
        {
            return this.LastName;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new ArgumentNullException("Last name can not be null or empty");
            }
        }
    }
    public IList<Exam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException("The exam list is not define or empty!");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException("The exam list is not define or empty!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}

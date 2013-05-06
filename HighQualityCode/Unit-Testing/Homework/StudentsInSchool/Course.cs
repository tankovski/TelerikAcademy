using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Course
{
    private string name;
    private List<Student> setOfStudents = new List<Student>();

    public Course(string name)
    {
        this.Name = name;
    }

    public List<Student> SetOfStudents
    {
        get
        {
            return this.setOfStudents;
        }
        private set { }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value==null || value==string.Empty)
            {
                throw new ArgumentNullException("Course name can't be null or empty");
            }
            this.name = value;
        }
    }

    public void AddStudent(Student student)
    {
        if (this.setOfStudents.Count<30)
        {
            setOfStudents.Add(student);
        }
        else
        {
            throw new ArgumentException("The students in this course can be maximum 30!");
        }
    }

    public void RemoveStudent(int studentUniqueNumber)
    {
        bool studentFinded=false;

        for (int i = 0; i < this.setOfStudents.Count; i++)
        {
            if (studentUniqueNumber == this.setOfStudents[i].UniqueNumber)
            {
                this.setOfStudents.RemoveAt(i);
                studentFinded = true;
                break;
            }
        }
        if (studentFinded==false)
        {
            throw new ArgumentException("There is no student with this number in the course");
        }


    }
}


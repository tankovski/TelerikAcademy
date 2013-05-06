using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class School
{
    private string name;
    private List<Course> setOfCourses = new List<Course>();

    public School(string name)
    {
        this.Name = name;
    }

    public List<Course> SetOfCourses
    {
        get { return this.setOfCourses; }
        private set{}
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == null || value == String.Empty)
            {
                throw new ArgumentNullException("Student name can't be null or empty");
            }
            this.name = value;
        }
    }
}


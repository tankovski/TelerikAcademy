using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        //Properties
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        //Constructor
         public Course(string courseName, string teacherName=null, IList<string> students=null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        //Methods
         internal string GetStudentsAsString()
         {
             if (this.Students == null || this.Students.Count == 0)
             {
                 return "{ }";
             }
             else
             {
                 return "{ " + string.Join(", ", this.Students) + " }";
             }
         }
    }
}

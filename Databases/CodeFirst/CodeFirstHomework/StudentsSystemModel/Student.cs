using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("Students")]
public class Student
{
    private ICollection<Homework> homeworks;
    private ICollection<Course> courses;


    public Student()
    {
        this.homeworks = new HashSet<Homework>();
        this.courses = new HashSet<Course>();

    }
    [Key]
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string StudentLastName { get; set; }
    public int StudentNumber { get; set; }


    public virtual ICollection<Homework> Homeworks
    {
        get { return this.homeworks; }
        set { this.homeworks = value; }
    }

    public virtual ICollection<Course> Courses
    {
        get { return this.courses; }
        set { this.courses = value; }
    }
}


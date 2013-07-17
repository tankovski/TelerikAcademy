using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
        : base("StudentSystem")
    { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
}


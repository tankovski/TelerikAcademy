using StudentsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataLayer
{
    public class StudentsContext:DbContext
    {
        public StudentsContext()
            : base("StudentsDb")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}

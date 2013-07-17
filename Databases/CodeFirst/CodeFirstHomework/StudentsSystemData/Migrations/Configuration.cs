namespace StudentsSystemData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    using StudentsSystemModel;
 
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            HashSet<Homework> homeworks = new HashSet<Homework>();
            Homework firstHomework = new Homework
            {
                HomeworkID = 1,
                CourseId =1,
                HomeworkContent = "RandomContent",
                StudentId = 1,
                TimeSent = new DateTime(1997,01,01)
            };
             Homework SecondHomework = new Homework
            {
                HomeworkID = 2,
                CourseId =1,
                HomeworkContent = "RandomContent",
                StudentId = 1,
                TimeSent = new DateTime(1997,01,01)
            };
             homeworks.Add(firstHomework);
            homeworks.Add(SecondHomework);
            Course css = new Course
            {
                CourseId = 1,
                CourseName ="CSS",
                Description = "Unknown",
                Materials = "Unknown",
                Homeworks = homeworks
            };
           
            Student pesho = new Student { StudentId = 1,StudentName="Pesho", StudentNumber=1234, Homeworks = homeworks ,
                Courses = new HashSet<Course>{css},StudentLastName = "Peshev"};
            css.Students = new HashSet<Student>{pesho};

            context.Students.AddOrUpdate(pesho);
            context.Courses.AddOrUpdate(css);
            context.Homeworks.AddOrUpdate(firstHomework,SecondHomework);


            
        }
    }
}

using StudentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsServices.Models
{
    public class SchoolFullModel : SchoolModel
    {
        public ICollection<StudentModel> Students { get; set; }

        public SchoolFullModel()
        {
            this.Students = new HashSet<StudentModel>();
        }

        public void TransformSchoolFromEntity(School schoolEntity)
        {

            Name = schoolEntity.Name;
            SchoolId = schoolEntity.SchoolId;
            Location = schoolEntity.Location;


            if (schoolEntity.Students != null)
            {
                Students =
                   (from student in schoolEntity.Students
                    select new StudentModel()
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Age = student.Age,
                        Grade = student.Grade,
                        StudentId = student.StudentId
                    }).ToList();
            }
        }
    }
}
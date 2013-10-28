using StudentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsServices.Models
{
    public class StudentFullModel : StudentModel
    {

        public SchoolModel School { get; set; }
        public IEnumerable<MarksModel> Marks { get; set; }

        public StudentFullModel()
        {
            this.Marks = new HashSet<MarksModel>();
        }

        public void TransformFromEntity(Student student)
        {

            StudentId = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Age = student.Age;
            Grade = student.Grade;


            if (student.School != null)
            {
                School = new SchoolModel()
                 {
                     SchoolId = student.School.SchoolId,
                     Name = student.School.Name,
                     Location = student.School.Location
                 };
            }
            if (student.Marks != null)
            {
                Marks =
                from mark in student.Marks
                select new MarksModel()
                {
                    MarkId = mark.MarkId,
                    Subjeckt = mark.Subjeckt,
                    Value = mark.Value
                };
            }
        }
    }
}
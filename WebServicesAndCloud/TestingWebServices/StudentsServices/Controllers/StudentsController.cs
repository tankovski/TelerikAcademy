using StudentsModels;
using StudentsRepositories;
using StudentsServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsServices.Controllers
{
    public class StudentsController : ApiController
    {
         private IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/students
        public IEnumerable<string> Get()
        {
            //var students = this.studentsRepository.All();
            //var studentModels =
            //    from student in students
            //    select new StudentFullModel()
            //    {
            //        StudentId = student.StudentId,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        Age = student.Age,
            //        Grade = student.Grade,
            //        School = new SchoolModel()
            //        {
            //            SchoolId = student.School.SchoolId,
            //            Name = student.School.Name,
            //            Location = student.School.Location
            //        },
            //        Marks =
            //        from mark in student.Marks
            //        select new MarksModel()
            //        {
            //            MarkId = mark.MarkId,
            //            Subjeckt = mark.Subjeckt,
            //            Value = mark.Value
            //        }
            //    };

            //return studentModels;

            return new string[] {"sss","dddd"};
        }

        // GET api/students/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/students
        public void Post([FromBody]string value)
        {
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        public void Delete(int id)
        {
        }
    }
}

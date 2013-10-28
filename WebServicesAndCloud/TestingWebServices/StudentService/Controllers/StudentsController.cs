using StudentsDataLayer;
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
        public IEnumerable<StudentFullModel> Get()
        {
            var students = this.studentsRepository.All().ToList();
            var studentModels =
                from student in students
                select new StudentFullModel()
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade,
                    School = student.School != null ? new SchoolModel()
                    {
                        SchoolId = student.School.SchoolId,
                        Name = student.School.Name,
                        Location = student.School.Location
                    } : null,
                    Marks = student.Marks != null ?
                    from mark in student.Marks
                    select new MarksModel()
                    {
                        MarkId = mark.MarkId,
                        Subjeckt = mark.Subjeckt,
                        Value = mark.Value
                    } : null
                };

            return studentModels;

        }

        // GET api/students/5
        public StudentFullModel Get(int id)
        {
            var student = this.studentsRepository.Get(id);

            StudentFullModel studentModel = new StudentFullModel();
            if (student!=null)
            {
                studentModel.TransformFromEntity(student);
            }
            
            return studentModel;
        }

        // api/students?subject=S&value=V
        public ICollection<StudentFullModel> Get(string subject, int value)
        {
            var students = this.studentsRepository.All().Where(s => s.Marks.Any(
                m => m.Subjeckt == subject && m.Value > value)).ToList();
            ICollection<StudentFullModel> studentModels = new List<StudentFullModel>();
            foreach (var entity in students)
            {
                StudentFullModel stud = new StudentFullModel();
                stud.TransformFromEntity(entity);
                studentModels.Add(stud);
            }

            return studentModels;
        }

        // POST api/students
        public HttpResponseMessage Post(StudentFullModel student)
        {
            var entityToAdd = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade
            };

            if (student.School != null)
            {
                entityToAdd.School = new School()
                {
                    SchoolId = student.School.SchoolId,
                    Name = student.School.Name,
                    Location = student.School.Location
                };
            }
            if (entityToAdd.Marks != null)
            {
                entityToAdd.Marks = (
                from mark in student.Marks
                select new Mark()
                {
                    MarkId = mark.MarkId,
                    Subjeckt = mark.Subjeckt,
                    Value = mark.Value
                }).ToList();
            }

            var createdEntity = this.studentsRepository.Add(entityToAdd);


            StudentFullModel studentModel = new StudentFullModel();
            studentModel.TransformFromEntity(createdEntity);
            

            var response = Request.CreateResponse<StudentFullModel>(HttpStatusCode.Created, studentModel);
            var resourceLink = Url.Link("DefaultApi", new { id = studentModel.StudentId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        public void Delete(int id)
        {
            this.studentsRepository.Delete(id);
        }
    }
}

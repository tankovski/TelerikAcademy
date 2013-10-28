using StudentsModels;
using StudentsRepositories;
using StudentsServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentService.Controllers
{
    public class SchoolsController : ApiController
    {
        private IRepository<School> schoolsRepository;

        public SchoolsController(IRepository<School> schoolsRepository)
        {
            this.schoolsRepository = schoolsRepository;
        }

        // GET api/schools
        public IEnumerable<SchoolModel> Get()
        {
            
            var schools = this.schoolsRepository.All();

            var schoolModels =
                from school in schools
                select new SchoolModel()
                {
                    Name = school.Name,
                    Location = school.Location,
                    SchoolId = school.SchoolId
                };

            return schoolModels;
        }

        // GET api/schools/5
        public SchoolFullModel Get(int id)
        {
            var schoolEntity = this.schoolsRepository.Get(id);

            SchoolFullModel school = new SchoolFullModel();
           school.TransformSchoolFromEntity(schoolEntity);

            return school;
        }

        public HttpResponseMessage Post(SchoolFullModel school)
        {
            var entityToAdd = new School()
            {
                Name = school.Name,
                Location = school.Location
            };

            if (school.Students != null)
            {
                entityToAdd.Students =
                    (from student in school.Students
                     select new Student()
                     {

                         FirstName = student.FirstName,
                         LastName = student.LastName,
                         Age = student.Age,
                         Grade = student.Grade,
                     }).ToList();
            }
            

            var createdEntity = this.schoolsRepository.Add(entityToAdd);


            SchoolFullModel schoolModel = new SchoolFullModel();
            schoolModel.TransformSchoolFromEntity(createdEntity);
            

            var response = Request.CreateResponse<SchoolFullModel>(HttpStatusCode.Created, schoolModel);
            var resourceLink = Url.Link("DefaultApi", new { id = schoolModel.SchoolId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }

        // PUT api/schools/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/schools/5
        public void Delete(int id)
        {
            this.schoolsRepository.Delete(id);
        }
    }
}

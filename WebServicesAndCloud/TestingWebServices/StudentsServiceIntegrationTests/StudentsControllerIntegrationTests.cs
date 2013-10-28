using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using StudentsRepositories;
using StudentsModels;
using System.Linq;
using Places.Services.IntergrationTests;
using System.Net;
using Newtonsoft.Json;

namespace StudentsServiceIntegrationTests
{

    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        //GetAll method tests
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotListWithOneStudent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add( new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
               
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");
            var content = JsonConvert.DeserializeObject<ICollection<Student>>((response.Content.ReadAsStringAsync().Result));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(content.Count==1);
        }

        //Get By Id method tests
        [TestMethod]
        public void GetById_WhenOneStudentMatchTheId_ShouldReturnStatusCode200AndOneStudent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,

            });

            Mock.Arrange(() => mockRepository.Get(1))
                .Returns(() => models.AsQueryable().Where(s=>s.StudentId ==1).FirstOrDefault());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);
           
            var response = server.CreateGetRequest("api/students/1");
             var content = JsonConvert.DeserializeObject<Student>((response.Content.ReadAsStringAsync().Result));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(content.StudentId == 1);
           
        }

        [TestMethod]
        public void GetById_WhenNoStudentMatchTheId_ShouldReturnStatusCode200AndNoStudents()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                StudentId = 2,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,

            });

            Mock.Arrange(() => mockRepository.Get(1))
                .Returns(() => models.AsQueryable().Where(s => s.StudentId == 1).FirstOrDefault());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/1");
            var content = JsonConvert.DeserializeObject<Student>((response.Content.ReadAsStringAsync().Result));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsFalse(content.StudentId > 0);
        }

        //Get by marks subjeckt and value tests
        [TestMethod]
        public void GetByMarksSubjectAndValue_WhenStudentMatchTheSubjectAndValue_ShouldReturnStatusCode200AndTheStudent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                StudentId =1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subjeckt="math",
                        Value = 6
                    },
                    new Mark()
                    {
                        Subjeckt="biology",
                        Value = 4
                    },
                }
            });
            string subject = "math";
            int value = 5;

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable().Where(s => s.Marks.Any(m=>m.Subjeckt==subject&&m.Value>value)));

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students?subject=math&value=5");
            var content = JsonConvert.DeserializeObject<ICollection<Student>>((response.Content.ReadAsStringAsync().Result));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(content.First().StudentId == 1);
            Assert.IsTrue(content.First().Marks.First().Subjeckt == subject);
            Assert.IsTrue(content.First().Marks.First().Value >value);
        }

        public void GetByMarksSubjectAndValue_WhenNoStudentMatchTheSubjectAndValue_ShouldReturnStatusCode200AndNoStudents()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subjeckt="math",
                        Value = 5
                    },
                    new Mark()
                    {
                        Subjeckt="biology",
                        Value = 4
                    },
                }
            });
            string subject = "math";
            int value = 5;

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable().Where(s => s.Marks.Any(m => m.Subjeckt == subject && m.Value > value)));

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students?subject=math&value=5");
            var content = JsonConvert.DeserializeObject<ICollection<Student>>((response.Content.ReadAsStringAsync().Result));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(content.First().StudentId == 0);
            
        }

        //Post method tests
        [TestMethod]
        public void Post_StudentWithValidContent_ShouldReturnStatusCode200AndStudentWithId()
        {
            
            var mockRepository = Mock.Create<DbStudentsRepository>();
            bool added = false;

            var student = new Student()
                {
                    FirstName = "Peter",
                    LastName = "Petrov",
                    Grade = 5,
                    Age = 18,
                };
            var studentEntity = new Student()
            {
                StudentId =1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
            };

            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => added = true)
                .Returns(studentEntity);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/students", student);
           
            var content = JsonConvert.DeserializeObject<Student>((response.Content.ReadAsStringAsync().Result));
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.IsTrue(added);
            Assert.IsTrue(content.StudentId == 1);
        }

        [TestMethod]
        public void Post_StudentWithouthName_ShouldReturnInternalErrorMsg()
        {
           
            var mockRepository = Mock.Create<DbStudentsRepository>();

            var student = new Student()
                {
                    Grade = 5,
                    Age = 18
                };

            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .Throws<ArgumentNullException>();

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreatePostRequest("api/students", JsonConvert.SerializeObject(student));

            Assert.AreEqual(responce.StatusCode, HttpStatusCode.InternalServerError);
        }

        //Delete method tests
        [TestMethod]
        public void Delete_StudentWithValidId_ShouldReturnDeletedResponseMsg()
        {
           
            var mockRepository = Mock.Create<DbStudentsRepository>();

            var models = new List<Student>();
            models.Add( new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
               
            });
            int idForRemoving = 1;
            Mock.Arrange(() => mockRepository.Delete(Arg.IsAny<int>()))
                .DoInstead(() => models.RemoveAt(models.FindIndex(s=>s.StudentId== idForRemoving)));

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreateDeleteRequest("api/students/1");

            Assert.AreEqual(responce.StatusCode, HttpStatusCode.NoContent);
            Assert.IsTrue(models.Count == 0);
        }

        [TestMethod]
        public void Delete_NoStudentWithSuchId_ShouldReturnInternalErrorMsg()
        {
       
            var mockRepository = Mock.Create<DbStudentsRepository>();

            var models = new List<Student>();
            models.Add( new Student()
            {
                StudentId = 2,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
               
            });
           
            Mock.Arrange(() => mockRepository.Delete(Arg.IsAny<int>()))
                .Throws<ArgumentException>();

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreateDeleteRequest("api/students/1");

            Assert.AreEqual(responce.StatusCode, HttpStatusCode.InternalServerError);
        }
    }
}

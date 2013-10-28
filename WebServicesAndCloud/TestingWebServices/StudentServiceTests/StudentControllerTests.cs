using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Telerik.JustMock;
using StudentsRepositories;
using StudentsModels;
using StudentsServices.Models;
using StudentsServices.Controllers;
using System.Linq;

namespace StudentServiceTests
{
    [TestClass]
    public class StudentControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        //Add method tests
        [TestMethod]
        public void Add_StudentHaveValidProperties_ShouldAddTheStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            StudentFullModel student = new StudentFullModel()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };
            Student studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                Age = student.Age
            };

            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.Post(student);

            Assert.IsTrue(isItemAdded);
        }

        //GetAll method tests
        [TestMethod]
        public void GetAll_WhenASingleStudentInRepository_ShouldReturnSingleStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };
            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);
            Mock.Arrange(() => repository.All()).Returns(() => studentsEnteties.AsQueryable());

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get();
            Assert.IsTrue(studentsModels.Count() == 1);
            Assert.AreEqual(student.LastName, studentsModels.First().LastName);
        }

        [TestMethod]
        public void GetAll_WhenASeveralStudenstInRepository_ShouldReturnAll()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };
            Student student2 = new Student()
            {
                FirstName = "Peter2",
                LastName = "Petrov2",
                Grade = 6,
                Age = 19
            };
            Student student3 = new Student()
            {
                FirstName = "Peter3",
                LastName = "Petrov3",
                Grade = 7,
                Age = 20
            };
            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);
            studentsEnteties.Add(student2);
            studentsEnteties.Add(student3);

            Mock.Arrange(() => repository.All()).Returns(() => studentsEnteties.AsQueryable());

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get();
            Assert.IsTrue(studentsModels.Count() == 3);
            Assert.IsNotNull(studentsModels.Where(s => s.LastName == student.LastName));
            Assert.IsNotNull(studentsModels.Where(s => s.LastName == student2.LastName));
            Assert.IsNotNull(studentsModels.Where(s => s.LastName == student3.LastName));

        }

        [TestMethod]
        public void GetAll_WhenAZeroStudenstInRepository_ShouldReturnZeroStudents()
        {
            var repository = Mock.Create<IRepository<Student>>();

            IList<Student> studentsEnteties = new List<Student>();


            Mock.Arrange(() => repository.All()).Returns(() => studentsEnteties.AsQueryable());

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get();
            Assert.AreEqual(studentsModels.Count(), 0);

        }

        //Get by id tests
        [TestMethod]
        public void GetById_WhenThereIsSuchStudentInDb_ShouldReturnTheStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();

            IList<Student> studentsEnteties = new List<Student>();

            Student studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };
            studentsEnteties.Add(studentEntity);
            Mock.Arrange(() => repository.Get(studentEntity.StudentId)).Returns(() => studentsEnteties.AsQueryable().Where(s => s.StudentId == studentEntity.StudentId).FirstOrDefault());

            var controller = new StudentsController(repository);

            var studentModel = controller.Get(studentEntity.StudentId);
            Assert.AreEqual(studentEntity.StudentId, studentModel.StudentId);

        }

        [TestMethod]
        public void GetById_WhenThereIsNoSuchStudentInDb_ShouldReturnNull()
        {
            var repository = Mock.Create<IRepository<Student>>();

            IList<Student> studentsEnteties = new List<Student>();

            Student studentEntity = new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };

            int unexistingStudentId = 2;
            studentsEnteties.Add(studentEntity);
            Mock.Arrange(() => repository.Get(unexistingStudentId)).Returns(() => studentsEnteties.AsQueryable().Where(s => s.StudentId == unexistingStudentId).FirstOrDefault());

            var controller = new StudentsController(repository);

            var studentModel = controller.Get(unexistingStudentId);
            Assert.IsFalse(studentModel.StudentId > 0);

        }

        //Get by marks and subjeckt methot

        [TestMethod]
        public void GetByMarksAndSubject_WhenOneStudentMatch_ShouldReturnTheStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subjeckt="Math",
                        Value = 6
                    },
                    new Mark()
                    {
                        Subjeckt="Biology",
                        Value = 4
                    },
                }
            };
            Student student2 = new Student()
            {
                FirstName = "Peter2",
                LastName = "Petrov2",
                Grade = 6,
                Age = 19,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subjeckt="Math",
                        Value = 4
                    },
                    new Mark()
                    {
                        Subjeckt="Biology",
                        Value = 4
                    },
                }
            };
            Student student3 = new Student()
            {
                FirstName = "Peter3",
                LastName = "Petrov3",
                Grade = 7,
                Age = 20
            };
            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);
            studentsEnteties.Add(student2);
            studentsEnteties.Add(student3);

            string subject = "Math";
            int value = 5;
            Mock.Arrange(() => repository.All()).Returns(() => studentsEnteties.AsQueryable().Where(s=>s.Marks.Any(
                m=> m.Subjeckt==subject && m.Value > value)));

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get(subject,value);
            Assert.IsTrue(studentsModels.Count() == 1);
            Assert.IsTrue(studentsModels.First().Marks.Count() == 2);
            Assert.IsTrue(studentsModels.First().Marks.First().Subjeckt == subject);
        }

        [TestMethod]
        public void GetByMarksAndSubject_WhenNoStudentsMatch_ShouldNotReturnStudents()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subjeckt="Math",
                        Value = 5
                    },
                    new Mark()
                    {
                        Subjeckt="Biology",
                        Value = 4
                    },
                }
            };
           
            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);
          

            string subject = "Math";
            int value = 6;
            Mock.Arrange(() => repository.All()).Returns(() => studentsEnteties.AsQueryable().Where(s => s.Marks.Any(
                m => m.Subjeckt == subject && m.Value > value)));

            var controller = new StudentsController(repository);

            var studentsModels = controller.Get(subject, value);
            Assert.IsTrue(studentsModels.Count() == 0);
            
        }

        //Delete

        [TestMethod]
        public void Delete_WhenStudentWithSameIdExistInDb_ShouldRemoveTheStudent()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,
               
            };

            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);


            Mock.Arrange(() => repository.Delete(student.StudentId)).DoInstead(() => studentsEnteties.RemoveAt(0));

            var controller = new StudentsController(repository);
            controller.Delete(student.StudentId);

            Assert.IsTrue(studentsEnteties.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_WhenNoStudentWithSameIdExistInDb_ShouldThrowException()
        {
            var repository = Mock.Create<IRepository<Student>>();
            Student student = new Student()
            {
                StudentId = 1,
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18,

            };

            IList<Student> studentsEnteties = new List<Student>();
            studentsEnteties.Add(student);

            var invalidStudentId = 2;
            Mock.Arrange(() => repository.Delete(invalidStudentId)).Throws(new ArgumentException("Error"));

            var controller = new StudentsController(repository);
            controller.Delete(invalidStudentId);

        }
    }
}

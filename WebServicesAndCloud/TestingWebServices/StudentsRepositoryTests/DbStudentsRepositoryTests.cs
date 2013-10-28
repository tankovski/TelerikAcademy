using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using StudentsRepositories;
using StudentsModels;
using StudentsDataLayer;
using System.Collections.Generic;
using System.Linq;

namespace StudentsRepositoryTests
{
    [TestClass]
    public class DbStudentsRepositoryTests
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope;

        public DbStudentsRepositoryTests()
        {
            this.dbContext = new StudentsContext();
            this.studentsRepository = new DbStudentsRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        //Test Add method
        [TestMethod]
        public void Add_WhenStudentPropertiesAreValid_ShouldAddStudentToDatabase()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };

            var createdStudent = this.studentsRepository.Add(student);
            var foundStudent = this.dbContext.Set<Student>().Find(createdStudent.StudentId);
            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(student.FirstName, foundStudent.FirstName);
        }

        [TestMethod]
        public void Add_WhenStudentPropertiesAreValid_ShouldReturnNotZeroId()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };

            var createdStudent = this.studentsRepository.Add(student);
            Assert.IsTrue(createdStudent.StudentId != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_WhenStudenDontHaveName_ShouldThrowException()
        {
            Student student = new Student()
            {
                Grade = 6,
                Age = 18
            };

            var createdStudent = this.studentsRepository.Add(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WhenStudenDontHaveGrade_ShouldThrowException()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Age = 18
            };

            var createdStudent = this.studentsRepository.Add(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WhenStudenDontHaveAge_ShouldThrowException()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 4
            };

            var createdStudent = this.studentsRepository.Add(student);
        }


        //Test All met method

        [TestMethod]
        public void All_WhenDbNotEmpty_ShouldReturnAllStudents()
        {
            Student student1 = new Student()
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

            dbContext.Set<Student>().Add(student1);
            dbContext.Set<Student>().Add(student2);
            dbContext.SaveChanges();

            var students = this.studentsRepository.All().ToList();
            Assert.AreEqual(students.Count, 2);
            Assert.IsNotNull(students.Where(s => s.FirstName == student1.FirstName));
            Assert.IsNotNull(students.Where(s => s.FirstName == student2.FirstName));


        }

        [TestMethod]
        public void All_WhenDbIsEmpty_ShouldReturnZeroStudents()
        {
            
            var students = this.studentsRepository.All().ToList();
            Assert.AreEqual(students.Count,0);
        }

        //Test Get method

        [TestMethod]
        public void Get_WhenIdIsValid_ShouldReturnStudent()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };

            var actualStudent = dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();

            var expectedStudent = studentsRepository.Get(actualStudent.StudentId);

            Assert.IsNotNull(expectedStudent);
            Assert.AreEqual(student.LastName, expectedStudent.LastName);
        }

        [TestMethod]
        public void Get_WhenIdIsNotValid_ShouldReturnNull()
        {
            var expectedStudent = studentsRepository.Get(14);
            Assert.IsNull(expectedStudent);
        }


        //Test Delete method

        [TestMethod]
        public void Delete_WhenIdIsValid_ShouldRemoveStudentFromDb()
        {
            Student student = new Student()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Grade = 5,
                Age = 18
            };

            var actualStudent = dbContext.Set<Student>().Add(student);
            dbContext.SaveChanges();

            studentsRepository.Delete(actualStudent.StudentId);
            var expectedStudent = studentsRepository.Get(actualStudent.StudentId);

            Assert.IsNull(expectedStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Delete_WhenIdIsNotValid_ShouldThrowException()
        {
            studentsRepository.Delete(14);            
        }

    }
}

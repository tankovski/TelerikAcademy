using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsInSchool.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestCreateAStdent()
        {
            Student peter = new Student("Peter", 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentWithNullName()
        {
            Student peter = new Student(null, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestChangeStudentNameWithEmptyString()
        {
            Student peter = new Student("Peter", 10001);
            peter.Name = "";
        }

        public void TestStudentName()
        {
            Student peter = new Student("Peter", 10001);
            string expected = "Peter";

            Assert.AreEqual(expected, peter.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChangeStudentUniqueNumberWithWrongOne()
        {
            Student peter = new Student("Peter", 10001);
            peter.UniqueNumber = 100;
        }

        public void TestStudentUniqueNumber()
        {
            Student peter = new Student("Peter", 10001);
            int expected = 10001 ;

            Assert.AreEqual(expected, peter.UniqueNumber);
        }
    }
}

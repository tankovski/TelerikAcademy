using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsInSchool.Tests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCreateCourse()
        {
            Course html = new Course("HTML");
        }

        [TestMethod]
        public void TestCourseName()
        {
            Course html = new Course("HTML");

            string expected = "HTML";

            Assert.AreEqual(expected, html.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestToChangeCourseNameWithEmptyOne()
        {
            Course html = new Course("HTML");
            html.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestToGiveNullName()
        {
            Course html = new Course(null);

        }

        [TestMethod]
        public void TestToAddStudent()
        {
            Course html = new Course("HTML");
            html.AddStudent(new Student("Peter", 10001));

            Assert.AreEqual(1, html.SetOfStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddMoreThan30StudentsInOnCourse()
        {
            Course html = new Course("HTML");

            for (int i = 0; i < 32; i++)
            {
                html.AddStudent(new Student("Peter", 10002));
            }
        }

        [TestMethod]
        public void TestRemoveStudent()
        {
            Course html = new Course("HTML");
            html.SetOfStudents.Add(new Student("Peter", 10002));
            int notExpected = html.SetOfStudents.Count;

            html.RemoveStudent(10002);

            Assert.AreNotEqual(notExpected, html.SetOfStudents.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToGiveWrongStudentNumberInRemoveStudentMethod()
        {
            Course html = new Course("HTML");
            int notExpected = html.SetOfStudents.Count;

            html.RemoveStudent(10003);
        }
    }
}

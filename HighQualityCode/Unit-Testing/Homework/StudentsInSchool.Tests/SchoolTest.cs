using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsInSchool.Tests
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestToCreateSchool()
        {
            School telerik = new School("TelerikAcademy");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestToCreateSchoolWithNullName()
        {
            School telerik = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestToChangeSchoolNameWithEmptyString()
        {
            School telerik = new School("TelerikAcademy");
            telerik.Name = "";
        }

        [TestMethod]
        public void TestToAddCourse()
        {
            School telerik = new School("TelerikAcademy");
            telerik.SetOfCourses.Add(new Course("C#"));

            Assert.AreEqual(1, telerik.SetOfCourses.Count);
        }

        [TestMethod]
        public void TestSchoolName()
        {
            School telerik = new School("TelerikAcademy");
            string expected = "TelerikAcademy";

            Assert.AreEqual(expected, telerik.Name);
        }

        [TestMethod]
        public void TestSchoolSetOfCourses()
        {
            School telerik = new School("TelerikAcademy");

            Assert.AreEqual(0, telerik.SetOfCourses.Count);
        }
    }
}

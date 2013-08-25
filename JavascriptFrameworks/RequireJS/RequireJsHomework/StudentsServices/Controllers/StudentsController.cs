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

        private IList<Student> students;

        public StudentsController()
        {
            PopulateStudents();
        }

        public IList<Student> GetAll()
        {
            return this.students;
        }

        [ActionName("marks")]
        public ICollection<Mark> GetStudentMarks(int studentId)
        {
            return this.students[studentId].Marks;
        }

        private void PopulateStudents()
        {
            Student[] students = {
                            new Student()
                            {
                                Id=0,
                                FirstName = "Peter",
                                LastName="Petrov",
                                Marks = new Mark[]
                                {
                                    new Mark()
                                    {
                                        Subject="C#",
                                        Score=5
                                    },
                                    new Mark()
                                    {
                                        Subject="HTML",
                                        Score=6
                                    },new Mark()
                                    {
                                        Subject="CSS",
                                        Score=6
                                    }
                                }
                            },
                            new Student()
                            {
                                Id=1,
                                FirstName = "Ivan",
                                LastName="Ivanov",
                                Marks = new Mark[]
                                {
                                    new Mark()
                                    {
                                        Subject="DSA",
                                        Score=3
                                    },
                                    new Mark()
                                    {
                                        Subject="HTML",
                                        Score=6
                                    },new Mark()
                                    {
                                        Subject="JS",
                                        Score=4
                                    }
                                }
                            },
                            new Student()
                            {
                                Id=2,
                                FirstName = "Dimitar",
                                LastName="Dimitrov",
                                Marks = new Mark[]
                                {
                                    new Mark()
                                    {
                                        Subject="C#",
                                        Score=5
                                    },
                                    new Mark()
                                    {
                                        Subject="DSA",
                                        Score=5
                                    },new Mark()
                                    {
                                        Subject="Slice&Dice",
                                        Score=3
                                    }
                                }
                            },new Student()
                            {
                                Id=3,
                                FirstName = "Georgy",
                                LastName="Georgyev",
                                Marks = new Mark[]
                                {
                                    new Mark()
                                    {
                                        Subject="C#",
                                        Score=6
                                    },
                                    new Mark()
                                    {
                                        Subject="Slice&Dice",
                                        Score=4
                                    },new Mark()
                                    {
                                        Subject="PHP",
                                        Score=4
                                    }
                                }
                            }
                                 };
            this.students = students;
        }
    }
}

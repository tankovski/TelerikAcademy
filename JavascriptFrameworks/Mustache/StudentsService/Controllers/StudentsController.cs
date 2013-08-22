using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsService.Controllers
{
    public class StudentsController : ApiController
    {
        public ICollection<Student> GetAll()
        {
            var students =new Student[] {
                new Student()
                {
                    FirstName="Doncho",
                    LastName="Minkov",
                    Marks = new Mark[]
                    {
                        new Mark()
                        {
                            Subjeckt="C#",
                            Score = 4
                        },
                        new Mark()
                        {
                            Subjeckt="CSS",
                            Score = 6
                        }
                    }
                },
                new Student()
                {
                    FirstName="Ivaylo",
                    LastName="Kenov",
                    Marks = new Mark[]
                    {
                        new Mark()
                        {
                            Subjeckt="C#",
                            Score = 4
                        }
                    }
                },new Student()
                {
                    FirstName="Svetlin",
                    LastName="Nakov"
                }
                           };


            return students;
        }
    }
}

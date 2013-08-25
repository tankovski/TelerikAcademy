using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentsServices.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "fname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lname")]
        public string LastName { get; set; }

        [DataMember(Name = "fullName")]
        public string FullName 
        {
            get { return this.FirstName + " " + this.LastName; }
            set { } 
        }

        [DataMember(Name = "marks")]
        public ICollection<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

    }
}
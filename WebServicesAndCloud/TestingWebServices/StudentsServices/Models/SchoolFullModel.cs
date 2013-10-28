using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsServices.Models
{
    public class SchoolFullModel:SchoolModel
    {
        public ICollection<StudentModel> Students { get; set; }

        public SchoolFullModel()
        {
            this.Students= new HashSet<StudentModel>();
        }
    }
}
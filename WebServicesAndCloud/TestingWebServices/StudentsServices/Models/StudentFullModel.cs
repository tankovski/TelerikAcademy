using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsServices.Models
{
    public class StudentFullModel:StudentModel
    {
        
        public SchoolModel School { get; set; }
        public IEnumerable<MarksModel> Marks { get; set; }

        public StudentFullModel()
        {
            this.Marks = new HashSet<MarksModel>();
        }
    }
}
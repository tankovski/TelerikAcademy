using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Exam.Web.Models
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max lenght of the UserName must be 100 symbols")]
        public string Name { get; set; }
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return cat => new CategoryViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name
                };
            }
        }
    }
}

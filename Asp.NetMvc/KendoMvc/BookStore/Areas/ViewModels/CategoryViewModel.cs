using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookStore.Areas.ViewModels
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }
    }
}
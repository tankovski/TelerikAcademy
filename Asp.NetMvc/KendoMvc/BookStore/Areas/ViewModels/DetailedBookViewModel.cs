using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace KendoForMVCDemos.Areas.Administration.ViewModels
{
    public class DetailedBookViewModel
    {
        public static Expression<Func<Book, DetailedBookViewModel>> FromBook
        {
            get
            {
                return b => new DetailedBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    CategoryName = b.Category.Name,
                    Isbn=b.ISBN,
                    WebSite=b.WebSite
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
        public string Isbn { get; set; }

        public string WebSite { get; set; }

        public string CategoryName { get; set; }
    }
}
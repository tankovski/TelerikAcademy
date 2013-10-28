using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Url { get; set; }

        public ImageModel(Image image)
        {
            Id = image.Id;
            ArticleId = image.ArticleId;
            Url = image.Url;
        }
    }
}
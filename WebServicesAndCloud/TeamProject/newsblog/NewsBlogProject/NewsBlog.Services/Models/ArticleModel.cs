using System;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }

        public ArticleModel() { }


        public ArticleModel(Article article)
        {
            this.Id = article.Id;
            this.Title = article.Title;
            this.Content = article.Content;
            this.Date = article.Date;
            this.Author = article.User.Username;
        }

        public Article CreateArticle()
        {
            Article article = new Article();

            article.Title = this.Title;
            article.Content = this.Content;

            return article;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class ArticleDetails : ArticleModel
    {
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<VoteModel> Votes { get; set; }
        public ICollection<ImageModel> Images { get; set; }

        public ArticleDetails(Article article)
            : base(article)
        {
            this.Comments = new List<CommentModel>();
            this.Votes = new List<VoteModel>();
            this.Images = new List<ImageModel>();
            this.FillData(article);
        }

        private void FillData(Article article)
        {
            foreach (var comment in article.Comments)
            {
                this.Comments.Add(new CommentModel(comment));
            }

            foreach (var vote in article.Votes)
            {
                this.Votes.Add(new VoteModel(vote));
            }

            foreach (var image in article.Images)
            {
                this.Images.Add(new ImageModel(image));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwitterData;

namespace TwitterProject.ViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }

        public string UserName { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel
                {
                    Id = tweet.Id,
                    Text = tweet.Text,
                    DatePosted = tweet.DatePosted,
                    UserName = tweet.AspNetUser.UserName
                };
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TwitterData;

namespace TwitterProject.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<AspNetUser, UserModel>> FromUser
        {
            get
            {
                return user => new UserModel
                {
                    Id = user.Id,
                    Name = user.UserName
                };
            }
        }
    }
}
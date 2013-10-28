using System;
using System.Linq;
using NewsBlog.Model;

namespace NewsBlog.Services.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
        }

        public User CreateUser()
        {
            User user = new User();

            user.Username = this.Username;
            user.Password = this.Password;

            return user;
        }
    }
}
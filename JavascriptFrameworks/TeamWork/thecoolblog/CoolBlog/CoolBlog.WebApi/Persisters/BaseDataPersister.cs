namespace CoolBlog.WebApi.Persisters
{
    using System;
    using System.Linq;
    using CoolBlog.Model;
    using CoolBlog.WebApi.Models;

    public class BaseDataPersister
    {
        protected const int Sha1CodeLength = 40;
        protected static Random rand = new Random();

        protected static User GetUser(int userId, CoolBlogEntity context)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ServerErrorException("Invalid user", "ERR_INV_USR");
            }

            return user;
        }
    }
}
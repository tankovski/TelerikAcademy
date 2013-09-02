namespace CoolBlog.WebApi.Models
{
    using System;

    public class UserExtendedModel
    {
        public string Nickname { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Rank { get; set; }

        public Nullable<bool> IsBanned { get; set; }
    }
}
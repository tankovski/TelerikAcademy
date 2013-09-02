namespace CoolBlog.WebApi.Models
{
    public class UserRegisterModel : UserLoginModel
    {
        public string Nickname { get; set; }

        public string Gender { get; set; }

        public int RankId { get; set; }

        public string Email { get; set; }
    }
}
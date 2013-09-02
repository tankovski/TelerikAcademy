namespace CoolBlog.WebApi.Models
{
    public class UserLoggedModel : UserMinimalModel
    {
        public string SessionKey { get; set; }
        public string Rank { get; set; }
    }
}
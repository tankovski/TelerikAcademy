using System.Runtime.Serialization;

namespace CoolBlog.WebApi.Models
{
    [DataContract]
    public class TagModel
    {
        //   {
        //    "name": "tag1"
        //   }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}

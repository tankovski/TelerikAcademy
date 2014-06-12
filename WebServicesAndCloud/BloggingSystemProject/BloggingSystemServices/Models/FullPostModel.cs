using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystemServices.Models
{
    [DataContract]
    public class FullPostModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public ICollection<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public ICollection<CommentModel> Comments { get; set; }

        public FullPostModel()
        {
            this.Tags = new HashSet<string>();
            this.Comments = new HashSet<CommentModel>();
        }
    }
}
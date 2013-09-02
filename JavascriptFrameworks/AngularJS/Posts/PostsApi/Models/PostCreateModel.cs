using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostsApi.Models
{
    public class PostCreateModel
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }

        public virtual ICollection<string> Categories { get; set; }

        public PostCreateModel()
        {
            this.Categories = new HashSet<string>();
        }
    }
}
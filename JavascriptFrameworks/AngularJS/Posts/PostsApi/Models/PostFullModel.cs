using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostsApi.Models
{
    public class PostFullModel
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }

        public PostFullModel()
        {
            this.Categories = new HashSet<CategoryModel>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystemServices.Models
{
    [DataContract]
    public class AddedPost
    {
        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
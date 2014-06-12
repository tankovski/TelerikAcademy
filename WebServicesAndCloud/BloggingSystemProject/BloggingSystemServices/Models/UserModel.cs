using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystemServices.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string AuthCode { get; set; }

    }
}
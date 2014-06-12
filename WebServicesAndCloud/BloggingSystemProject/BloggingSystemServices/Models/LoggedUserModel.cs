using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystemServices.Models
{
    [DataContract]
    public class LoggedUserModel
    {
        [DataMember(Name="displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

    }
}
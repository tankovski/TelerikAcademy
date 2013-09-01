using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankSystemAPI.Models
{
    [DataContract]
    public class LoggedUserModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentsServices.Models
{
    [DataContract]
    public class Mark
    {
        [DataMember(Name="subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}
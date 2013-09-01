using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankSystemAPI.Models
{
    [DataContract]
    public class UserMoneyModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }
        [DataMember(Name = "avelableMoney")]
        public long AvelableMoney { get; set; }
    }
}
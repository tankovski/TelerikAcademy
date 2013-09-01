using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankSystemAPI.Models
{
    
    public class LogModel
    {
        public int Id { get; set; }
        public long OldSum { get; set; }
        public long NewSum { get; set; }
        public System.DateTime TransDate { get; set; }
        public int UserId { get; set; }
    }
}
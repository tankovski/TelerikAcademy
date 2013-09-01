using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankSystemData;
using BankSystemAPI.Models;

namespace BankSystemAPI.Controllers
{
    public class LogController : ApiController
    {
        [HttpGet]
        [ActionName("get")]
        public ICollection<LogModel> GetGrid(string sessionKey)
        {
            var context = new BankSystemEntities();
            var user = context.Users.FirstOrDefault(u => u.AuthKey == sessionKey);

            if (user==null)
            {
                throw new InvalidOperationException("No such user loged");
            }

            var logs = context.LogInfoes.Where(l=> l.UserId==user.Id);

            var models =
                from log in logs
                select new LogModel()
                {
                    NewSum = log.NewSum,
                    OldSum = log.OldSum,
                    TransDate = log.TransDate
                };

            return models.ToList();
        }
    }
}

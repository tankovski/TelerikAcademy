
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterData
{
    public interface IUowData : IDisposable
    {
        IRepository<AspNetUser> Users { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}

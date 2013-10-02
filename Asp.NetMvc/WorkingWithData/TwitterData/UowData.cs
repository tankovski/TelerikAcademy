
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterData
{
    public class UowData : IUowData
    {
        private readonly TwitterEntities context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        
        public UowData()
            : this(new TwitterEntities())
        {
        }

        public UowData(TwitterEntities context)
        {
            this.context = context;
        }

        public IRepository<AspNetUser> Users
        {
            get
            {
                return this.GetRepository<AspNetUser>();
            }
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}

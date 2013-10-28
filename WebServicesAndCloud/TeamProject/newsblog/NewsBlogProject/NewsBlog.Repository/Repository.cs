using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog.Repository
{
    public class Repository<T>: IRepository<T> where T: class
    {
        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public T Add(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }

            this.Context.SaveChanges();
            return this.DbSet.Add(item);
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
            
            this.Context.SaveChanges();
        }

        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;

            this.Context.SaveChanges();
        }
    }
}

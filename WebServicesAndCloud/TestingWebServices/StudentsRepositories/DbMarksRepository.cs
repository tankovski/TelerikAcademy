using StudentsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsRepositories
{
    public interface IMarksRepository : IRepository<Mark>
    { }

    public class DbMarksRepository:IMarksRepository
    {
         private DbContext dbContext;
        private DbSet<Mark> entitySet;

        public DbMarksRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Mark>();
        }

        public IQueryable<Mark> Find(Expression<Func<Mark, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public Mark Add(Mark entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Mark Update(int id, Mark entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Mark Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Mark> All()
        {
            return this.entitySet;
        }
    }
}

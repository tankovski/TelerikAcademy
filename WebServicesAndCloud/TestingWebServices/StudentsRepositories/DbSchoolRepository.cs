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
    public interface ISchoolRepository : IRepository<School>
    { }

    public class DbSchoolRepository:ISchoolRepository
    {
        private DbContext dbContext;
        private DbSet<School> entitySet;

        public DbSchoolRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<School>();
        }

        public IQueryable<School> Find(Expression<Func<School, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public School Add(School entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public School Update(int id, School entity)
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

        public School Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<School> All()
        {
            return this.entitySet;
        }
    }
}

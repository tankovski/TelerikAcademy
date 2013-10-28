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
    public interface IStudentsRepository : IRepository<Student>
    { }

    public class DbStudentsRepository:IStudentsRepository
    {
        private DbContext dbContext;
        private DbSet<Student> entitySet;

        public DbStudentsRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Student>();
        }

        public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public Student Add(Student entity)
        {
            if (entity.FirstName == null || entity.FirstName.Length == 0)
            {
                throw new ArgumentNullException("FirstName can not be empty");
            }
            if (entity.LastName == null || entity.LastName.Length == 0)
            {
                throw new ArgumentNullException("LastName can not be empty");
            }
            if (entity.Grade<1 || entity.Grade>12)
            {
                throw new ArgumentException("Grade must be form 1 to 12");
            }
            if (entity.Age < 6)
            {
                throw new ArgumentException("Age must be more than 6");
            }

            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();

            return entity;
        }

        public Student Update(int id, Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity!=null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid Id");
            }
        }

        public Student Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Student> All()
        {
            return this.entitySet;
        }
    }
}

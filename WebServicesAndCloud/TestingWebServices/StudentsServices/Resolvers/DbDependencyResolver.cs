using StudentsDataLayer;
using StudentsModels;
using StudentsRepositories;
using StudentsServices.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace StudentsServices.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver   
    {
        private static DbContext studentsContext = new StudentsContext();

        private static IRepository<Student> repository = new DbStudentsRepository(studentsContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           
        }
    }
}
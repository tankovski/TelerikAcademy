using StudentsDataLayer;
using StudentService.Controllers;
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
        private static IRepository<School> schoolRepository = new DbSchoolRepository(studentsContext);

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
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(schoolRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}
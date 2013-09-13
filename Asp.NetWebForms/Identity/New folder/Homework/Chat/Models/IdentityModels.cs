using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebFormsTemplate.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

    }

    // You can inherit the base IdentityContext and add your application custom DbSets
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext() 
            : base ("DefaultConnection")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
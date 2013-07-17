using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersEntetiesData;
using System.Transactions;

namespace UsersAndGroupsDatabase
{
    class Program
    {
        static void Main()
        {
            using (UsersEntities usersDb = new UsersEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    bool haveAdminGroup = usersDb.Groups.Where(x => x.GroupName == "Admins").ToList().Count > 0;
                    if (!haveAdminGroup)
                    {
                        Group admins = new Group
                        {
                            GroupName = "Admins"
                        };

                        usersDb.Groups.Add(admins);
                        usersDb.SaveChanges();
                    }
                  

                    int adminsId = usersDb.Groups.Where(x => x.GroupName == "Admins").First().GroupId;

                    User user = new User
                    {
                        UserName = "RandomName2",
                        GroupId = adminsId
                    };

                    usersDb.Users.Add(user);
                    usersDb.SaveChanges();

                    scope.Complete();
                }
            }
        }
    }
}

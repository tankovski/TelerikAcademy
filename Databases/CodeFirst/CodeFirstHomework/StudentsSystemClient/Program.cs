using System;
using System.Linq;
using StudentsSystemData;
using StudentsSystemData.Migrations;
using StudentsSystemModel;
using System.Data.Entity;



public class Program
{
    static void Main()
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());


        StudentSystemContext studentSystemDb = new StudentSystemContext();

        foreach (var item in studentSystemDb.Students)
        {
            Console.WriteLine("Name: {0} with studentNumber {1}",item.StudentName +' '+ item.StudentLastName,item.StudentNumber);
        }

        studentSystemDb.SaveChanges();
    }
}


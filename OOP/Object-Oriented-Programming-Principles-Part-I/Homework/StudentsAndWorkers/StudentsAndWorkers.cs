using System;
using System.Collections.Generic;
using System.Linq;

class StudentsAndWorkers
{
    static void Main()
    {

        //Define abstract class Human with first name and last name. Define new class Student 
        //which is derived from Human and has new field – grade. Define class Worker derived 
        //from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
        //that returns money earned by hour by the worker. Define the proper constructors and 
        //properties for this hierarchy. Initialize a list of 10 students and sort them by grade 
        //in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10 workers 
        //and sort them by money per hour in descending order. Merge the lists and sort them by first 
        //name and last name.

        try
        {

            //Make list of students and sort them by grade
            List<Student> studentsList = new List<Student> {new Student("Ivo","Georgiev",3),
                                                 new Student("Ivan","Petrov",2),
                                                 new Student("Drago","Vasilev",1),
                                                 new Student("Stefan","Ivanov",7),
                                                 new Student("Ivo","Soqnov",9),
                                                 new Student("Boiko","Boriosv",6),
                                                 new Student("Vasil","Iliev",5),
                                                 new Student("Atanas","Djambazov",8),
                                                 new Student("Mitko","Todorov",5),
                                                 new Student("Teodor","Kazandjiev",5)};
            studentsList = studentsList.OrderByDescending(student => student.Grade).ToList();
            foreach (Student student in studentsList)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Grade);
            }
            Console.WriteLine();

            //Make a list of workers and sort them by money per hour
            List<Worker> workerList = new List<Worker>{new Worker("Ivo","Draganov",300,8),
                                                           new Worker("Vejdi","Rashidov",250,4),
                                                           new Worker("Radoslav","Ivanov",390,8),
                                                           new Worker("Stoqn","Stamenov",3000,6),
                                                           new Worker("Filip","Nenchev",200,3),
                                                           new Worker("Stefan","Dobrev",1300,8),
                                                           new Worker("Ivo","Balkandjiev",300,8),
                                                           new Worker("Dimitur","Djambazov",400,6),
                                                           new Worker("Nikolay","Vuldobrev",300,8),
                                                           new Worker("Stoil","Slavchev",3300,8)};
            workerList = workerList.OrderByDescending(worker => worker.MoneyPerHour()).ToList();
            foreach (Worker worker in workerList)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName + " " + worker.MoneyPerHour());
            }
            Console.WriteLine();


            //Merge the lists and sort by name
            var mergedlists = workerList.Concat<Human>(studentsList).ToList();
            mergedlists = mergedlists.OrderBy(list => list.FirstName).ThenBy(list => list.LastName).ToList();

            foreach (Human human in mergedlists.OrderBy(human => human.FirstName).ThenBy(human => human.LastName))
            {
                Console.WriteLine(human.FirstName + " " + human.LastName + "-" + human.GetType());
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine("Error!" + ex.Message);
        }
    }
}


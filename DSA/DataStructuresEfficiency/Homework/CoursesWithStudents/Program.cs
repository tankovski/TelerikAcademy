using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Wintellect.PowerCollections;


class Program
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"../../../students.txt");
        SortedDictionary<string, OrderedBag<Student>> courses = new SortedDictionary<string, OrderedBag<Student>>(); 
        using (reader)
        {
          
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] info = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (courses.ContainsKey(info[2]))
                {
                    courses[info[2]].Add(new Student(info[0], info[1]));
                }
                else
                {
                    courses[info[2]] = new OrderedBag<Student> { new Student(info[0], info[1]) };
                }
            }

            foreach (var item in courses.OrderBy(x=> x.Key))
            {
                var students = item.Value;
                Console.Write("{0}: ",item.Key);
                foreach (var student in students)
                {
                    Console.Write(student.FirstName +" "+ student.LastName+", ");
                }
                Console.WriteLine();
            } 

              
        }
    }
}


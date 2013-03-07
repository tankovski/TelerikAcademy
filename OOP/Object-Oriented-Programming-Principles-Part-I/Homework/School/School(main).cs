using System;
using System.Collections.Generic;
using System.Text;


class School
{
    static void Main(string[] args)
    {

        //We are given a school. In the school there are classes of students. Each class
        //has a set of teachers. Each teacher teaches a set of disciplines. Students have
        //name and unique class number. Classes have unique text identifier. Teachers have
        //name. Disciplines have name, number of lectures and number of exercises. Both teachers
        //and students are people. Students, classes, teachers and disciplines could have optional
        //comments (free text block).
	    //Your task is to identify the classes (in terms of  OOP) and their attributes and operations,
        //encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.



        //I use this class(class Scool) like a scool.
        try
        {
            //Initialize some students
            Student joro = new Student("Joro", 19877);
            Student petur = new Student("Petur", 19878);
            Student ivo = new Student("Ivo", 19879);

            //...some disciplines
            Discipline math = new Discipline("Mathematic", 8, 5);
            Discipline bio = new Discipline("Biology", 7, 3);

            // ... teacher
            Teacher ivanov = new Teacher("Ivanov");
            //Adding some disciplines that he teaching
            ivanov.SetOfDisciplines.Add(math);
            ivanov.SetOfDisciplines.Add(bio);
            

            //Make a class with students and teacher
            Class theBestClass = new Class("The best of the best");
            theBestClass.SetOfStudents.Add(joro);
            theBestClass.SetOfStudents.Add(petur);
            theBestClass.SetOfStudents.Add(ivo);
            theBestClass.SetOfTeachers.Add(ivanov);
            Console.WriteLine("Our clas - \"{0}\" have {1} studets :\n{2}and {3} teacher(s) :\n{4}"
                , theBestClass.UniqueTextIdentifier, theBestClass.SetOfStudents.Count, theBestClass.Students()
                , theBestClass.SetOfTeachers.Count, theBestClass.Teachers());

            //Add and show some optional comments
            ivo.AddComment("Ivo is football player");
            ivanov.AddComment("Mr. Ivanov do not like football players.");
            Console.WriteLine(ivo.ShowComment()+","+ivanov.ShowComment());



        }
        catch (Exception ex)
        {

            Console.WriteLine("Error!" + ex.Message); ;
        }

    }
}


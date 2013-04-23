using System;

    static class ComparePeople
    {
        public static bool FindWhoIsOlder(Student firstStudent, Student secondStudent) //In normal situation this will be with Human not Student
        {
            DateTime firstDate =
                DateTime.Parse(firstStudent.OtherInfo.Substring(firstStudent.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(secondStudent.OtherInfo.Substring(secondStudent.OtherInfo.Length - 10));
            bool isOlder = firstDate > secondDate;

            return isOlder;
        }
    }


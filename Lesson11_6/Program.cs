using System;
using System.Collections.Generic;

namespace Lesson11_6
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Score { get; set; }
        public DateTime Birthdate { get; set; }

        public override string ToString() => $@"
Name: {Name}
Surname: {Surname}
Score: {Score}
Birthdate: {Birthdate}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stundets = new List<Student>
            {
                new Student
                {
                    Name = "Zahid",
                    Surname = "Vahabzade",
                    Birthdate = new DateTime(2001, 11, 03),
                    Score = 11
                }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Student
    {
      
        public string Studentname { get; set; }
        public string Section { get; set; }
        //public int Grade { get; set; }

        public double SeatworkGrade { get; set; }

        //Constructor
        public Student(string studentname, string section)
        {
            this.Studentname = studentname ?? throw new ArgumentNullException(nameof(studentname));
            this.Section = section ?? throw new ArgumentNullException(nameof(section));
            //this.Grade = grade;
        }

       
    }

    public class StudentInfoMethods
    {

        public static List<Student> studentlist = new();
        public static void CreateStudent()
        {
            string studname;
            string section;
           

            //strings into uppercase

            string studentnameupper;
            string sectionupper;

            try
            {
                Console.WriteLine("");
                Console.Write("Enter Name Here: ");
                studname = Console.ReadLine();
                Console.Write("Enter Section here: ");
                section = Console.ReadLine();
              
               

                studentnameupper = studname.ToUpper();
                sectionupper = section.ToUpper();

                Student student = new(studentnameupper, sectionupper);
                studentlist.Add(student);

                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine("An Invalid Input was detected, returning to main menu");
                studentlist.RemoveAt(studentlist.Count - 1);

            }

        }

        public static void GetStudentInfo()
        {
            foreach (Student student in studentlist)
            {
                Console.WriteLine($"Name: {student.Studentname}");
                Console.WriteLine($"Section: {student.Section}");
                Console.WriteLine($"Seatwork Grade: {student.SeatworkGrade}");

                Console.WriteLine("");
            }
        }

       

    }
}



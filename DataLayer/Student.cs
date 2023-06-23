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



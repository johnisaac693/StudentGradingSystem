using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   

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



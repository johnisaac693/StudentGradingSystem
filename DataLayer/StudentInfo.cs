using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentInfo
    {
        public static List<StudentInfo> studentlist = new();
        public string Studentname { get; set; }
        public string Section { get; set; }
        public int Grade { get; set; }

        //Constructor
        public StudentInfo(string studentname, string section, int grade)
        {
            this.Studentname = studentname ?? throw new ArgumentNullException(nameof(studentname));
            this.Section = section ?? throw new ArgumentNullException(nameof(section));
            this.Grade = grade;
        }
    }

    public class StudentInfoMethods
    {
        public static void CreateStudent()
        {
            string studname;
            string section;
            int grade;

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
                Console.Write("Enter Grade here: ");
                grade = Convert.ToInt32(Console.ReadLine());

                studentnameupper = studname.ToUpper();
                sectionupper = section.ToUpper();

                StudentInfo student = new(studentnameupper, sectionupper, grade);
                StudentInfo.studentlist.Add(student);
            }
            catch (Exception e)
            {
                Console.WriteLine("An Invalid Input was detected, returning to main menu");
                StudentInfo.studentlist.RemoveAt(StudentInfo.studentlist.Count - 1);

            }

        }

        public static void GetStudentInfo()
        {
            foreach (StudentInfo student in StudentInfo.studentlist)
            {
                Console.WriteLine($"Name: {student.Studentname}");
                Console.WriteLine($"Section: {student.Section}");
                Console.WriteLine($"Grade: {student.Grade}");
                Console.WriteLine("");
            }
        }

    }
}



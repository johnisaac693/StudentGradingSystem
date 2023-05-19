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
        public string studentname { get; set; }
        public string section { get; set; }
        public int grade { get; set; }

        public StudentInfo(string studentname, string section, int grade)
        {
            this.studentname = studentname ?? throw new ArgumentNullException(nameof(studentname));
            this.section = section ?? throw new ArgumentNullException(nameof(section));
            this.grade = grade;
        }

        public static void GetStudentInfo()
        {
            foreach (StudentInfo student in studentlist)
            {
                Console.WriteLine($"Name: {student.studentname}");
                Console.WriteLine($"Section: {student.section}");
                Console.WriteLine($"Course: {student.grade}");
                Console.WriteLine("");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentInfo
    {
       
        public string studentname { get; set; }
        public string section { get; set; }
        public int grade { get; set; }

        public StudentInfo(string studentname, string section, int grade)
        {
            this.studentname = studentname ?? throw new ArgumentNullException(nameof(studentname));
            this.section = section ?? throw new ArgumentNullException(nameof(section));
            this.grade = grade;
        }
    }
}

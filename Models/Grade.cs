using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grade
    {
        public string Studentname { get; set; }
        public double Seatworkgrade { get; set; }
        public double Quizgrade { get; set; }
        public double Recitgrade { get; set; }
        public double Attendancegrade { get; set; }
        public double Projectgrade { get; set; }
        public double Totalgrade { get; set; }

        public double Examgrade { get; set; }

        public double Midtermgrade { get; set; }

        public double Finalgrade { get; set; }

        
    }
}

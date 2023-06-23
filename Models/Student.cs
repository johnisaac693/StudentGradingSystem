namespace Models
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
}
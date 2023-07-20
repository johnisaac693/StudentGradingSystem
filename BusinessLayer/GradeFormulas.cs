using DataLayer;

namespace BusinessLayer
{
    public class GradeFormulas
    {

        public static double GradeCompute(double sum, double itemtotal)
        {
            double grade = (sum / itemtotal) * 100;
            double graderound = Math.Round(grade,2);
            return graderound;
        }

        public static double AttendanceCompute(double daysattended, double daystotal)
        {
            double grade = (daysattended / daystotal) * 100;
            double graderound = Math.Round(grade, 2);
            return graderound;
        }




    }



}
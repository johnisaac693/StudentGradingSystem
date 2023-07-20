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

        /*public static double TotatlGradeCompute()
        {
            double grade = 0;
        }*/

        public static double TabulateGrade(double swgrade, double qgrade, double recitgrade, double attgrade, double projgrade, double examgrade)
        {
            double ClassStanding = ((swgrade + qgrade + recitgrade + attgrade + projgrade) / 5) * 100 * 0.7;
            double ExamStanding = examgrade * 0.3;

            double TabulatedGrade = ClassStanding + ExamStanding;
            double tabulatedround = Math.Round(TabulatedGrade, 2);

            return tabulatedround;

        }

    }



}
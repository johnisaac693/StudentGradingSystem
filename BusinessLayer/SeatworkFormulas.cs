using DataLayer;

namespace BusinessLayer
{
    public class SeatworkFormulas
    {

        public static double QuizSeatworkGradeCompute(double sum, double itemtotal)
        {
            double grade = (sum / itemtotal) * 100;

            return grade;
        }
    }

}
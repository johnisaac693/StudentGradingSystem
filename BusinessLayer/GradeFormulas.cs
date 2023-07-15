using DataLayer;

namespace BusinessLayer
{
    public class GradeFormulas
    {

        public static double GradeCompute(double sum, double itemtotal)
        {
            double grade = (sum / itemtotal) * 100;

            return grade;
        }

       


    }

    

}
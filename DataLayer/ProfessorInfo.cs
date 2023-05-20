namespace DataLayer
{
    public class ProfessorInfo
    {
        public static bool FacultyCheck()
        {
            string profcheck;
            Console.WriteLine("Are you a Professor, or Student?");
            profcheck = Console.ReadLine();
            string profupper = profcheck.ToUpper();

            if (profupper == "PROFESSOR")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
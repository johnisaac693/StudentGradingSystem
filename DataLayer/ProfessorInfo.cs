namespace DataLayer
{
    public class ProfessorInfo
    {
        public static bool FacultyCheck()
        {
            Console.WriteLine("Are you a Professor, or Student?");
            string profcheck = Console.ReadLine();
            string profupper = profcheck.ToUpper();

            return (profupper == "PROFESSOR");
        }



    }
}
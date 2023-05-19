using System;

namespace GUI
{
    public class UserInterfaces
    {
        //LISTS
       public static readonly List<string> MenuOptions = new()
     {"Enter Student Info - Press 1", "View Students and Info - Press 2", "Input Grades - Press 3", "Exit - 0"};

       public static readonly List<string> GradingOptions = new()
     {"Seatworks - Press 1", "Quizzes - Press 2", "Recitations - Press 3", "Performance Tasks - 4", "Midterms - 5", "Finals - 6", "Add Optional Toggles - 7", "Back - 0"};

        public static readonly List<string> AddToggles = new()
        {"Attendance - 1", "Attitude - 2"};

        //MENU METHODS

        public static void ViewMenu() // view menu
        {
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }

        }

        public static void ViewGradingOptions() // View Grading Options
        {
            foreach (var option in GradingOptions)
            {
                Console.WriteLine(option);
            }
        }

        public static void ViewToggles()
        {
            foreach (var toggle in AddToggles)
            {
                Console.WriteLine(toggle);
            }
        }


        //Choice Variables
        public static int ViewGradingSelect()
        {
            
                try
                {
                    Console.WriteLine("Select your action");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    return choice;
                }
                catch
                {
                    return 0;
                }

        }
        public static int ViewMenuSelect()
        {
            try
            {
                Console.WriteLine("Select your action");
                int choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            catch
            {
                return 0;
            }



        }

        public static int ToggleSelect()
        {
            try
            {
                Console.WriteLine("Select your action");
                int choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            catch
            {
                return 0;
            }



        }
    }
}
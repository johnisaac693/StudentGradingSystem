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

        public static void SpecialStudentGradeGUI()
        {

            ViewGradingOptions();
            int gradeselectmenu = ViewGradingSelect();

            while (gradeselectmenu != 0)
            {
                switch (gradeselectmenu)
                {
                    case 1:
                        Console.WriteLine("Seatworks");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();

                        break;
                    case 2:
                        Console.WriteLine("Quizzes");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 3:
                        Console.WriteLine("Recitations");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 4:
                        Console.WriteLine("Performance Tasks");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 5:
                        Console.WriteLine("Midterms");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 6:
                        Console.WriteLine("Finals");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 7:
                        Console.WriteLine("Optional Toggles");
                        ViewGradingOptions();

                        Console.WriteLine("");
                        gradeselectmenu = ViewGradingSelect();
                        break;

                    default:
                        gradeselectmenu = 0;
                        break;
                }
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

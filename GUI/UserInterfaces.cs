using System;

namespace GUI
{
    public class UserInterfaces
    {
       public static readonly List<string> MenuOptions = new()
     {"Enter Student Info - Press 1", "View Students and Info - Press 2", "Input Grades - Press 3", "Exit - 0"};

       public static void ViewMenu() // view menu
        {
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
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
    }
}
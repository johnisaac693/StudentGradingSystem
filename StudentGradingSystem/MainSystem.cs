using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataLayer;



public class MainSystem 
{
    static List<string> menuoptions = new List<string>()
     {"Enter Student Info - Press 1", "View Students and Info - Press 2", "Input Grades - Press 3", "Exit - 0"};
    static void Main(string[] args)
    {
        if (FacultyCheck() == true)
        {
            StudentInfo infoinput = new StudentInfo();

            Console.WriteLine("Welcome to the Grading System");
            Console.WriteLine("Here are your options: ");
            ViewMenu();
            int selectmenu = ViewMenuSelect();

            while (selectmenu != 0)
            {
                switch (selectmenu)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.Write("Enter Name Here: ");
                        infoinput.studentname = Console.ReadLine();
                        Console.WriteLine("");

                        ViewMenu();
                        selectmenu = ViewMenuSelect();
                        break;

                    case 2:
                        Console.WriteLine("Viewing Student/s:");
                        Console.WriteLine(infoinput.studentname);
                        ViewMenu();
                        selectmenu = ViewMenuSelect();
                        break;

                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Input grades sample");
                        Console.WriteLine("");
                        ViewMenu();
                        selectmenu = ViewMenuSelect();
                        break;

                   
                    default:
                        Console.WriteLine("Goodbye");
                        selectmenu = 0;
                        break;
                }

            }


        }
        else 
        {
            Console.WriteLine("Sorry, you are not allowed to access this page");
        }
    }

    static bool FacultyCheck()
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

    static void ViewMenu() // view menu
    {
        foreach (var option in menuoptions) 
        {
            Console.WriteLine(option);
        }
       
        
    }

    private static void ProfessorGradingInterface()
    {
        ViewMenu();
    }

    static int ViewMenuSelect()
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

using System;
using System.Collections.Generic;
using DataLayer;



public class MainSystem 
{
    static List<string> menuoptions = new List<string>()
     {"Enter Student Info - Press 1", "Input Grades - Press 2", "Exit - 0", };
    static void Main(string[] args)
    {
        if (FacultyCheck() == true)
        {
            Console.WriteLine("Welcome to the Grading System");
            Console.WriteLine("Here are your options: ");
            ViewMenu();


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

    private int ViewMenuSelect()
    {
        Console.WriteLine("Select your action");
        int choice = Convert.ToInt32(Console.ReadLine());

        return choice;
    }

   
}

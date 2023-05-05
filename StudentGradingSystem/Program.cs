using System;
using System.Collections.Generic;
using GradeSystemRules;


public class Program 
{
    static List<string> menuoptions = new List<string>()
     {"Enter Student Info - Press 1", "Input Grades - Press 2", "Exit - 0", };
    static void Main(string[] args)
    {
       
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

   
}

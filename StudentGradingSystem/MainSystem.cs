using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using DataLayer;
using GUI;


public class MainSystem

{
    

   
    static void Main(string[] args)
    {
        UserInterfaces UI = new UserInterfaces();
        if (ProfessorInfo.FacultyCheck())
        {
            UI.MainMenu();
        }
        else 
        {
            Console.WriteLine("Sorry, you are not allowed to access this page");
        }
    }

   
    

   

   

   
}

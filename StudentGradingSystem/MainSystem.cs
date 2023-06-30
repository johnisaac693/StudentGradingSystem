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

        if (ProfessorInfo.FacultyCheck())
        {
            UserInterfaces.MainMenu();
        }
        else 
        {
            Console.WriteLine("Sorry, you are not allowed to access this page");
        }
    }

   
    

   

   

   
}

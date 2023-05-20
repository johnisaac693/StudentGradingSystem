﻿using System;
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

        if (ProfessorInfo.FacultyCheck() == true)
        {
            
            Console.WriteLine("Welcome to the Grading System");
            Console.WriteLine("Here are your options: ");
            UserInterfaces.ViewMenu();
            int selectmenu = UserInterfaces.ViewMenuSelect();

            while (selectmenu != 0)
            {
                switch (selectmenu)
                {
                    case 1:
                        

                        Console.WriteLine("");// Linebreak for when the menu activates
                        StudentInfoMethods.CreateStudent();
                        UserInterfaces.ViewMenu();

                        //Enter Student Info - Press 1  
                        //View Students and Info -Press 2  
                        //Input Grades - Press 3 
                        //Exit - 0

                        selectmenu = UserInterfaces.ViewMenuSelect();
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Viewing Student/s:");
                        StudentInfoMethods.GetStudentInfo();
                        Console.WriteLine("");
                        UserInterfaces.ViewMenu();
                        selectmenu = UserInterfaces.ViewMenuSelect();
                        break;

                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Input grades");
                        UserInterfaces.SpecialStudentGradeGUI();
                        Console.WriteLine("");
                        UserInterfaces.ViewMenu();
                        selectmenu = UserInterfaces.ViewMenuSelect();
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

   
    

   

   

   
}

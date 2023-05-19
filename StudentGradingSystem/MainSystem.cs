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

        if (FacultyCheck() == true)
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
                        UserInterfaces.ViewGradingOptions();
                        int gradeselectmenu = UserInterfaces.ViewGradingSelect();

                        while (gradeselectmenu != 0)
                        {
                            switch (gradeselectmenu)
                            {
                                case 1:
                                    Console.WriteLine("Seatworks");
                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();

                                    break;
                                case 2:
                                    Console.WriteLine("Quizzes");
                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                case 3:
                                    Console.WriteLine("Recitations");

                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                case 4:
                                    Console.WriteLine("Performance Tasks");

                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                case 5:
                                    Console.WriteLine("Midterms");

                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                case 6:
                                    Console.WriteLine("Finals");

                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                case 7:
                                    Console.WriteLine("Optional Toggles");

                                    UserInterfaces.ViewGradingOptions();
                                    gradeselectmenu = UserInterfaces.ViewGradingSelect();
                                    break;
                                
                                default:
                                    gradeselectmenu = 0;
                                    break;
                            }
                        }



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

    

   

   

   
}

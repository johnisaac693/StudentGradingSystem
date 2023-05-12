using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataLayer;





//How on earth am I able to apply this to a GUI?
//Just prepping the classes and the objects is killing me
public class MainSystem

{
    static List<string> menuoptions = new()
     {"Enter Student Info - Press 1", "View Students and Info - Press 2", "Input Grades - Press 3", "Exit - 0"};

    public static List<StudentInfo> studentlist = new();
    static void Main(string[] args)
    {

        if (FacultyCheck() == true)
        {
            
            Console.WriteLine("Welcome to the Grading System");
            Console.WriteLine("Here are your options: ");
            ViewMenu();
            int selectmenu = ViewMenuSelect();

            while (selectmenu != 0)
            {
                switch (selectmenu)
                {
                    case 1:
                        

                        Console.WriteLine("");// Linebreak for when the menu activates
                        CreateStudent();

                        ViewMenu();
                        selectmenu = ViewMenuSelect();
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Viewing Student/s:");
                        foreach (StudentInfo student in studentlist)
                        {
                            Console.WriteLine($"Name: {student.studentname}");
                            Console.WriteLine($"Section: {student.section}");
                            Console.WriteLine($"Course: {student.grade}");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
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

   static void CreateStudent()
    {
        string studname;
        string section;
        int grade;

        //strings into uppercase

        string studentnameupper;
        string sectionupper;

        try
        {
            Console.WriteLine("");
            Console.Write("Enter Name Here: ");
            studname = Console.ReadLine();
            Console.Write("Enter Section here: ");
            section = Console.ReadLine();
            Console.Write("Enter Grade here: ");
            grade = Convert.ToInt32(Console.ReadLine());

            studentnameupper = studname.ToUpper();
            sectionupper = section.ToUpper();

            StudentInfo student = new(studentnameupper, sectionupper, grade);
            studentlist.Add(student);
        }
        catch (Exception e)
        {
            Console.WriteLine("An Invalid Input was detected, returning to main menu");
            studentlist.RemoveAt(studentlist.Count - 1);

        }
         
    }
}

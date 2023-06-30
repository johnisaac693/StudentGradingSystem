using System;
using BusinessLayer;
using DataLayer;
using Models;

namespace GUI
{
    public class UserInterfaces
    {
        //LISTS
       public static readonly List<string> MenuOptions = new()
     {"Create New Grade Info - Press 1", "View Grades Inputted - 2", "Input Grades - Press 3", "Exit - 0"};

       

        public static readonly List<string> AddToggles = new()
        {"Attendance - 1", "Attitude - 2"};

        //MENU METHODS

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the Grading System");
            Console.WriteLine("Here are your options:");
            UserInterfaces.ViewMenu();

            int selectmenu;
            while ((selectmenu = UserInterfaces.ViewGradingSelect()) != 0)
            {
                switch (selectmenu)
                {
                    case 1:
                        Console.WriteLine();
                        CreateGrade();
                        
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Viewing Grade/s:");
                        ViewGrade();
                        
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Input grades");
                        string studentchoice = ChooseStudent();
                        GradeSystemGUI.SpecialStudentGradeGUI(studentchoice);
                        
                        break;

                    default:
                        Console.WriteLine("Goodbye");
                        break;
                }
                UserInterfaces.ViewMenu();
                Console.WriteLine();
            }
        }

        public static void ViewMenu() // view menu
        {
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }

        }

        

       



        //MENU FUNCTIONS
        public static void CreateGrade()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter Name of Student to Grade: ");
                string studname = Console.ReadLine()?.Trim().ToUpper();

                Grade grade = new Grade(studname);
                GradeMemory.Gradelist.Add(grade);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("An Invalid Input was detected, returning to the main menu");
                GradeMemory.Gradelist.RemoveAt(GradeMemory.Gradelist.Count - 1);
            }
        }

        public static void ViewGrade()
        {
            foreach (Grade grades in GradeMemory.Gradelist)
            {
                Console.WriteLine("Student Name: " + grades.Studentname);
                Console.WriteLine("Seatwork Grade: " +grades.Seatworkgrade);
                Console.WriteLine("Quiz Grade: " + grades.Quizgrade);
                Console.WriteLine("Project Grade: " + grades.Projectgrade);
                Console.WriteLine("Recitation Grade: " + grades.Recitgrade);
                Console.WriteLine("Exam Grade: " + grades.Examgrade);
                Console.WriteLine("Attendance Grade: " +grades.Attendancegrade);

            }
        }


        public static string ChooseStudent()
        {

            Console.WriteLine("Choose which student whose grade you choose to modify");

            foreach (Grade grade in GradeMemory.Gradelist)
            {
                Console.WriteLine(grade.Studentname);
            }
            Console.Write("Enter name: ");
            string Student = Console.ReadLine()?.Trim().ToUpper();
            return Student;
        }


        //Choice Variables
        public static int ViewGradingSelect()
        {
            
                try
                {
                Console.Write("Select your action: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                    return choice;
                }
                catch
                {
                Console.WriteLine("Invalid input detected. Returning to Main Menu");
                return 0;
                }

        }
       

       

    }
}   

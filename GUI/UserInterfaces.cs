using System;
using System.Security.Cryptography;
using BusinessLayer;
using DataLayer;
using Models;

namespace GUI
{
    public class UserInterfaces
    {

        GradesDataService gradedb = new GradesDataService();
        GradeSystemGUI gradegui = new GradeSystemGUI();
        

        //LISTS
       public static readonly List<string> MenuOptions = new()
     {"Create New Grade Info - Press 1", "View Grades Inputted - 2", "Input Grades - Press 3", "Exit - 0"};

       

        public static readonly List<string> AddToggles = new()
        {"Attendance - 1", "Attitude - 2"};

        //MENU METHODS

        public void MainMenu()
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
                        if (IsStudentExisting(studentchoice))
                        {
                            gradegui.SpecialStudentGradeGUI(studentchoice);
                        }
                        else
                        {
                            Console.WriteLine("Student does not exist");
                        }

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
            Console.WriteLine("");
        }

        

       



        //MENU FUNCTIONS
        public void CreateGrade()
        {
            
           
                Console.WriteLine();
                Console.Write("Enter Name of Student to Grade: ");
                string studname = Console.ReadLine()?.Trim().ToUpper();

                Grade grade = new Grade();
                grade.Studentname = studname;
                gradedb.CreateGrade(grade);


            
        }

        public void ViewGrade()
        {

            var grades = gradedb.getGrades();
            if (grades.Count == 0)
            {
                Console.WriteLine("This page is empty. Create a grade data to fill this up.");
            }
            else
            {
                foreach (var gradingdata in grades)
            {
                Console.WriteLine("Student Name: " + gradingdata.Studentname);
                Console.WriteLine("Seatwork Grade: " + gradingdata.Seatworkgrade);
                Console.WriteLine("Quiz Grade: " + gradingdata.Quizgrade);
                Console.WriteLine("Project Grade: " + gradingdata.Projectgrade);
                Console.WriteLine("Recitation Grade: " + gradingdata.Recitgrade);
                Console.WriteLine("Exam Grade: " + gradingdata.Examgrade);
                Console.WriteLine("Attendance Grade: " + gradingdata.Attendancegrade);
                Console.WriteLine("Midterm Grade: " + gradingdata.Midtermgrade);
                Console.WriteLine("Final Grade: " + gradingdata.Finalgrade);
                Console.WriteLine("Total Grade: " + gradingdata.Totalgrade);

                Console.WriteLine(" ");
            }
            }
            Console.WriteLine(" ");
        }


        public string ChooseStudent()
        {

            Console.WriteLine("Enter the name of the student whose grade you wish to modify: ");

            var names = gradedb.GetNames();
            if (names.Count == 0)
            {
                Console.WriteLine("This page is empty. Create a grade data to continue!");
                return null;
            }
            else
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name.Studentname);
                }
                Console.Write("Enter name: ");
                string Student = Console.ReadLine()?.Trim().ToUpper();
                return Student;
            }
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


        public bool IsStudentExisting(string studentexist)
        {
            var nameexist = gradedb.getGrades();
            foreach (var name in nameexist)
            {
                if (name.Studentname.Contains(studentexist))
                {
                    return true;
                }
            }

            return false;
        } //For checks



    }
}   

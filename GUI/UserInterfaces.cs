using System;
using BusinessLayer;
using DataLayer;

namespace GUI
{
    public class UserInterfaces
    {
        //LISTS
       public static readonly List<string> MenuOptions = new()
     {"Enter Student Info - Press 1", "View Students and Info - Press 2", "Input Grades - Press 3", "Exit - 0"};

       public static readonly List<string> GradingOptions = new()
     {"Seatworks - Press 1", "Quizzes - Press 2", "Recitations - Press 3", "Performance Tasks - 4", "Midterms - 5", "Finals - 6", "Add Optional Toggles - 7", "Back - 0"};

        public static readonly List<string> AddToggles = new()
        {"Attendance - 1", "Attitude - 2"};

        //MENU METHODS

        public static void ViewMenu() // view menu
        {
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }

        }

        public static void ViewGradingOptions() // View Grading Options
        {
            foreach (var option in GradingOptions)
            {
                Console.WriteLine(option);
            }
        }

        public static void ViewToggles()
        {
            foreach (var toggle in AddToggles)
            {
                Console.WriteLine(toggle);
            }
        }

        public static void SpecialStudentGradeGUI()
        {
            
            ViewGradingOptions();
            int gradeselectmenu = ViewGradingSelect();

            while (gradeselectmenu != 0)
            {
                switch (gradeselectmenu)
                {
                    case 1:
                        Console.WriteLine("Seatworks");
                        NumberofItemsChecker();
                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();

                        break;
                    case 2:
                        Console.WriteLine("Quizzes");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 3:
                        Console.WriteLine("Recitations");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 4:
                        Console.WriteLine("Performance Tasks");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 5:
                        Console.WriteLine("Midterms");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 6:
                        Console.WriteLine("Finals");

                        Console.WriteLine("");
                        ViewGradingOptions();
                        gradeselectmenu = ViewGradingSelect();
                        break;
                    case 7:
                        Console.WriteLine("Optional Toggles");
                        ViewToggles();
                        Console.WriteLine("");

                        ViewGradingOptions();

                        Console.WriteLine("");
                        gradeselectmenu = ViewGradingSelect();
                        break;

                    default:
                        gradeselectmenu = 0;
                        break;
                }
            }

        }

        //Grading System GUI
        public static void ConstantItemScore(int x) //If the Written Works share the same number of items
        {



            try
            {
                int Constantitems;
                int score;
                double sum = 0.0;
                Console.Write("What is your constant score?: ");
                Constantitems = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= x; i++)
                {
                    Console.Write("{0}. Written Work Score: ", i);
                    score = Convert.ToInt32(Console.ReadLine());
                    sum += score;

                    if (score > Constantitems)
                    {
                        Console.WriteLine("Score cannot be higher than item limit. Returning to Main Menu");
                        return;
                    }

                }

                double itemall = Constantitems * x;

                double grade = SeatworkFormulas.QuizSeatworkGradeCompute(sum, itemall);

                Console.WriteLine("Your Grade is: {0}", grade);

                AddSeatworkGrade(grade);

                //
                //Grades.Add(grade);
            }
            catch
            {
                Console.WriteLine("An Invalid Input was Detected");
            }


        }

        public static void DynamicItemScore(int x) //If the Written Works have different number of items
        {

            try
            {
                int Dynamicitems = 0;
                int score;
                double sum = 0.0;
                double scoresum = 0.0;

                for (int i = 1; i <= x; i++)
                {
                    Console.Write("{0}. Written Work Score: ", i);
                    score = Convert.ToInt32(Console.ReadLine());


                    Console.Write("{0}. Score Over: ", i);
                    Dynamicitems = Convert.ToInt32(Console.ReadLine());
                    sum += score;
                    scoresum += Dynamicitems;

                    if (score > Dynamicitems)
                    {
                        Console.WriteLine("Score cannot be higher than constant item. Returning to Main Menu");
                        return;
                    }
                }


                double grade = SeatworkFormulas.QuizSeatworkGradeCompute(sum, scoresum);

                Console.WriteLine("Your Grade is: {0}", grade);

                AddSeatworkGrade(grade);
            }
            catch
            {
                Console.WriteLine("An invalid input was detected");
            }


        }
        public static bool DynamicOrStatic()
        {
            Console.Write("Do all your works share the same item limit?: ");
            string yesorno = Console.ReadLine();
            string yesnolower = yesorno.ToLower();

            bool result;
            if (yesnolower == "yes")
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;

        }
        public static void NumberofItemsChecker()
        {
            int numberofworks;
            Console.Write("Enter how many works you need: ");
            numberofworks = Convert.ToInt32(Console.ReadLine());

            if (DynamicOrStatic() == true)
            {
                ConstantItemScore(numberofworks);
            }
            else
            {
                DynamicItemScore(numberofworks);
            }
        } //CALL THIS METHOD

        public static void AddSeatworkGrade(double x)
        {
            Console.WriteLine("Which student do you need to add this Seatwork Grade to?");
            StudentInfoMethods.GetStudentInfo();

            Console.Write("Enter the name of the student: ");
            string name = Console.ReadLine().ToUpper();

            foreach (var student in StudentInfoMethods.studentlist)
            {
                if (student.Studentname.Contains(name))
                {
                    student.SeatworkGrade = x; break;
                }


            }


        }

        //MENU FUNCTIONS
        public static void CreateStudent()
        {
            string studname;
            string section;


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



                studentnameupper = studname.ToUpper();
                sectionupper = section.ToUpper();

                Student student = new(studentnameupper, sectionupper);
                StudentInfoMethods.studentlist.Add(student);

                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine("An Invalid Input was detected, returning to main menu");
                StudentInfoMethods.studentlist.RemoveAt(StudentInfoMethods.studentlist.Count - 1);

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
        public static int ViewMenuSelect()
        {
            try
            {
                Console.Write("Select your action: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            catch
            {
                Console.WriteLine("Invalid input detected. Terminating program");
                return 0;
            }



        }

        public static int ToggleSelect()
        {
            try
            {
                Console.Write("Select your action: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            catch
            {
                return 0;
            }



        }//TBA later

       

    }
}   

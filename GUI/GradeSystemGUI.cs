using BusinessLayer;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class GradeSystemGUI
    {
        public static readonly List<string> GradingOptions = new()
     {"Seatworks - Press 1", "Quizzes - Press 2", "Recitations - Press 3", "Performance Tasks - 4", "Midterms - 5", "Finals - 6", "Back - 0"};

        public static void SpecialStudentGradeGUI(string studentName)
        {
            ViewGradingOptions();

            int gradeselectmenu;
            while ((gradeselectmenu = UserInterfaces.ViewGradingSelect()) != 0)
            {
                switch (gradeselectmenu)
                {
                    case 1:
                        HandleSeatworks(studentName, gradeselectmenu);
                        break;
                    case 2:
                        HandleQuizzes(studentName, gradeselectmenu);
                        break;
                    case 3:
                        HandleRecitations();
                        break;
                    case 4:
                        HandlePerformanceTasks();
                        break;
                    case 5:
                        HandleMidterms();
                        break;
                    case 6:
                        HandleFinals();
                        break;
                    default:
                        gradeselectmenu = 0;
                        break;
                }

                ViewGradingOptions();
                Console.WriteLine();
            }
        }

        private static void HandleSeatworks(string studentName, int select)
        {
            Console.WriteLine("Seatworks");
            int itemnos = NumberofItemsChecker();
            double score = DynamicOrStatic() ? ConstantItemScore(itemnos) : DynamicItemScore(itemnos);
            AddGrade(score, studentName, select);
            Console.WriteLine("");
        }

        private static void HandleQuizzes(string studentName, int select)
        {
            Console.WriteLine("Quizzes");
            int itemnos = NumberofItemsChecker();
            double score = DynamicOrStatic() ? ConstantItemScore(itemnos) : DynamicItemScore(itemnos);
            AddGrade(score, studentName, select);
            Console.WriteLine("");
        }

        private static void HandleRecitations()
        {
            Console.WriteLine("Recitations");
            Console.WriteLine();
        }

        private static void HandlePerformanceTasks()
        {
            Console.WriteLine("Performance Tasks");
            Console.WriteLine();
        }

        private static void HandleMidterms()
        {
            Console.WriteLine("Midterms");
            Console.WriteLine();
        }

        private static void HandleFinals()
        {
            Console.WriteLine("Finals");
            Console.WriteLine();
        }


        public static void ViewGradingOptions() // View Grading Options
        {
            foreach (var option in GradingOptions)
            {
                Console.WriteLine(option);
            }
        }

       

        //Grading System GUI
        public static double ConstantItemScore(int x) //If the Written Works share the same number of items
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
                        throw new ArgumentException("Score cannot be higher than the number of items!");
                        
                    }

                }

                double itemall = Constantitems * x;

                double grade = GradeFormulas.GradeCompute(sum, itemall);

                Console.WriteLine("Your Grade is: {0}", grade);


                return (double)grade;
                //
                //Grades.Add(grade);
            }
            catch
            {
                Console.WriteLine("An Invalid Input was Detected");
                return -1;
            }


        }
        public static double DynamicItemScore(int x) //If the Written Works have different number of items
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
                        throw new ArgumentException("Score cannot be higher than the number of items!");
                    }
                }


                double grade = GradeFormulas.GradeCompute(sum, scoresum);

                Console.WriteLine("Your Grade is: {0}", grade);

                return (double)grade;
            }
            catch
            {
                Console.WriteLine("An invalid input was detected");
                return -1;
            }


        }
        public static bool DynamicOrStatic()
        {
            Console.Write("Do all your works share the same item limit?: ");
            string yesorno = Console.ReadLine()?.Trim().ToLower();

            bool result = (yesorno == "yes");

            return result;

        }
        public static int NumberofItemsChecker()
        {
            Console.Write("Enter how many works you need: ");
            int numberofworks = Convert.ToInt32(Console.ReadLine());

            return numberofworks;
        } 

        public static void AddGrade(double grade, string studentName, int select)
        {
            foreach (Grade grades in GradeMemory.Gradelist)
            {
                if (grades.Studentname.Contains(studentName))
                {

                   

                    switch (select)
                    {
                        case 1:
                            grades.Seatworkgrade = grade;
                            Console.WriteLine("Grade added to " +studentName);
                            break;
                        case 2:
                            grades.Quizgrade = grade;
                            Console.WriteLine("Quiz grade added to " + studentName);
                            break;
                        case 3:
                            grades.Quizgrade = grade;
                            Console.WriteLine("Quiz grade added to " + studentName);
                            break;
                        // Add more cases for other categories as needed
                        default:
                            Console.WriteLine("Invalid category selection. Grade not added.");
                            break;
                    }
                }
            }
        }

       

        public static double ExamGrade()
        {
            try
            {
                int Items;
                int Score;
                Console.Write("How many items were the exam?: ");
                Items = Convert.ToInt32(Console.ReadLine());

                Console.Write("How many items were achieved?: ");
                Score = Convert.ToInt32(Console.ReadLine());
                   
                    if (Score > Items)
                    {
                    throw new ArgumentException("Score cannot be higher than the number of items!");

                }

                

                

                double grade = GradeFormulas.GradeCompute(Score, Items);

                Console.WriteLine("Your Grade is: {0}", grade);

                return (double)grade;

                //
                //Grades.Add(grade);
            }
            catch
            {
                Console.WriteLine("An Invalid Input was Detected");
                return -1;
            }


        }



    }
}

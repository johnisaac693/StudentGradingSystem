using BusinessLayer;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GUI
{

    
    public class GradeSystemGUI{

       
        GradesDataService gradedb = new GradesDataService();
        public static readonly List<string> GradingOptions = new()
     {"Seatworks - Press 1", "Quizzes - Press 2", "Recitations - Press 3", "Attendance - 4", "Exams - 5", "Project - 6", "Midterm - 7","Final - 8", "Total Grade - 9", "Back - 0"};

        public void SpecialStudentGradeGUI(string studentName)
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
                        HandleRecitations(studentName, gradeselectmenu);
                        break;
                    case 4:
                         HandleAttendance(studentName, gradeselectmenu);
                        break;
                    case 5:
                         HandleExams(studentName, gradeselectmenu);
                        break;
                    case 6: 
                        HandleProject(studentName, gradeselectmenu);
                        break;
    
                    case 7:
                        HandleMidterms(studentName, gradeselectmenu);
                        break;
                    case 8:
                       HandleFinals(studentName, gradeselectmenu);
                        break;
                    default:
                        gradeselectmenu = 0;
                        break;
                }

                ViewGradingOptions();
                Console.WriteLine();
            }
        }

        private void HandleSeatworks(string studentName, int select)
        {
            Console.WriteLine("Seatworks");
            int itemnos = NumberofItemsChecker();
            double score = DynamicOrStatic() ? ConstantItemScore(itemnos) : DynamicItemScore(itemnos);
            AddGrade(score, studentName, select);
            Console.WriteLine("");
        }

        private void HandleQuizzes(string studentName, int select)
        {
            Console.WriteLine("Quizzes");
            int itemnos = NumberofItemsChecker();
            double score = DynamicOrStatic() ? ConstantItemScore(itemnos) : DynamicItemScore(itemnos);
            AddGrade(score, studentName, select);
            Console.WriteLine("");
        }

        private void HandleRecitations(string studentName, int select)
        {
            Console.WriteLine("Recitations");
            double score = RecitationCompute();
            AddGrade(score, studentName, select);

            Console.WriteLine();
        }

        private void HandlePerformanceTasks()
        {
            Console.WriteLine("Performance Tasks");
            Console.WriteLine();
        }

        private void HandleFinals(string studentName, int select)
        {
            Console.WriteLine("Finals");
            Console.WriteLine("Tabulating Final Grade");
            TabulateGrade(studentName, select);
            Console.WriteLine();
        }
        private void HandleMidterms(string studentName, int Select)
        {
            Console.WriteLine("Tabulating Midterm Grade");
            TabulateGrade(studentName, Select);


        }
        private void HandleExams(string studentName, int select)
        {
            Console.WriteLine("Exams");
            double score = ExamGrade();
            AddGrade(score, studentName, select);
        }

        private void HandleProject(string studentName, int select) 
        {
            Console.WriteLine("Project");
            double score = ProjectCompute();
            AddGrade(score, studentName, select);

            Console.WriteLine();
        }

        private void HandleAttendance(string studentName, int select)
        {
            Console.WriteLine("Attendance");
            double daystotal = NoOfDays();
            double daysattended = DaysAttended();
            double score = GradeFormulas.AttendanceCompute(daysattended, daystotal);
            AddGrade(score, studentName, select);
           Console.WriteLine();
        }

        private void HandleTotalGrade(string studentName, int select)
        {
            Console.WriteLine("Total Grade");



            Console.WriteLine();
        }

       


        public void ViewGradingOptions() // View Grading Options
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
               
            }
            catch
            {
                Console.WriteLine("An Invalid Input was Detected");
                return -1;
            }


        }

        public static double RecitationCompute()
        {
            double reciGrade;
            Console.Write("What is the student's recitation grade? (out of 100)?: ");
            reciGrade = Convert.ToDouble(Console.ReadLine());
            return (double)reciGrade;
        }

        public static double ProjectCompute()
        {
            double projectGrade;
            Console.Write("What is the student's projet grade? (out of 100)?: ");
            projectGrade = Convert.ToDouble(Console.ReadLine());
            return (double)projectGrade;
        }

        public static double NoOfDays()
        {
            Console.Write("How many days were in the term?: ");
            double days = Convert.ToInt32(Console.ReadLine());

            return days;
        }

        public static double DaysAttended()
        {

            Console.Write("How many days did this student attend?: ");
            double daysattend = Convert.ToInt32(Console.ReadLine());
            return daysattend;
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



        public void AddGrade(double grade, string studentName, int select)
        {
                Grade gradedata = gradedb.GetGradesByName(studentName);

                if (gradedata != null)
                {
                    switch (select)
                    {
                        case 1:
                            gradedata.Seatworkgrade = grade;
                           gradedb.InsertSeatWorkGrade(gradedata);
                            break;

                            case 2:
                            gradedata.Quizgrade = grade;
                            gradedb.InsertQuizGrade(gradedata);
                            break;

                            case 3:
                            gradedata.Recitgrade = grade;
                            gradedb.InsertRecitationGrade(gradedata);
                            break;

                            case 4:
                            gradedata.Attendancegrade = grade;
                            gradedb.InsertAttendanceGrade(gradedata);
                            Console.WriteLine("Your Attendance Grade is: " + gradedata.Attendancegrade);
                            break;

                            case 5:
                            gradedata.Examgrade = grade;
                            gradedb.InsertExamGrade(gradedata);
                            Console.WriteLine("Your Exam Grade is: " + gradedata.Examgrade);
                            break;

                            case 6:
                            gradedata.Projectgrade = grade;
                            gradedb.InsertProjectGrade(gradedata);
                            break;

                        default:
                            
                            break;

                    }
                }
        }
        
        public void TabulateGrade(string studentName, int select)
        {

            {
                Grade gradedata = gradedb.GetGradesByName(studentName);

                if (gradedata != null)
                {
                    switch (select)
                    {
                        case 7:
                            gradedata.Midtermgrade = GradeFormulas.TabulateGrade(gradedata.Seatworkgrade, gradedata.Quizgrade, gradedata.Recitgrade, gradedata.Attendancegrade, gradedata.Projectgrade, gradedata.Examgrade);
                            gradedb.InsertMidtermGrade(gradedata);
                            Console.WriteLine("The Midterm Grade Is: " +gradedata.Midtermgrade);
                            break;

                        case 8:
                            gradedata.Finalgrade = GradeFormulas.TabulateGrade(gradedata.Seatworkgrade, gradedata.Quizgrade, gradedata.Recitgrade, gradedata.Attendancegrade, gradedata.Projectgrade, gradedata.Examgrade);
                            gradedb.InsertFinalGrade(gradedata);
                            Console.WriteLine("The Final Grade Is: " + gradedata.Finalgrade);
                            break;


                        default:
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

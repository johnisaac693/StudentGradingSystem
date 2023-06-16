using DataLayer;

namespace BusinessLayer
{
    public class SeatworkFormulas
    {

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
                        StudentInfoMethods.studentlist.RemoveAt(StudentInfoMethods.studentlist.Count - 1);
                        return;
                    }

                }

                double itemall = Constantitems * x;
                double grade = (sum / itemall) * 100;

                Console.WriteLine($"Your grade is {grade}");
                Console.WriteLine("");

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
                        StudentInfoMethods.studentlist.RemoveAt(StudentInfoMethods.studentlist.Count - 1);
                        return;
                    }
                }




                double grade = (sum / scoresum) * 100;
                //Console.WriteLine($"Your grade is {grade}");
                //Grades.Add(grade);

                Console.WriteLine($"Your grade is {grade}");
                Console.WriteLine("");

                AddSeatworkGrade(grade);
            }
            catch
            {
                Console.WriteLine("An invalid input was detected");
            }


        }

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
    }

    public class SeatworkCheck
    {
        public static int NumberofItemsChecker ()
        {
            int Numberofworks;
            Console.Write("Enter how many works you need: ");
            Numberofworks = Convert.ToInt32(Console.ReadLine());

            return Numberofworks;

        }

        public static void DynamicOrStatic()//CALL THIS METHOD
        {
     
            Console.Write("Do your Seatworks share the same number of items?: Yes or No?");
            string choicemaker = Console.ReadLine().ToLower();

            if (choicemaker == "yes")
            {
               
                int seatworkamounts = NumberofItemsChecker();
                SeatworkFormulas.ConstantItemScore(seatworkamounts);
                
            }
            else 
            {
                
                int seatworkamounts = NumberofItemsChecker();
                SeatworkFormulas.ConstantItemScore(seatworkamounts);
            }
        }


    }
}
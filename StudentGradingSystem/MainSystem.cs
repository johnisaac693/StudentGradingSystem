using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using DataLayer;
using GUI;


public class MainSystem

{
    

   
    static void Main()
    {
        UserInterfaces UI = new UserInterfaces();
        StudentGUI studui = new StudentGUI();
        GradesDataService gradedb = new GradesDataService();
        if (ProfessorInfo.FacultyCheck())
        {
            UI.MainMenu();
        }
        else 
        {
            string nameexist = studui.Login();

            if (UI.IsStudentExisting(nameexist))
            {
                var gradingdata = gradedb.GetGradesByName(nameexist);

                Console.WriteLine("Student Name: " + gradingdata.Studentname);
                Console.WriteLine("Midterm Grade: " + gradingdata.Midtermgrade);
                Console.WriteLine("Final Grade: " + gradingdata.Finalgrade);
                Console.WriteLine("Total Grade: " + gradingdata.Totalgrade);

                Console.WriteLine(" ");


            }
            else
            {
                Console.WriteLine("Student Does Not Exist!");
            }

        }
    }

   
    

   

   

   
}

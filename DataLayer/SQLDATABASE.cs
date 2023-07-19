using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DataLayer
{
    public class SQLDATABASE
    {

        static string ConnectString = "Data Source=LAPTOP-D3L5LPUQ\\SQLEXPRESS01; Initial Catalog = GradingSystem; Integrated Security = True;";
        

        static SqlConnection sqlconnection;

        public SQLDATABASE()
        {
            sqlconnection = new SqlConnection(ConnectString);
        }

        public static void Connect()
        {
            sqlconnection.Open();
        }

        public void CreateGradeData(Grade gradedata)
        {
            sqlconnection.Open();
            var insertStatement = "INSERT INTO Grade (Name, SeatWork, Quiz, Recitation, Attendance, Project, Exam, Midterm, Final, TotalGrade) VALUES (@Name, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0); ";

            SqlCommand insertcommand = new SqlCommand(insertStatement, sqlconnection);
            insertcommand.Parameters.AddWithValue("@Name", gradedata.Studentname);
            

            insertcommand.ExecuteNonQuery();

            sqlconnection.Close();


            

        }

        //SeatWork insert in DB
        public void InsertSeatWorkGrade(Grade SW)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET SeatWork = @SeatWork WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@SeatWork", SW.Seatworkgrade);
            updateCommand.Parameters.AddWithValue("@Name", SW.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }


        public List<Grade> GetGrades()
        {

            var selectStatement = "SELECT * FROM Grade";
            SqlCommand selectcommand = new SqlCommand(selectStatement, sqlconnection);
            sqlconnection.Open();

            SqlDataReader reader = selectcommand.ExecuteReader();

            var Grades = new List<Grade>();

            while (reader.Read())
            {
                Grades.Add(new Grade()
                {
                    Studentname = reader["Name"].ToString(),
                    Seatworkgrade = Convert.ToDouble(reader["SeatWork"].ToString()),
                    Quizgrade = Convert.ToDouble(reader["Quiz"].ToString()),
                    Recitgrade = Convert.ToDouble(reader["Recitation"].ToString()),
                    Attendancegrade = Convert.ToDouble(reader["Attendance"].ToString()),
                    Projectgrade = Convert.ToDouble(reader["Project"].ToString()),
                    Examgrade = Convert.ToDouble(reader["Exam"].ToString()),
                    Midtermgrade = Convert.ToDouble(reader["Midterm"].ToString()),
                    Finalgrade = Convert.ToDouble(reader["Final"].ToString()),
                    Totalgrade = Convert.ToDouble(reader["TotalGrade"].ToString()),

                });
            }
            sqlconnection.Close(); return Grades;
        }

        public List<Grade> GetNames()
        {

            var selectStatement = "SELECT * FROM Grade";
            SqlCommand selectcommand = new SqlCommand(selectStatement, sqlconnection);
            sqlconnection.Open();

            SqlDataReader reader = selectcommand.ExecuteReader();

            var Names = new List<Grade>();

            while (reader.Read())
            {
                Names.Add(new Grade()
                {
                    Studentname = reader["Name"].ToString(),

                    

                });
            }
            sqlconnection.Close(); return Names;
        }

         public Grade GetGradeByName(string name)
        {
            var selectStatement = "SELECT * FROM Grade WHERE Name = @Name";
            SqlCommand selectcommand = new SqlCommand(selectStatement, sqlconnection);
            selectcommand.Parameters.AddWithValue("@Name", name);
            sqlconnection.Open();

            SqlDataReader reader = selectcommand.ExecuteReader();

            Grade grade = null;

            while (reader.Read())
            {
                grade = new Grade() 
                {
                    Studentname = reader["Name"].ToString(),
                    Seatworkgrade = Convert.ToDouble(reader["SeatWork"].ToString()),
                    Quizgrade = Convert.ToDouble(reader["Quiz"].ToString()),
                    Recitgrade = Convert.ToDouble(reader["Recitation"].ToString()),
                    Attendancegrade = Convert.ToDouble(reader["Attendance"].ToString()),
                    Projectgrade = Convert.ToDouble(reader["Project"].ToString()),
                    Examgrade = Convert.ToDouble(reader["Exam"].ToString()),
                    Midtermgrade = Convert.ToDouble(reader["Midterm"].ToString()),
                    Finalgrade = Convert.ToDouble(reader["Final"].ToString()),
                    Totalgrade = Convert.ToDouble(reader["TotalGrade"].ToString()),

                };
            }
            sqlconnection.Close(); 
            return grade;
        }


    }
}



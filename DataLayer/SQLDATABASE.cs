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

        //static string ConnectString = "Data Source=localhost; Initial Catalog = GradingSystem; Integrated Security = True;";
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

        public void CreateGradeData(Grade gradedata)//Create Grade Data
        {
            sqlconnection.Open();
            var insertStatement = "INSERT INTO Grade (Name, SeatWork, Quiz, Recitation, Attendance, Project, Exam, Midterm, Final, TotalGrade) VALUES (@Name, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0); ";

            SqlCommand insertcommand = new SqlCommand(insertStatement, sqlconnection);
            insertcommand.Parameters.AddWithValue("@Name", gradedata.Studentname);
            

            insertcommand.ExecuteNonQuery();

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

        public void InsertQuizGrade(Grade QUIZ)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Quiz = @Quiz WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Quiz", QUIZ.Quizgrade);
            updateCommand.Parameters.AddWithValue("@Name", QUIZ.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }
        public void InsertRecitationGrade(Grade RECI)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Recitation = @Recitation WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Recitation", RECI.Recitgrade);
            updateCommand.Parameters.AddWithValue("@Name", RECI.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }

        public void InsertProjectGrade(Grade PROJECT)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Project = @Project WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Project", PROJECT.Projectgrade);
            updateCommand.Parameters.AddWithValue("@Name", PROJECT.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }

        public void InsertAttendanceGrade(Grade ATTENDANCE)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Attendance = @Attendance WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Attendance", ATTENDANCE.Attendancegrade);
            updateCommand.Parameters.AddWithValue("@Name", ATTENDANCE.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }

        public void InsertExamGrade(Grade EXAM)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Exam = @Exam WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Exam", EXAM.Examgrade);
            updateCommand.Parameters.AddWithValue("@Name", EXAM.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }

        public void InsertMidtermGrade(Grade MIDTERM)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Midterm = @Midterm WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Midterm", MIDTERM.Midtermgrade);
            updateCommand.Parameters.AddWithValue("@Name", MIDTERM.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }

        public void InsertFinalGrade(Grade FINAL)
        {
            sqlconnection.Open();
            var updateStatement = "UPDATE GRADE SET Final = @Final WHERE Name = @Name";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlconnection);

            updateCommand.Parameters.AddWithValue("@Final", FINAL.Finalgrade);
            updateCommand.Parameters.AddWithValue("@Name", FINAL.Studentname);

            updateCommand.ExecuteNonQuery();

            sqlconnection.Close();
        }






    }
}



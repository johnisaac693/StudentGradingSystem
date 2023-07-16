using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DataLayer
{
    public class SQLDATABASE
    {

        
        static string ConnectString = "Data Source=localhost; Initial Catalog = GradingSystem; Integrated Security = True;";

        SqlConnection connect = new SqlConnection(ConnectString);

        static SqlConnection connection;

        public SQLDATABASE()
        {
            connection = new SqlConnection(ConnectString);
        }


        public void CreateGradeData(Grade gradeData)
        {
            var insertStatement = "INSERT INTO GRADE (Name) VALUES (@Name)";

            using (SqlConnection connection = new SqlConnection(ConnectString))
            {
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Name", gradeData.Studentname);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
            }
        }


        public double UpdateSeatworkGrade(Grade gradedata)
        {
            double success;
            var updateStatement = "UPDATE Grade SET Grade = @SeatWork WHERE Name = @Name";

            SqlCommand insertcommand = new SqlCommand(updateStatement, connection);
            insertcommand.Parameters.AddWithValue("@SeatWork", gradedata.Seatworkgrade);
            connection.Open();

            success = insertcommand.ExecuteNonQuery();

            connection.Close();

            return success;
            
        }



        public List<Grade> GetGrades() 
        {
            var selectStatement = "SELECT * FROM GRADE";
            SqlCommand selectcommand = new SqlCommand(selectStatement, connection);
            connection.Open();

            SqlDataReader reader = selectcommand.ExecuteReader();

            var grades = new List<Grade>();

            while (reader.Read()) 
            {
              grades.Add(new Grade
                  {
                    Studentname = reader["Name"].ToString(),
                    Seatworkgrade = Convert.ToDouble(reader["Seatworkgrade"].ToString()),
                    Quizgrade = Convert.ToDouble(reader["Quizgrade"].ToString()),
                    Recitgrade = Convert.ToDouble(reader["Recitgrade"].ToString()),
                    Attendancegrade = Convert.ToDouble(reader["Attendancegrade"].ToString()),
                    Projectgrade = Convert.ToDouble(reader["Projectgrade"].ToString()),
                    Totalgrade = Convert.ToDouble(reader["Totalgrade"].ToString()),
                    Examgrade = Convert.ToDouble(reader["Examgrade"].ToString()),
                    Midtermgrade = Convert.ToDouble(reader["Midtermgrade"].ToString()),
                    Finalgrade = Convert.ToDouble(reader["Finalgrade"].ToString()),
              });
            }
            connection.Close();
            return grades;

        }
    }
}

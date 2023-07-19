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

        static string ConnectString = "Data Source=localhost; Initial Catalog = GradingSystem; Integrated Security = True;";
        

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
            var insertStatement = "INSERT INTO GRADE (Name) VALUES (@Name)";

            SqlCommand insertcommand = new SqlCommand(insertStatement, sqlconnection);
            insertcommand.Parameters.AddWithValue("@Name", gradedata.Studentname);
            

            insertcommand.ExecuteNonQuery();

            sqlconnection.Close();


            

        }

        //SeatWork insert in DB
        public void InsertSeatWorkGrade(Grade SW)
        {
            sqlconnection.Open();
            var insertStatement = "INSERT INTO GRADE (SeatWork) VALUES (@SeatWork)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlconnection);

            insertCommand.Parameters.AddWithValue("@SeatWork", SW.Seatworkgrade);
            
            insertCommand.ExecuteNonQuery();
            
            sqlconnection.Close();
        }


        //public List<Grade> GetGrades() {

        //    var selectStatement = "SELECT * FROM Grade";
        //    SqlCommand selectcommand = new SqlCommand(selectStatement, sqlconnection);
        //    sqlconnection.Open();

        //    SqlDataReader reader = selectcommand.ExecuteReader();

        //    var Grades = new List<Grade>();

        //    while (reader.Read())
        //    {
        //        Grades.Add(new Grade()
        //        {
        //        Studentname = 
                
                
        //        });
        //    }

        //}
       
    }
}



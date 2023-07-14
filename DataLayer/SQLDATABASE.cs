using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public class SQLDATABASE
    {
        string Connectionsstring;
        static string ConnectString = "Data Source =MSI; Initial Catalog = GradingSystem; Integrated Security = True;";
        // SqlConnection connect = new SqlConnection(ConnectString);

        static SqlConnection connection;
       
    }
}

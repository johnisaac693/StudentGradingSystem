using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer
{
    public class GradeConnectDB
    {
        SQLDATABASE detabes = new SQLDATABASE();

        

        public void CreateGrade(Grade gradedata)
        {
            detabes.CreateGradeData(gradedata);
        }
    }
}

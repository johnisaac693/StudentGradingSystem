using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataLayer
{
    public class GradesDataService
    {
        
        
        SQLDATABASE detabes = new SQLDATABASE();

        

        public void CreateGrade(Grade gradedata)
        {
            detabes.CreateGradeData(gradedata);
        }

        public List <Grade> getGrades () 
        {
            return detabes.GetGrades();
        }

        public List<Grade> GetNames()
        {
            return detabes.GetNames();

        }

        public void InsertSeatWorkGrade(Grade SW)
        {
            detabes.InsertSeatWorkGrade(SW);
        }

        public Grade GetGradesByName(string Name)
        {
            return detabes.GetGradeByName(Name);
        }

    }
}

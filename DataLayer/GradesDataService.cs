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
        private List<Grade> Grades { get; set; }
        
        SQLDATABASE detabes = new SQLDATABASE();

        

        public void CreateGrade(Grade gradedata)
        {
            detabes.CreateGradeData(gradedata);
        }

        public List <Grade> getGrades () 
        {
            return Grades;
        }
    }
}

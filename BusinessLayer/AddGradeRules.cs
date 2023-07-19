using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AddGradeRules
    {
        GradesDataService dataService = new GradesDataService();

        public void InsertSeatworkGrade(double grade, string name)
        { 
        Grade gradedata = dataService.GetGradesByName(name);

        if (gradedata != null) {
            
                gradedata.Seatworkgrade = grade;
                dataService.InsertSeatWorkGrade(gradedata);

            
            }
        }



    }
}

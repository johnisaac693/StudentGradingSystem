using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class StudentGUI
    {
        public string Login()
        {
            Console.Write("Enter your name: ");
            string studname = Console.ReadLine()?.Trim().ToUpper();


            return studname;

        }


    }
}

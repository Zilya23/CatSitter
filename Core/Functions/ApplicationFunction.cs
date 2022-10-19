using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class ApplicationFunction
    {
        public static List<Applictioon> GetApplications()
        {
            List<Applictioon> applications = bd_connection.connection.Applictioon.Where(x => x.Active == true).ToList();
            return applications;
        }

        public static void SaveRespond(User_Application user_Application)
        {
            bd_connection.connection.User_Application.Add(user_Application);
            bd_connection.connection.SaveChanges();
        }

        public static bool UniqApplicationUser(int IDUser, int IDApplication)
        {
            var uniq = bd_connection.connection.User_Application.FirstOrDefault(x=> x.IDUser == IDUser && x.IDApplication == IDApplication);
            if(uniq == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

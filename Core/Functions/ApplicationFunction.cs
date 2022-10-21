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

        public static List<User_Application> GetUserRespond(int idUser)
        {
            List<User_Application> userApplications = bd_connection.connection.User_Application.Where(x => x.IDUser == idUser).ToList();
            return userApplications;
        }

        public static List<Applictioon> GetApplictioonsUser(int idUser)
        {
            List<Applictioon> applictioons = bd_connection.connection.Applictioon.Where(x => x.IDUser == idUser).ToList();
            return applictioons;
        }

        public static bool IsYou(User user, Applictioon applictioon)
        {
            return applictioon.User == user;
        }

        public static void AddApplication(Applictioon applictioon)
        {
            bd_connection.connection.Applictioon.Add(applictioon);
            bd_connection.connection.SaveChanges();
        }
    }
}

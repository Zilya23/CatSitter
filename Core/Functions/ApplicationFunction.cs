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
            List<Applictioon> applications = bd_connection.connection.Applictioon.Where(x => x.Active == true && x.IsDelete != true).ToList();
            return applications;
        }

        public static List<User_Application> GetRespond(int IDApplication)
        {
            return bd_connection.connection.User_Application.Where(x => x.IDApplication == IDApplication && x.UserRespond == true).ToList();
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
            List<User_Application> userApplications = bd_connection.connection.User_Application.Where(x => x.IDUser == idUser && x.Applictioon.IsDelete != true).ToList();
            return userApplications;
        }

        public static List<Applictioon> GetApplictioonsUser(int idUser)
        {
            List<Applictioon> applictioons = bd_connection.connection.Applictioon.Where(x => x.IDUser == idUser && x.IsDelete != true).ToList();
            return applictioons;
        }

        public static bool IsYou(User user, Applictioon applictioon)
        {
            return applictioon.User == user;
        }

        public static void AddApplication(Applictioon applictioon)
        {
            bd_connection.connection.Applictioon.Add(applictioon);
        }

        public static void DeleteApplication(Applictioon applictioon)
        {
            applictioon.IsDelete = true;
            bd_connection.connection.SaveChanges();
        }

        public static void ApplicationRespondTrue(User_Application application)
        {
            application.ApplicationRespond = true;
            bd_connection.connection.SaveChanges();
        }
        public static void ApplicationRespondFalse(User_Application application)
        {
            application.ApplicationRespond = false;
            bd_connection.connection.SaveChanges();
        }
        public static void UserApplicationFalse(User_Application application)
        {
            application.UserRespond = false;
            bd_connection.connection.SaveChanges();
        }
        public static void UserApplicationTrue(User_Application application)
        {
            application.UserRespond = true;
            bd_connection.connection.SaveChanges();
        }

        public static void ApplicationTrue(User_Application application)
        {
            if (application.UserRespond == true && application.ApplicationRespond == true)
            {
                application.Applictioon.Active = true;
                bd_connection.connection.SaveChanges();
            }
        }

        public static bool QwnerTrue(Applictioon applictioon)
        {
            var lists = bd_connection.connection.User_Application.Where(x => x.Applictioon.ID == applictioon.ID && x.UserRespond == true).ToList();
            if(lists.Count != 0)
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

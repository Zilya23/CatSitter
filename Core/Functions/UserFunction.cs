using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class UserFunction
    {
        public static void SaveCatsitterInfo()
        {
            bd_connection.connection.SaveChanges();
        }

        public static bool CatsitterUser(User user)
        {
            if(user.CaringExperience != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Registration(User user)
        {
            bd_connection.connection.User.Add(user);
            bd_connection.connection.SaveChanges();
        }
    }
}

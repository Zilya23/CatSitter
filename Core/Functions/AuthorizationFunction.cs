using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class AuthorizationFunction
    {
        public static User Authorization(string login, string password)
        {
            User user = bd_connection.connection.User.Where(x => x.Password == password && x.Login == login).FirstOrDefault();
            return user;
        }
    }
}

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
    }
}

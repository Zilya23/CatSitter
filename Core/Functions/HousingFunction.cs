using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class HousingFunction
    {
        public static List<Housing> GetHousings()
        {
            return bd_connection.connection.Housing.ToList();
        }
    }
}

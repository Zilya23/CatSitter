using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class CityFunction
    {
        public static List<City> GetCities()
        {
            return bd_connection.connection.City.ToList();
        }
    }
}

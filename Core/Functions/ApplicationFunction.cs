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
    }
}

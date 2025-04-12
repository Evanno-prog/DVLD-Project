using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DVLD_DataAccessLayer
{
    static class clsDataAccessSettings
    {
        //public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=sa123456;";
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Const
{
    public static class Const
    {
        //filepath to.\RestaurantApp\src\RestaurantApp\bin\Debug\net6.0 
        public static readonly string appDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string auditTxtPath = System.AppDomain.CurrentDomain.BaseDirectory + "/audit.txt";

        public static readonly string defaultConnString = System.Configuration.ConfigurationManager
                .ConnectionStrings["DefaultConnectionString"].ConnectionString;

    }
}

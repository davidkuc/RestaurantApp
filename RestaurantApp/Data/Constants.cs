namespace RestaurantApp.Data
{
    public static class Constants
    {
        //filepath to.\RestaurantApp\src\RestaurantApp\bin\Debug\net6.0 
        public static readonly string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string auditTxtPath = AppDomain.CurrentDomain.BaseDirectory + "/audit.txt";

        public static readonly string defaultConnString = System.Configuration.ConfigurationManager
                .ConnectionStrings["DefaultConnectionString"].ConnectionString;

    }
}

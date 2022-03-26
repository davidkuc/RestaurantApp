using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApp.Data;

namespace RestaurantAppTests
{
    public class RestaurantAppTestsInitalization
    {

        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {

            tc.WriteLine($"AssemblyInitialize() : nothing to say for now");
            

        }

        [AssemblyCleanup()]
        public static void AssemblyCleanUp()
        {


        }
    }
}

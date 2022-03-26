using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApp.Data;

namespace RestaurantAppTests
{
    public class RestaurantAppTestsInitalization
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine($"AssemblyInitialize()");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanUp()
        {

        }
    }
}

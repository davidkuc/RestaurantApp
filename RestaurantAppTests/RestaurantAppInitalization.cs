using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppTests
{
    public class RestaurantAppInitalization
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

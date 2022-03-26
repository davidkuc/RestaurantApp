using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppTests
{
    public abstract class TestBase
    {
        protected DbContext dbContext;

        public TestContext TestContext { get; set; }

        public void WriteTestDescription(Type type)
        {
            var testname = TestContext.TestName;

            var method = type.GetMethod(testname);
            if (method != null)
            {
                var attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    var dattr = (DescriptionAttribute)attr;
                    TestContext.WriteLine($"Test description: {dattr.Description}");
                }
            }
        }
    }
}

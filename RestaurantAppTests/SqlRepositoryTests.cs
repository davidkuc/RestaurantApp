using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestaurantApp.Data;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantAppTests
{
    [TestClass]
    public class SqlRepositoryTests : TestBase
    {

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {

            tc.WriteLine(" ClassInitialize() : nothing to say for now");
        }


        [ClassCleanup()]
        public static void ClassCleanUp()
        {


        }

        [TestInitialize()]
        public void TestInitialize()
        {
            dbContext = new RestaurantAppTestsDbContext();
            TestContext.WriteLine(" TestInitialize() : nothing to say for now");
            WriteTestDescription(GetType());

        }


        [TestCleanup()]
        public void TestCleanUp()
        {
            TestContext.WriteLine(" TestCleanUp() : : nothing to say for now");

        }


        [TestMethod]
        [Description("Checking if GetById() returns proper item from repository")]
        [TestCategory("WithoutException")]
        public void GetByIdReturnsProperItems()
        {
            var expectedEmpList = new List<Employee>();
            var employeeRepo = new SqlRepository<Employee>(dbContext);
            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1 });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Id = 2 });
            expectedEmpList.Add(new Employee { FirstName = "Charlie", LastName = "C", Id = 3 });
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B" });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Charlie", LastName = "C" });
            employeeRepo.Save();

            for (int i = 1; i < expectedEmpList.Count; i++)
            {
                var actualEmployee = employeeRepo.GetById(i);
                Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[i - 1]), JsonConvert.SerializeObject(actualEmployee));

            }
        }


        [TestMethod]
        [Description("Checking if Add() adds proper items to repository")]
        [TestCategory("WithoutException")]
        public void AddAddsProperItemToDb()
        {
            var expectedEmpList = new List<Employee>();
            var employeeRepo = new SqlRepository<Employee>(dbContext);
            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1 });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Id = 2 });
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B" });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A" });
            employeeRepo.Save();

            for (int i = 1; i < expectedEmpList.Count; i++)
            {
                var actualEmployee = employeeRepo.GetById(i);
                Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[i - 1]), JsonConvert.SerializeObject(actualEmployee));

            }
        }

        [TestMethod]
        [Description("Checking if Remove() removes proper items from repository")]
        [TestCategory("WithoutException")]
        public void RemoveRemovesProperItemsFromDb()
        {
            var expectedEmpList = new List<Employee>();
            var employeeRepo = new SqlRepository<Employee>(dbContext);
            var employeeCount = 0;
            expectedEmpList.Add(null);
            expectedEmpList.Add(new Employee { FirstName = "Francis", LastName = "A", Id = 2 });
            expectedEmpList.Add(new Employee { FirstName = "Meg", LastName = "A", Id = 3 });
            expectedEmpList.Add(new Employee { FirstName = "Dick", LastName = "A", Id = 4 });
            expectedEmpList.Add(null);
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Francis", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Meg", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Dick", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Kurt", LastName = "A" });

            employeeRepo.Remove(employeeRepo.GetById(1));
            employeeRepo.Remove(employeeRepo.GetById(5));
            employeeRepo.Save();

            for (int i = 1; i < expectedEmpList.Count; i++)
            {
                var actualEmployee = employeeRepo.GetById(i);
                if (actualEmployee != null)
                {
                    employeeCount++;
                    Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[i - 1]), JsonConvert.SerializeObject(actualEmployee));
                }
                else
                {
                    Assert.IsTrue(actualEmployee == null);
                }
            }
        }
    }
}
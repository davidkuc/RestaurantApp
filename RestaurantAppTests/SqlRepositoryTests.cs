using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestaurantApp.Data;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Data.Entities.Enums;

namespace RestaurantAppTests
{
    [TestClass]
    public class SqlRepositoryTests : TestBase
    {
        private List<Employee> expectedEmpList;
        private SqlRepository<Employee> employeeRepo;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("ClassInitialize()");
        }

        [ClassCleanup()]
        public static void ClassCleanUp()
        {
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            dbContext = new RestaurantAppTestsDbContext();
            expectedEmpList = new List<Employee>();
            employeeRepo = new SqlRepository<Employee>(dbContext);
            TestContext.WriteLine("TestInitialize()");
            WriteTestDescription(GetType());
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            TestContext.WriteLine("TestCleanUp()");
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
            
        }

        [TestMethod]
        [Description("Checking if GetById() returns proper item from repository")]
        [TestCategory("WithoutException")]
        public void GetById_ReturnsProperItems()
        {

            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1, Role = EmployeeRole.Employee.ToString() });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Id = 2, Role = EmployeeRole.Employee.ToString() });
            expectedEmpList.Add(new Employee { FirstName = "Charlie", LastName = "C", Id = 3, Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Charlie", LastName = "C", Role = EmployeeRole.Employee.ToString() });
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
        public void Add_AddsProperItemToDb()
        {

            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Role = EmployeeRole.Employee.ToString(), Id = 1 });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Role = EmployeeRole.Employee.ToString(), Id = 2 });
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A", Role = EmployeeRole.Employee.ToString() });
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
        public void Remove_RemovesProperItemsFromDb()
        {

            var employeeCount = 0;
            expectedEmpList.Add(null);
            expectedEmpList.Add(new Employee { FirstName = "Francis", LastName = "A", Id = 2, Role = EmployeeRole.Employee.ToString() });
            expectedEmpList.Add(new Employee { FirstName = "Meg", LastName = "A", Id = 3, Role = EmployeeRole.Employee.ToString() });
            expectedEmpList.Add(new Employee { FirstName = "Dick", LastName = "A", Id = 4, Role = EmployeeRole.Employee.ToString() });
            expectedEmpList.Add(null);
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Francis", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Meg", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Dick", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Add(new Employee { FirstName = "Kurt", LastName = "A", Role = EmployeeRole.Employee.ToString() });

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

        [TestMethod]
        [Description("Checking if Update() updates entity data")]
        [TestCategory("WithoutException")]
        public void Update_UpdatesEntityData()
        {
            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "A", Role = EmployeeRole.Employee.ToString() });
            employeeRepo.Save();
            var expectedEmployee = new Employee { FirstName = "Bart", LastName = "B", Id = 1, Role = EmployeeRole.Employee.ToString() };
            var employeeToUpdate = employeeRepo.GetById(1);

            employeeToUpdate.FirstName = "Bart";
            employeeToUpdate.LastName = "B";
            employeeRepo.Update(employeeToUpdate);

            Assert.AreEqual(JsonConvert.SerializeObject(expectedEmployee), JsonConvert.SerializeObject(employeeRepo.GetById(1)));
        }
    }
}
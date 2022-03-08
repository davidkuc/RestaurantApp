using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestaurantApp.Data;
using System;
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
            TestContext.WriteLine(" TestInitialize() : nothing to say for now");
            WriteTestDescription(this.GetType());

        }


        [TestCleanup()]
        public void TestCleanUp()
        {
            TestContext.WriteLine(" TestCleanUp() : : nothing to say for now");

        }
 

        [TestMethod]
        [Owner("David")]
        [Description("Checking if GetById() returns proper item from repository")]
        [TestCategory("WithoutException")]
        public void GetByIdReturnsProperItems()
        {

            var expectedEmpList = new List<Employee>();

            var employeeRepo = new SqlRepository<Employee>(new RestaurantAppDbContext());

            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1 });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Id = 2 });
            expectedEmpList.Add(new Employee { FirstName = "Charlie", LastName = "C", Id = 3 });


            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B" });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A" });
            employeeRepo.Add(new Employee { FirstName = "Charlie", LastName = "C"});
            employeeRepo.Save();

           
            for (int i = 1; i < expectedEmpList.Count; i++)
            {
                var actualEmployee = employeeRepo.GetById(i);
                Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[i-1]), JsonConvert.SerializeObject(actualEmployee));

            }

        }


        [TestMethod]
        [Owner("David")]
        [Description("Checking if Add() adds proper items to repository")]
        [TestCategory("WithoutException")]
        public void AddAddsProperItemToDb()
        {

            var expectedEmpList = new List<Employee>();

            var employeeRepo = new SqlRepository<Employee>(new RestaurantAppDbContext());

            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1 });
            expectedEmpList.Add(new Employee { FirstName = "Bart", LastName = "A", Id = 2 });

            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B" });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A" });
            employeeRepo.Save();



            var actualEmpList = (List<Employee>)employeeRepo.GetAll();


            for (int i = 0; i < expectedEmpList.Count; i++)
            {
                Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[i]), JsonConvert.SerializeObject(actualEmpList[i]));

            }

        }

        [TestMethod]
        [Owner("David")]
        [Description("Checking if Remove() removes proper items from repository")]
        [TestCategory("WithoutException")]
        public void RemoveRemovesProperItemsFromDb()
        {

            var expectedEmpList = new List<Employee>();
            var employeeRepo = new SqlRepository<Employee>(new RestaurantAppDbContext());

            expectedEmpList.Add(new Employee { FirstName = "Adam", LastName = "B", Id = 1 });

            employeeRepo.Add(new Employee { FirstName = "Adam", LastName = "B" });
            employeeRepo.Add(new Employee { FirstName = "Bart", LastName = "A" });
            employeeRepo.Remove(employeeRepo.GetById(2));
            employeeRepo.Save();


            var actualEmpList = (List<Employee>)employeeRepo.GetAll();



            Assert.AreEqual(expectedEmpList.Count(), actualEmpList.Count());
            Assert.AreEqual(JsonConvert.SerializeObject(expectedEmpList[0]), JsonConvert.SerializeObject(actualEmpList[0]));
        }



    }
}
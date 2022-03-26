using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppTests
{
    [TestClass]
    public class SupplierRepositoryTests : TestBase
    {
        private List<Supply> expectedSupplyList;
        private List<Supplier> expectedSupplierList;
        private SupplierRepository supplierRepo;
        private SqlRepository<Supply> supplyRepo;

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
            expectedSupplierList = new List<Supplier>();
            expectedSupplyList = new List<Supply>();
            supplierRepo = new SupplierRepository(dbContext);
            supplyRepo = new SqlRepository<Supply>(dbContext);
            Seed();
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
        [Description("Checking if GetAll() assigns supplies to each supplier from supplies table")]
        public void GetAllTest_IncludeSupplies()
        {
            try
            {
                Assert.IsNotNull(supplierRepo.GetById(1).Supplies);
                Assert.IsNotNull(supplierRepo.GetById(2).Supplies);

                for (int i = 4; i <= expectedSupplyList.Count; i++)
                {
                    Assert.AreEqual(JsonConvert.SerializeObject(supplierRepo.GetById(1).Supplies.ElementAt(i - 3)), expectedSupplyList[i - 4]);
                    Assert.AreEqual(JsonConvert.SerializeObject(supplierRepo.GetById(2).Supplies.ElementAt(i)), expectedSupplyList[i - 1]);
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine(ex.Message);
            }
        }

        private void Seed()
        {
            supplierRepo.Add(new Supplier { Name = "Marco", SupplyCategory = "Food" });
            supplierRepo.Add(new Supplier { Name = "Polo", SupplyCategory = "Food" });
            supplyRepo.Add(new Supply { Name = "Rice", Category = "Food", SupplierID = 1 });
            supplyRepo.Add(new Supply { Name = "Bread", Category = "Food", SupplierID = 1 });
            supplyRepo.Add(new Supply { Name = "Garlic", Category = "Food", SupplierID = 1 });
            supplyRepo.Add(new Supply { Name = "Kimchi", Category = "Food", SupplierID = 2 });
            supplyRepo.Add(new Supply { Name = "Wasabi", Category = "Food", SupplierID = 2 });
            supplyRepo.Add(new Supply { Name = "Corn", Category = "Food", SupplierID = 2 });

            expectedSupplyList.Add(new Supply { Name = "Rice", Category = "Food", SupplierID = 1 });
            expectedSupplyList.Add(new Supply { Name = "Bread", Category = "Food", SupplierID = 1 });
            expectedSupplyList.Add(new Supply { Name = "Garlic", Category = "Food", SupplierID = 1 });
            expectedSupplyList.Add(new Supply { Name = "Kimchi", Category = "Food", SupplierID = 2 });
            expectedSupplyList.Add(new Supply { Name = "Wasabi", Category = "Food", SupplierID = 2 });
            expectedSupplyList.Add(new Supply { Name = "Corn", Category = "Food", SupplierID = 2 });
        }
    }
}

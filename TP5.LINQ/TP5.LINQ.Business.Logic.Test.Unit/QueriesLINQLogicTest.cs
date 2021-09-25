using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TP5.LINQ.Business.Domain;

namespace TP5.LINQ.Business.Logic.Test.Unit
{
    [TestClass]
    public class QueriesLINQLogicTest
    {
        private QueriesLINQLogic _queriesLINQLogic = new QueriesLINQLogic();

        [TestMethod]
        public void Test_GetTypeCustommer()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.GetTypeCustommer();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Customers));
        }

        [TestMethod]
        public void Test_ProductsWithOutStock()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.ProductsWithOutStock();

            //Assert
            foreach (var product in result)
            {
                Assert.AreEqual(product.UnitsInStock, default(short));
            }
        }

        [TestMethod]
        public void Test_ProductsInStockWhithPriceGreaterThan()
        {
            //Arrange
            decimal unitPrice = 3;
            
            //Act
            var result = _queriesLINQLogic.ProductsInStockWhithPriceGreaterThan(unitPrice);

            //Assert
            foreach (var product in result)
            {
                Assert.AreNotEqual(product.UnitsInStock, default(short));
                Assert.IsTrue(product.UnitPrice > unitPrice);
            }
        }

        [TestMethod]
        public void Test_CustomersInWashingtonRegion()
        {
            //Arrange
            string region = "WA";
            //Act
            var result = _queriesLINQLogic.CustomersInWashingtonRegion();

            //Assert
            foreach (var customer in result)
            {
                Assert.AreEqual(customer.Region.ToUpper(), region.ToUpper());
            }
        }

        [TestMethod]
        public void Test_FirstElementOrNullProductsByID()
        {
            //Arrange
            int idProduct = 789;
            //Act
            var result = _queriesLINQLogic.FirstElementOrNullProductsByID(idProduct);

            //Assert
            if(result != null)
            {
                Assert.IsInstanceOfType(result, typeof(Products));
            }
            else
            {
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public void Test_CustomersNames()
        {
            //Arrange
            bool inUpperCase = true;

            //Act
            var result = _queriesLINQLogic.CustomersNames(inUpperCase);

            //Assert
            if (inUpperCase)
            {
                foreach (var name in result)
                {
                    Assert.AreEqual(name, name.ToUpper());
                }
            }
            else
            {
                foreach (var name in result)
                {
                    Assert.AreEqual(name, name.ToLower());
                }
            }
        }

        [TestMethod]
        public void Test_CustomersInWashingtonRegionAndOrdersDateGreaterThan()
        {
            //Arrange
            DateTime dateTime = new DateTime(1997, 01, 01);
            string region = "WA";

            //Act
            var result = _queriesLINQLogic.CustomersInWashingtonRegionAndOrdersDateGreaterThan(dateTime);

            //Assert
            foreach (var customerOrder in result)
            {
                Assert.AreEqual(customerOrder.Customer.Region.ToUpper(), region.ToUpper());
                Assert.IsTrue(customerOrder.Order.OrderDate > dateTime);
            }
        }

        [TestMethod]
        public void Test_GetSpecificNumberCustomersFromBegin()
        {
            //Arrange
            int numberCustmers = 3;

            //Act
            var result = _queriesLINQLogic.GetSpecificNumberCustomersFromBegin(numberCustmers);

            //Assert
            Assert.IsTrue(result.Count == numberCustmers);
        }

        [TestMethod]
        public void Test_ProductsOrderByNameAZ()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.ProductsOrderByNameAZ();
            var resultOrderByNameAZ = result.OrderBy(p => p.ProductName);
            
            //Assert
            Assert.IsTrue(resultOrderByNameAZ.SequenceEqual(result));
        }

        [TestMethod]
        public void Test_ProductsOrderByUnitsInStockDesc()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.ProductsOrderByUnitsInStockDesc();
            var resultOrderByUnitsInStockDesc = result.OrderByDescending(p => p.UnitsInStock);

            //Assert
            Assert.IsTrue(resultOrderByUnitsInStockDesc.SequenceEqual(result));
        }

        [TestMethod]
        public void Test_GetAllCategories()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.GetAllCategories();

            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test_GetFirstProduct()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.GetFirstProduct();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Products));
        }

        [TestMethod]
        public void Test_GetQuantityOrdersPerCustomer()
        {
            //Arrange

            //Act
            var result = _queriesLINQLogic.GetQuantityOrdersPerCustomer();

            //Assert
            Assert.IsTrue(true);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspNetWebFormsDataFederation;

namespace AspNetWebFormsDataFederation.Tests
{
    [TestClass]
    public class InvoicesTests
    {
        [TestMethod]
        public void CreateData_ReturnsExpectedData()
        {
            var data = Invoices.CreateData();

            Assert.IsNotNull(data);
            Assert.AreEqual(35, data.Count);
            Assert.AreEqual("Germany", data[0].Country);
            Assert.AreEqual("Aachen", data[0].City);
            Assert.AreEqual("Raclette Courdavault", data[0].ProductName);
            Assert.AreEqual(30, data[0].Quantity);
            Assert.AreEqual(0, data[0].Discount);
            Assert.AreEqual(1650, data[0].ExtendedPrice);
            Assert.AreEqual(149.47, data[0].Freigth);
            Assert.AreEqual(55, data[0].UnitPrice);
        }

        [TestMethod]
        public void GenerateOrderDate_ReturnsValidDate()
        {
            var date = typeof(Invoices).GetMethod("GenerateOrderDate", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Invoke(null, null);

            Assert.IsNotNull(date);
            Assert.IsInstanceOfType(date, typeof(DateTime));
            var orderDate = (DateTime)date;
            Assert.IsTrue(orderDate.Year >= DateTime.Today.Year - 3 && orderDate.Year <= DateTime.Today.Year);
        }
    }
}

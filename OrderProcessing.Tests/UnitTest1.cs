using ASP.NET_Assignment.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OrderProcessing.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CalculateDiscount_LoyalCustomer_Above100()
        {
          
            var order = new Order { OrderAmount = 150, CustomerType = "Loyal" };

            var discount = order.OrderAmount >= 100 && order.CustomerType == "Loyal" ? 0.10m * order.OrderAmount : 0;

           
            Assert.AreEqual(15, discount);
        }
    }

}

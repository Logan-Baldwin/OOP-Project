using System;
using Baldwin_Matchett_Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Baldwin_Matchett_Project
{
    [TestClass]
    public sealed class CartTests
    {
        [TestMethod]
        public void TotalCartTest()
        {
            // Arrange
            Cart c = new Cart();
            Inventory i = new Inventory();
            FileHelper.ReadProducts("inventory.txt", i.inventory);
            c.cart.Add(i.inventory[0]);
            c.cart.Add(i.inventory[1]); 
            decimal expectedTotal = i.inventory[0].Price + i.inventory[1].Price;

            // Act
            decimal total = c.TotalCart();

            // Assert
            Assert.AreEqual(expectedTotal, total, 0, "Amount Incorrect");
        }
    }
}

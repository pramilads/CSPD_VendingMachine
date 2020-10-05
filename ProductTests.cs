using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine_CSPD.Tests
{
    [TestClass()]
    public class ProductTests
    {

        [TestMethod()]
        public void ProductName()
        {
            Product Coke = new Product("Coke",10, 1.25);
            Assert.AreEqual("Coke", Coke.Name);
        }

        [TestMethod()]
        public void ProductPrice()
        {
            Product Coke = new Product("Coke",10, 1.25);
            Assert.AreEqual(1.25, Coke.Price);
        }
    }
}
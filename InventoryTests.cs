using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachine_CSPD.Tests
{
    [TestClass()]
    public class InventoryTests
    {

        [TestMethod()]
        public void InventoryReturnsItsItems()
        {
            Inventory inventory = new Inventory();
            Assert.AreEqual(2, inventory.Items.Length);
        }
    }
}
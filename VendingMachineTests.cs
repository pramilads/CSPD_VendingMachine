using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace VendingMachine_CSPD.Tests
{
    [TestClass()]
    public class VendingMachineTests
    {
        [TestMethod()]
        public void InventoryReturnsItsItems()
        {
            Inventory inventory = new Inventory();
            Assert.AreEqual(4, inventory.Items.Length);
        }

        [TestMethod()]
        public void ItemsArrayHasALengthOfTwo()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Assert.AreEqual(2, vendingMachine.Items.Length);
        }

        [TestMethod()]
        public void DisplayItemsMethodOutputsToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                VendingMachine vendingMachine = new VendingMachine();
                vendingMachine.DisplayItems();
                string message = "Items available are as follows...\n\n Water - Price £0.60p \\Snickers - Price £0.40p\n\n";
                Assert.AreEqual(message, sw.ToString());
            }
        }

        [TestMethod()]
        public void RequestSelectionOutputsCorrectDetailsToConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader("C"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    VendingMachine vendingMachine = new VendingMachine();
                    var selection = vendingMachine.RequestSelection();
                    string message = "Please make your selection...\nPlease enter B for Water.\nPlease enter C for Snickers.\n";
                    Assert.AreEqual(message, sw.ToString());
                }
            }
        }


        [TestMethod()]
        public void RequestSelectionReceivesTheCorrectInputFromConsole()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader("C"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    VendingMachine vendingMachine = new VendingMachine();
                    var selection = vendingMachine.RequestSelection();
                    Assert.AreEqual(selection, 'C');
                }
            }
        }

        [TestMethod()]
        public void CharacterfromConsoleCorrectlyFindsCorrespondingItemOne()
        {
            VendingMachine vendingMachine = new VendingMachine();
            var product = vendingMachine.FindAndReturnProduct('C');
            Assert.AreEqual("Coke", product.Name);
        }

        [TestMethod()]
        public void CharacterfromConsoleCorrectlyFindsCorrespondingItemTwo()
        {
            VendingMachine vendingMachine = new VendingMachine();
            var product = vendingMachine.FindAndReturnProduct('B');
            Assert.AreEqual("Water", product.Name);
        }


        [TestMethod()]
        public void TakePaymentMethodReturnsPaymentProductChangeCrisps()
        {
            using (StringReader sr = new StringReader("2.05"))
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    VendingMachine vendingMachine = new VendingMachine();
                    vendingMachine.MakePayment(1, 0.10, "Snickers");
                    Assert.AreEqual("Please enter a payment of 50p as 0.50\n" +
                                    "Received 1, Outstanding 0\nThank you for your payment " +
                                    "of £0.50\nYour product Snickers has been dispensed\nYour change " +
                                    "of £0.10 has been dispensed also\n", sw.ToString());
                }
            }
        }
    }
}
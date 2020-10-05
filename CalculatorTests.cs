using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VendingMachine_CSPD.Tests
{
    [TestClass()]
    public class CalculatorTests
    {

        [TestMethod()]
        public void CalculatesChangeAndCoinsRequired()
        {
            Calculator calculator = new Calculator();
            double[] returned = calculator.ReturnPaymentAndChange(0.80);
            var returnedFormatted = Convert.ToDecimal(returned[1]);

            Assert.AreEqual(2, returned[0]);
            Assert.AreEqual(0.20, returnedFormatted);
            Assert.AreEqual(2, returned.Length);
        }
        [TestMethod(
            )]
        public void CalculatesChangeAndCoinsRequiredTwo()
        {

            Calculator calculator = new Calculator();
            double[] returned = calculator.ReturnPaymentAndChange(0.10);

            Assert.AreEqual(1, returned[0]);
            Assert.AreEqual(0.40, returned[1]);
            Assert.AreEqual(2, returned.Length);
        }

        [TestMethod()]
        public void CalculatesChangeAndCoinsRequiredThree()
        {
            Calculator calculator = new Calculator();
            double[] returned = calculator.ReturnPaymentAndChange(0.50);

            Assert.AreEqual(1, returned[0]);
            Assert.AreEqual(0, returned[1]);
            Assert.AreEqual(2, returned.Length);
        }
    }
}
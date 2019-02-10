using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using vendingMachine;

namespace vendingMachineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 正しく読み取れる100円Version()
        {
            var managedMoney = new ManagedMoney();
            managedMoney.PutMoney(Coin.Create(100));
            Assert.AreEqual(100, managedMoney.Total);            
        }

        [TestMethod]
        public void 正しく読み取れない30円Version()
        {
            var managedMoney = new ManagedMoney();
            Assert.ThrowsException<ArgumentException>(() => { managedMoney.PutMoney(Coin.Create(30)); }); // fail

        }
    }
}

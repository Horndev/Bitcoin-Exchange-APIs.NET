using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitExAPI.Markets;
using BitExAPI.Markets.Kraken;
using System.Threading;

namespace BitExAPI.Tests
{
    [TestClass]
    public class KrakenTests
    {
        [TestMethod]
        public void TestCreateConnection()
        {
            IMarketConnection connection;

            connection = new KrakenConnection();
            connection.StartBackgroundThread();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Assert.IsTrue(connection.IsRunning);
            Assert.IsTrue(connection.TradeCount > 0);

            connection.StopBackgroundThread();
            Assert.IsFalse(connection.IsRunning);
        }

        public void TestRequestTicker()
        {
            Assert.Inconclusive();
        }
    }
}

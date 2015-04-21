using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitExAPI.Markets;
using BitExAPI.Markets.Kraken;
using System.Threading;
using BitExAPI.Markets.Data;

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

        [TestMethod]
        public void TestRequestTrades()
        {
            var connection = new KrakenConnection();
            Trades t = connection.RequestTrades();
            Assert.IsTrue(t.TradePoints.Count > 0);
        }

        public void TestRequestTicker()
        {
            Assert.Inconclusive();
        }
    }
}

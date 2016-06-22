using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitExAPI.Markets;
using BitExAPI.Markets.Kraken;
using System.Threading;
using BitExAPI.Markets.Data;

namespace BitExAPI.Tests
{
    [TestClass]
    public class TestKrakenConnection
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
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.IsFalse(connection.IsRunning);
        }

        [TestMethod]
        public void TestRequestTrades()
        {
            var connection = new KrakenConnection();
            Trades t = connection.RequestTrades();

            //By default will return last 1000 trades
            Assert.IsTrue(t.TradePoints.Count > 0);
        }

        [TestMethod]
        public void TestKrakenTradeCount()
        {
            var connection = new KrakenConnection();
            Trades t = connection.RequestTrades();

            Assert.IsTrue(connection.TradeCount > 0);
        }

        [TestMethod]
        public void TestRequestTicker()
        {
            var connection = new KrakenConnection();
            Ticker t = connection.RequestTicker();

            Assert.IsTrue(t.TradeCount > 0);
        }

        [TestMethod]
        public void TestRequestTime()
        {
            var connection = new KrakenConnection();
            DateTime t = connection.RequestTime();

            Console.WriteLine(t.ToLongDateString());
        }

        [TestMethod]
        public void TestGetAssets()
        {
            var connection = new KrakenConnection();
            var r = connection.GetAssets();

            Console.WriteLine(r.ToString());
        }
    }
}

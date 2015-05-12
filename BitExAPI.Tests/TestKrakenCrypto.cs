using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using BitExAPI.Crypto;
using BitExAPI.Markets.Kraken;

namespace TraderCrypto.Tests
{
    [TestClass]
    public class TestSign
    {
        [TestMethod]
        public void TestHMAC()
        {
            //Assert.Inconclusive();
            string key = File.ReadAllText(@"L:\ReadOnlyPu.txt");
            string secret = File.ReadAllText(@"L:\ReadOnlyPr.txt");

            KrakenCrypto connection = new KrakenCrypto(key, secret);

            string paramstring = "txid=OZXYB4_WKZD4_OHN3MV&trades=false".Replace("_","-");
            string path = "/0/private/QueryOrders";
            string nonce = KrakenCrypto.GetNonce();

            string signature = KrakenCrypto.Sign_POST_HMAC512A(path, nonce, paramstring);

            string url = "https://api.kraken.com";
            string address = url + path;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(address);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.Headers.Add("API-Key", key);
            webRequest.Headers.Add("API-Sign", signature);

            string props = "nonce=" + nonce + "&" + paramstring;

            using (var writer = new StreamWriter(webRequest.GetRequestStream()))
            {
                writer.Write(props);
            }

            string response;

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (Stream str = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(str))
                    {
                        response = sr.ReadToEnd();
                    }
                }
            }

            Console.WriteLine(response);
        }

        [TestMethod]
        public void TestKrakenSecureConnection()
        {
            var connection = new KrakenConnection();
            string APIKey = File.ReadAllText(@"L:\ReadOnlyPu.txt");
            string PrvKey = File.ReadAllText(@"L:\ReadOnlyPr.txt");
            connection.SetAPIKey(APIKey);
            connection.SetPrivateKey(PrvKey);

        }
    }
}

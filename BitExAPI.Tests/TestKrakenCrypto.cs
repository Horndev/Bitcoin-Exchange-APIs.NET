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
            string key = File.ReadAllText(@"L:\Pu.txt");
            string secret = File.ReadAllText(@"L:\Pr.txt");

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
            string APIKey = File.ReadAllText(@"L:\Pu.txt");
            string PrvKey = File.ReadAllText(@"L:\Pr.txt");
            connection.SetAPIKey(APIKey);
            connection.SetPrivateKey(PrvKey);

        }

        [TestMethod]
        public void TestEncryptionAES()
        {
            var c = new Crypto();
            string userKey = "4b236698-ebbb-4d3d-9513-961c5603d431";
            string cypher = c.Encrypt("hello", userKey, "0000000001");
            Console.WriteLine(cypher);
        }
    }

    /* MATLAB code for signed requests
     * function [ res, extra ] = HTTPPOST( connection, url, path, par )
%HTTPPOST Summary of this function goes here
%   Detailed explanation goes here

nonce = char(connection.crypto.GetNonce());

if ~isempty(par)
    params = [par(:)'];
    [paramString, header] = http_paramsToString(params,1);
else
    paramString = '';
end

sign = char(connection.crypto.Sign_POST_HMAC512A(path, nonce, paramString));

if ~isempty(par)
    params = ['nonce' nonce par(:)'];
    [paramString,header] = http_paramsToString(params,1);
else
    params = {'nonce' nonce};
    [paramString,header] = http_paramsToString(params,1);
end

header2 = http_createHeader('API-Key', connection.key);
header3 = http_createHeader('API-Sign', sign);
headerua = http_createHeader('User-Agent','Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36');

[res extra] = urlread2(strcat(url,path), 'POST', paramString,...
    [headerua header header2 header3 ]);

end


    */
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace BitExAPI.Crypto
{
    /// <summary>
    /// 
    /// </summary>
    public class KrakenCrypto
    {
        public static string _apiKey;
        public static string _apiSecret;

        public KrakenCrypto(string key, string secret)
        {
            _apiKey = key.Replace("-", "");
            _apiSecret = secret;
        }

        public static class Private
        {
            public static string createId(string nonce)
            {
                string _id = GetMd5Hash(nonce);
                return _id;
            }
        }
        public static byte[] PackH(string hex)
        {
            if ((hex.Length % 2) == 1) hex += '0';
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static string Sign_POST_HMAC512A(string path, string snonce, string postString)
        {
            var secret = Convert.FromBase64String(_apiSecret);

            Int64 nonceInt = Convert.ToInt64(snonce);

            string post = postString == "" ? "nonce=" + nonceInt : "nonce=" + nonceInt + "&" + postString;

            var np = nonceInt + Convert.ToChar(0) + post;
            var pathBytes = Encoding.UTF8.GetBytes(path);
            var hash256Bytes = sha256_hash(np);

            var z = new byte[pathBytes.Count() + hash256Bytes.Count()];
            pathBytes.CopyTo(z, 0);
            hash256Bytes.CopyTo(z, pathBytes.Count());

            var signature = getHash(secret, z);

            string sign = Convert.ToBase64String(signature);

            return sign;
        }

        public static string[] Sign_POST_HMAC512B(string path, string postString)
        {
            string nonce = KrakenCrypto.GetNonce();
            return new string[] 
            {
                Sign_POST_HMAC512A(path, nonce, postString), 
                nonce
            };
        }

        private static byte[] getHash(byte[] keyByte, byte[] messageBytes)
        {
            using (var hmacsha512 = new HMACSHA512(keyByte))
            {
                Byte[] result = hmacsha512.ComputeHash(messageBytes);
                return result;
            }
        }

        private static byte[] sha256_hash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                return result;
            }
        }    
            //$path = '/' . $this->version . '/private/' . $method;
            //$sign = hash_hmac('sha512', $path . hash('sha256', $request['nonce'] . $postdata, true), base64_decode($this->secret), true);
        public static string Sign_WS_APIv1(string querytext_JSON, string apiKey, string apiSecretBase64String)
        {
            byte[] secret = Convert.FromBase64String(apiSecretBase64String);
            var hmacsha512 = new HMACSHA512(secret);
            byte[] bytes_queryJSON = Encoding.UTF8.GetBytes(querytext_JSON);
            hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(querytext_JSON));
            byte[] bytes_signature = hmacsha512.Hash;
            string signature = Convert.ToBase64String(bytes_signature);

            string APIKey = apiKey.Replace("-", "");
            byte[] bytes_APIKey = PackH(APIKey);
            string packstr = Convert.ToBase64String(bytes_APIKey.ToArray());

            List<byte> queryList = new List<byte>();
            queryList.AddRange(bytes_APIKey);
            queryList.AddRange(bytes_signature);
            queryList.AddRange(bytes_queryJSON);
            byte[] bytes_query = queryList.ToArray();

            return Convert.ToBase64String(bytes_query);
        }
        public static string Sign_POST_APIv2(string endpoint, string nonce, string apiSecretBase64String, string postString)
        {
            string prefix = endpoint;
            string post = postString == "" ? "nonce=" + nonce : postString;
            string sign = getHash(Convert.FromBase64String(apiSecretBase64String),
                prefix + Convert.ToChar(0) + post);
            return sign;
        }


        private static string getHash(byte[] keyByte, String message)
        {
            var hmacsha512 = new HMACSHA512(keyByte);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            return Convert.ToBase64String(hmacsha512.ComputeHash(messageBytes));
        }

        public static string GetNonce()
        {
            return GetNonce_v2();
        }

        public static string GetNonce_v2()
        {
            Int64 nonce = DateTime.Now.Ticks;
            return Convert.ToString(nonce);
        }
        public static string GetNonce_WS()
        {
            var t = (DateTime.Now - new DateTime(1970, 1, 1, 1, 1, 0)).TotalMilliseconds;
            string nonce = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("0.000").Replace(".", "");
            return nonce;
        }
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}

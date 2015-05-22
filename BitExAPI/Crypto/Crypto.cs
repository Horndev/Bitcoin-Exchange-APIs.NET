using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Crypto
{
    /// <summary>
    /// Manage the encryption and decryption of user information.
    /// uses AES-256
    /// </summary>
    public class Crypto
    {
        // Used for AES encryption/decryption.  see http://blogs.msdn.com/b/shawnfa/archive/2006/10/09/the-differences-between-rijndael-and-aes.aspx for AES interoperability info.
        RijndaelManaged SymmetricKey = new RijndaelManaged();

        public string Encrypt(string text, string key)
        {
            return "";
        }

        public string Decrypt(string cyphertext, string userKey)
        {
            // When a user logs in, the key will be the hash of the user's password + salt

            // 	Key Size (bits)	Block Size (bits)
            // AES-128	128	128
            // AES-192	192	128
            // AES-256	256	128
            // --- This code needs to be moved - should be passed via userKey to ensure sensitive credentials not transmitted. 
            byte[] salt = Encoding.ASCII.GetBytes("SALT STRING");
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(userKey, salt);
            SymmetricKey.Key = key.GetBytes(SymmetricKey.KeySize / 8);
            SymmetricKey.IV = key.GetBytes(SymmetricKey.BlockSize / 8);
            // ---

            //PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(
            //                                       LoginUser.Password,
            //                                       salt,
            //                                       "SHA1",
            //                                       4);
            byte[] KeyBytes = SymmetricKey.Key;
            byte[] IV = SymmetricKey.IV;

            SymmetricKey.Mode = CipherMode.CBC;
            byte[] CipherTextBytes = null;


            /// DEBUG - encrypt some text
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes("Hello");
            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, IV))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                        CryptoStream.FlushFinalBlock();
                        CipherTextBytes = MemStream.ToArray();
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();



            ///  --- Decryption
            string tokenKey = Convert.ToBase64String(KeyBytes);
            string tokenIV = Convert.ToBase64String(IV);
            //Save our generated keys for this session
            //Session["TokenKey"] = tokenKey;
            //Session["TokenInit"] = tokenIV;
            
            string cipherValue = Convert.ToBase64String(CipherTextBytes);

            int z = 1; //debug
            return "";
        }
    }
}

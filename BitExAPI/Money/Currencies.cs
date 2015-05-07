
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI
{
    public static class Money
    {
        /// <summary>
        /// Currencies supported by API.  There should be a standard translation between the platform and each market/exchange.
        /// </summary>
        public static Dictionary<string, BitExAPI.Currency> Currencies = new Dictionary<string, BitExAPI.Currency>()
        {
            {"BTC", new BitExAPI.Currency() 
                { 
                    ThreeLetter = "BTC", 
                    FullName = "Bitcoin", 
                    precision = 10
                }
            },

            {"EUR", new BitExAPI.Currency() 
                {
                    ThreeLetter = "EUR", 
                    FullName = "Euro", 
                    precision = 4
                }
            },
            {"USD", new BitExAPI.Currency() 
                {
                    ThreeLetter = "USD", 
                    FullName = "United States Dollars", 
                    precision = 4
                }
            }
        };
    }
}

namespace BitExAPI
{
    public class Currency
    {
        public string ThreeLetter;
        public string FullName;
        public uint precision;  //Number of decimal points to keep
    }
}

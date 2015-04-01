using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Money
{
    public static class Money
    {
        /// <summary>
        /// Currencies supported by API.  There should be a standard translation between the platform and each market/exchange.
        /// </summary>
        public static Dictionary<string, Currency> Currencies = new Dictionary<string, Currency>()
        {
            {"BTC", new Currency() 
                { 
                    ThreeLetter = "BTC", 
                    FullName = "Bitcoin", 
                    precision = 10
                }
            },

            {"EUR", new Currency() 
                {
                    ThreeLetter = "EUR", 
                    FullName = "Euro", 
                    precision = 4
                }
            },
            {"USD", new Currency() 
                {
                    ThreeLetter = "USD", 
                    FullName = "United States Dollars", 
                    precision = 4
                }
            }
        };
    }

    public class Currency
    {
        public string ThreeLetter;
        public string FullName;
        public uint precision;  //Number of decimal points to keep
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Money
{
    public static class Money
    {
        public static Dictionary<string, Currency> Currencies = new Dictionary<string, Currency>()
        {
            {"BTC", new Currency() { ThreeLetter = "BTC", FullName = "Bitcoin"}},
            {"EUR", new Currency() { ThreeLetter = "EUR", FullName = "Euro"}}
        };
    }

    public class Currency
    {
        public string ThreeLetter;
        public string FullName;
    }
}

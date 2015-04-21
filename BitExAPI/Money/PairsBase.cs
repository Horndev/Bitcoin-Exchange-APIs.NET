using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Money
{
    public abstract class PairsBase
    {
        public abstract string FormatPair(Currency bid, Currency asked);
        public abstract string FormatPair(string bid, string asked);
    }
}

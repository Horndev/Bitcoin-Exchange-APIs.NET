using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI
{
    public abstract class PairsBase
    {
        private Currency _bid;
        private Currency _asked;

        public PairsBase(Currency bid, Currency asked)
        {
            _bid = bid;
            _asked = asked;
        }

        public abstract string FormatPair(Currency bid, Currency asked);
        public abstract string FormatPair(string bid, string asked);
    }
}

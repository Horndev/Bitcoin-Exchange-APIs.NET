using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI
{
    public abstract class PairsBase
    {
        protected Currency _bid;
        protected Currency _asked;

        public PairsBase(Currency bid, Currency asked)
        {
            _bid = bid;
            _asked = asked;
        }

        public Currency Bid
        {
            get { return _bid; }
        }

        public Currency Ask
        {
            get { return _asked; }
        }
    }
}

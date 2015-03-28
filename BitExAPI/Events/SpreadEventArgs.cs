using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Events
{
    public class SpreadEventArgs : MarketEventArgs
    {
        public Spread Data;
        public Int64 LastTimeUTC_epoch;
    }
}

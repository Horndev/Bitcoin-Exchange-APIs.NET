using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Events
{
    public class TradesEventArgs
    {
        public BitExAPI.Markets.Kraken.TradesResponse data;
        public string APIName;
    }
}

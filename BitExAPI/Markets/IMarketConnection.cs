using BitExAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    //public delegate void TradesUpdatedEvent(TradesResponse trades, string APIName);

    public interface IMarketConnection
    {
        event EventHandler<TradesEventArgs> OnTradesUpdated;
        
        void Start();
    }
}

using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    public interface IMessagingConnection
    {
        /// <summary>
        /// Transmit a string message
        /// </summary>
        /// <param name="msg"></param>
        void Echo(string msg);

        void TxTrade(TradePoint t);

        void TxSpread(SpreadPoint s);
    }
}

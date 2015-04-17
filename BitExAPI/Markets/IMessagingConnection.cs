using BitExAPI.Markets.Data;
using BitExAPI.Utility;
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
        void E(string msg);

        /// <summary>
        /// TxTrade 
        /// NOTE: method name is shortened to reduce transmission memory/bandwidth
        /// </summary>
        /// <param name="t"></param>
        void T(TradePoint t);

        /// <summary>
        /// TxSpread
        /// </summary>
        /// <param name="s"></param>
        void S(SpreadPoint s);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        void OHLC(OHLCPoint o);
    }
}

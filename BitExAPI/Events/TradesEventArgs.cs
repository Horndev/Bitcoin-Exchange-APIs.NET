using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Events
{
    public class TradesEventArgs
    {
        public Trades data;
        public string APIName;
        public Int64  LastTimeUTC_Epoch_e9;    //Epoch seconds multiplied by 10^9

        public DateTime LastTimeUTC
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(LastTimeUTC_Epoch_e9 / 1000000000.0);
            }
        }
    }
}

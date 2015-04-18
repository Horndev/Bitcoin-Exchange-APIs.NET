using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// https://api.kraken.com/0/public/Assets
    /// </summary>
    public class AssetsResponse : Response
    {


        public override Data.MarketData ToMarketData()
        {
            throw new NotImplementedException();
        }
    }
}
//{"error":[],"result":{"KFEE":{"aclass":"currency","altname":"FEE","decimals":2,"display_decimals":2},"XLTC":{"aclass":"currency","altname":"LTC","decimals":10,"display_decimals":5},"XNMC":{"aclass":"currency","altname":"NMC","decimals":10,"display_decimals":5},"XSTR":{"aclass":"currency","altname":"STR","decimals":8,"display_decimals":5},"XXBT":{"aclass":"currency","altname":"XBT","decimals":10,"display_decimals":5},"XXDG":{"aclass":"currency","altname":"XDG","decimals":8,"display_decimals":2},"XXRP":{"aclass":"currency","altname":"XRP","decimals":8,"display_decimals":5},"XXVN":{"aclass":"currency","altname":"XVN","decimals":4,"display_decimals":2},"ZEUR":{"aclass":"currency","altname":"EUR","decimals":4,"display_decimals":2},"ZGBP":{"aclass":"currency","altname":"GBP","decimals":4,"display_decimals":2},"ZJPY":{"aclass":"currency","altname":"JPY","decimals":2,"display_decimals":0},"ZKRW":{"aclass":"currency","altname":"KRW","decimals":2,"display_decimals":0},"ZUSD":{"aclass":"currency","altname":"USD","decimals":4,"display_decimals":2}}}
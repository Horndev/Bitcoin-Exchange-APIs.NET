using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    /// <summary>
    /// https://api.kraken.com/0/private/TradeBalance
    /// </summary>
    public class RequestTradeBalance
    {
    }
}
/*Input:

aclass = asset class (optional):
    currency (default)
asset = base asset used to determine balance (default = ZUSD)
Result: array of trade balance info

eb = equivalent balance (combined balance of all currencies)
tb = trade balance (combined balance of all equity currencies)
m = margin amount of open positions
n = unrealized net profit/loss of open positions
c = cost basis of open positions
v = current floating valuation of open positions
e = equity = trade balance + unrealized net profit/loss
mf = free margin = equity - initial margin (maximum margin available to open new positions)
ml = margin level = (equity / initial margin) * 100
*/
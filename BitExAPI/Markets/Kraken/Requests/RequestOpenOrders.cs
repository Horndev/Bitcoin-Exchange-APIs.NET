using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class RequestOpenOrders
    {
    }
}
/*
Get open orders
URL: https://api.kraken.com/0/private/OpenOrders

Input:

trades = whether or not to include trades in output (optional.  default = false)
userref = restrict results to given user reference id (optional)
Result: array of order info in open array with txid as the key

refid = Referral order transaction id that created this order
userref = user reference id
status = status of order:
    pending = order pending book entry
    open = open order
    closed = closed order
    canceled = order canceled
    expired = order expired
opentm = unix timestamp of when order was placed
starttm = unix timestamp of order start time (or 0 if not set)
expiretm = unix timestamp of order end time (or 0 if not set)
descr = order description info
    pair = asset pair
    type = type of order (buy/sell)
    ordertype = order type (See Add standard order)
    price = primary price
    price2 = secondary price
    leverage = amount of leverage
    position = position tx id to close (if order is positional)
    order = order description
    close = conditional close order description (if conditional close set)
vol = volume of order (base currency unless viqc set in oflags)
vol_exec = volume executed (base currency unless viqc set in oflags)
cost = total cost (quote currency unless unless viqc set in oflags)
fee = total fee (quote currency)
price = average price (quote currency unless viqc set in oflags)
stopprice = stop price (quote currency, for trailing stops)
limitprice = triggered limit price (quote currency, when limit based order type triggered)
misc = comma delimited list of miscellaneous info
    stopped = triggered by stop price
    touched = triggered by touch price
    liquidated = liquidation
    partial = partial fill
oflags = comma delimited list of order flags
    viqc = volume in quote currency
    fcib = prefer fee in base currency (default if selling)
    fciq = prefer fee in quote currency (default if buying)
    nompp = no market price protection
trades = array of trade ids related to order (if trades info requested and data available)
 * 
 * Note: Unless otherwise stated, costs, fees, prices, and volumes are in the asset pair's scale, not the currency's scale. For example, if the asset pair uses a lot size that has a scale of 8, the volume will use a scale of 8, even if the currency it represents only has a scale of 2. Similarly, if the asset pair's pricing scale is 5, the scale will remain as 5, even if the underlying currency has a scale of 8.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class RequestTradeVolume
    {
    }
}
/*
Get trade volume
URL: https://api.kraken.com/0/private/TradeVolume

Input:

pair = comma delimited list of asset pairs to get fee info on (optional)
Result: associative array

currency = volume currency
volume = current discount volume
fees = array of asset pairs and fee tier info (if requested)
    fee = current fee in percent
    minfee = minimum fee for pair (if not fixed fee)
    maxfee = maximum fee for pair (if not fixed fee)
    nextfee = next tier's fee for pair (if not fixed fee.  nil if at lowest fee tier)
    nextvolume = volume level of next tier (if not fixed fee.  nil if at lowest fee tier)
    tiervolume = volume level of current tier (if not fixed fee.  nil if at lowest fee tier)
*/
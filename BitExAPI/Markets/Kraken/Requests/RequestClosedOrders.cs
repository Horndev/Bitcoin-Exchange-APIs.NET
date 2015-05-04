using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class RequestClosedOrders
    {
    }
}
/*
Get closed orders
URL: https://api.kraken.com/0/private/ClosedOrders

Input:

trades = whether or not to include trades in output (optional.  default = false)
userref = restrict results to given user reference id (optional)
start = starting unix timestamp or order tx id of results (optional.  exclusive)
end = ending unix timestamp or order tx id of results (optional.  inclusive)
ofs = result offset
closetime = which time to use (optional)
    open
    close
    both (default)
Result: array of order info

closed = array of order info.  See Get open orders.  Additional fields:
    closetm = unix timestamp of when order was closed
    reason = additional info on status (if any)
count = amount of available order info matching criteria
Note: Times given by order tx ids are more accurate than unix timestamps. If an order tx id is given for the time, the order's open time is used
*/
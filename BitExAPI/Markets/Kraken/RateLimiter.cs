using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BitExAPI.Markets.Kraken
{

    public delegate void ReadyEvent();

    public class RateLimiter
    {
        private static int counter = 0;
        private Timer decayTimer;
        private TimeSpan minWait = TimeSpan.FromSeconds(5);
        private DateTime lastRequestTime = DateTime.Now;
        private TimeSpan counterDecay = TimeSpan.FromSeconds(10);
        
        public RateLimiter()
        {
            TimerCallback tcb = this.reduceCounter;
            decayTimer = new Timer(tcb, null, counterDecay, TimeSpan.FromSeconds(4));
        }

        public void EnqueRequest(Action request, int priority, int cost = 2)
        {
            bool done = false;
            if (priority > 9)
                priority = 9;
            if (priority < 0)
                priority = 0;
            while (!done)
            {
                if ((DateTime.Now - lastRequestTime) > minWait && counter < 10 - priority)
                {
                    Console.Beep();     //debugging

                    request();
                    counter = counter + cost;
                    lastRequestTime = DateTime.Now;
                    done = true;
                }
                else
                {
                    
                }
            }
        }

        public void reduceCounter(object s)
        {
            counter = counter > 0 ? counter -= 1 : 0;
        }
    }


}

/*
We have safeguards in place to protect against abuse/DoS attacks as well as order book manipulation caused by the rapid placing and canceling of orders.

Every user of our API has a "call counter" which starts at 0.

Ledger/trade history calls increase the counter by 2.

Place/cancel order calls do not affect the counter.

All other API calls increase the counter by 1.

The user's counter is reduced every couple of seconds, but if the counter exceeds 10 the user's API access is suspended for 15 minutes. The rate at which a users counter is reduced depends on various factors, but the most strict limit reduces the count by 1 every 5 seconds.

Although placing and cancelling orders does not increase the counter, there are separate limits in place to prevent order book manipulation. Only placing orders you intend to fill and keeping the rate down to 1 per second is generally enough to not hit this limit.
*/
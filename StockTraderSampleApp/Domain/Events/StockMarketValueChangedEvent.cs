using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Messaging;

namespace Domain.Events
{
    public class StockMarketValueChangedEvent: IEvent
    {
        public Guid StockId { get; private set; }
        public float MarketValue { get; private set; }

        public StockMarketValueChangedEvent(Guid stockId, float marketValue)
        {
            StockId = stockId;
            MarketValue = marketValue;
        }
    }
}

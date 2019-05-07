using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Messaging;

namespace Domain.Events
{
    public class StockAddedEvent : IEvent
    {
        public Guid StockId { get; private set; }

        public StockAddedEvent(Guid stockId)
        {
            StockId = stockId;
        }
    }
}

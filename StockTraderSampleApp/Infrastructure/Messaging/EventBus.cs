using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public class EventBus : IEventBus, IEventHandlersRegistry
    {
        private readonly Dictionary<Type, IList<Action<IEvent>>> _handlers = new Dictionary<Type, IList<Action<IEvent>>>();

        public void Publish(IEvent @event)
        {
            var eventType = @event.GetType();
            if (_handlers.ContainsKey(eventType))
            {
                var handlers = _handlers[eventType];
                foreach (var handler in handlers)
                {
                    handler(@event);
                }
            }
        }
        public void Register(Type evenType, Action<IEvent> handler)
        {
            if (_handlers.ContainsKey(evenType))
            {
                _handlers[evenType].Add(handler);
            }
            else
            {
                _handlers.Add(evenType, new List<Action<IEvent>>(new[] { handler }));
            }
        }

    }
}

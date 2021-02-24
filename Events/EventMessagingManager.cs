using SFMLRaycaster.Events.Interfaces;
using System.Collections.Generic;
using System;
using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster.Events
{
    class EventMessagingManager : IEventMessagingManager
    {
        private static EventMessagingManager _instance;
        private readonly Dictionary<EventType, List<IEventMessageHandler>> _eventMessageHandlers = 
            new Dictionary<EventType, List<IEventMessageHandler>>();

        private EventMessagingManager() { }

        public void Publish(EventMessage eventMessage)
        {
            EventType eventType = eventMessage.eventType;
            List<IEventMessageHandler> eventTypeHandlers;

            try
            {
                eventTypeHandlers = _eventMessageHandlers[eventType];
            }
            catch(Exception e)
            {
                return;
            }
            
            for(var i = 0; i < eventTypeHandlers.Count; i++)
            {
                eventTypeHandlers[i].HandleMessage(eventMessage);
                
                Console.WriteLine(eventTypeHandlers[i]);
                Console.WriteLine(eventMessage.ToString());
            }

        }

        public void Subscribe(EventType eventType, IEventMessageHandler eventMessageHandler)
        {
            try
            {
                _eventMessageHandlers[eventType].Add(eventMessageHandler);
            } 
            catch
            {
                _eventMessageHandlers.Add(eventType, new List<IEventMessageHandler> { eventMessageHandler });
            }
        }

        public void Unsubscribe(EventType eventType, IEventMessageHandler eventMessageHandler)
        {
            
        }

        public static EventMessagingManager Instance()
        {
            if (_instance == null)
            {
                _instance = new EventMessagingManager();
            }

            return _instance;
        }
    }
}

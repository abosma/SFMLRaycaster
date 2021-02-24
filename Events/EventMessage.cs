using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster.Events
{
    public class EventMessage
    {
        public EventType eventType;
        public dynamic eventData;

        public EventMessage(EventType eventType, dynamic eventData = default)
        {
            this.eventType = eventType;
            this.eventData = eventData;
        }

        public override string ToString()
        {
            return $"Event Type: {eventType}\nEvent Data: {eventData}";
        }
    }
}

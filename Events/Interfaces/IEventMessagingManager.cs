using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster.Events.Interfaces
{
    interface IEventMessagingManager
    {
        void Publish(EventMessage eventMessage);
        void Subscribe(EventType eventType, IEventMessageHandler eventMessageHandler);
        void Unsubscribe(EventType eventType, IEventMessageHandler eventMessageHandler);
    }
}

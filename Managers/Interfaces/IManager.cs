using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Managers.Interfaces
{
    abstract class IManager : IEventMessageHandler
    {
        public abstract void Update(float deltaTime);
        public abstract void HandleMessage(EventMessage eventMessage);
    }
}

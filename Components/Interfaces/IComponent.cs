using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Components.Interfaces
{
    public abstract class IComponent : IEventMessageHandler
    {
        public Entity entity { get; set; }
        public abstract void Start();
        public abstract void Update(float deltaTime);
        public abstract void HandleMessage(EventMessage eventMessage);
    }
}

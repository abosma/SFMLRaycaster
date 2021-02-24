using SFMLRaycaster.Entities;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Components.Interfaces
{
    public abstract class Component : IEventMessageHandler
    {
        public Entity Entity { get; set; }
        
        public virtual void Start()
        {
            return;
        }

        public virtual void Update(float deltaTime)
        {
            return;
        }

        public virtual void HandleMessage(EventMessage eventMessage)
        {
            return;
        }
    }
}

using SFML.Graphics;
using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Components.Interfaces
{
    public abstract class IComponent : IEventMessageHandler
    {
        public Entity entity { get; set; }
        
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

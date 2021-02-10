using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Managers.Interfaces
{
    abstract class IManager : IEventMessageHandler
    {
        public IManager()
        {
            this.Start();
        }

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

using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Managers.Interfaces
{
    abstract class Manager : IEventMessageHandler
    {
        protected Manager()
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

using System.Collections.Generic;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.EventTypes;
using SFMLRaycaster.Managers.Interfaces;

namespace SFMLRaycaster.Entities
{
    class EntityManager : Manager
    {
        private readonly List<Entity> _entities = new List<Entity>();

        public override void Start()
        {
            EventMessagingManager.Instance().Subscribe(EventType.ADD_ENTITY, this);
        }

        public override void Update(float deltaTime)
        {
            for(var i = 0; i < _entities.Count; i++)
            {
                _entities[i].Update(deltaTime);
            }
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            if (eventMessage.eventType == EventType.ADD_ENTITY)
            {
                _entities.Add(eventMessage.eventData);
            }
        }
    }
}

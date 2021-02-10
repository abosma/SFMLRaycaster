using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers.Interfaces;
using System;
using System.Collections.Generic;

namespace SFMLRaycaster.Managers
{
    class EntityManager : IManager
    {
        private List<Entity> entities = new List<Entity>();

        public override void Update(float deltaTime)
        {
            for(var i = 0; i < entities.Count; i++)
            {
                entities[i].Update(deltaTime);
            }
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            if (eventMessage.eventType == EventType.ADD_ENTITY)
            {
                entities.Add(eventMessage.eventData);
            }
        }
    }
}

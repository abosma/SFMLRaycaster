using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Components;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers;
using SFMLRaycaster.Managers.Interfaces;
using System;
using SFMLRaycaster.Entities;
using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster
{
    class GameLoop
    {
        readonly Clock _clock = new Clock();

        public GameLoop(RenderWindow window)
        {
            Manager entityManager = new EntityManager();
            Manager debugManager = new DebugManager();

            Entity entity = new Entity(x: 5, y: 5);
            entity.AddComponent(new MapRenderer());
            entity.AddComponent(new Camera());
            entity.AddComponent(new InputHandler());

            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_ENTITY, entity));

            window.Closed += Window_Closed;

            while (window.IsOpen)
            {
                var deltaTime = _clock.Restart().AsSeconds();
                
                window.DispatchEvents();

                entityManager.Update(deltaTime);
                debugManager.Update(deltaTime);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}

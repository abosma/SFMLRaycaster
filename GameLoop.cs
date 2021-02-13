using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Components;
using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers;
using SFMLRaycaster.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLRaycaster
{
    class GameLoop
    {
        Clock clock = new Clock();

        public GameLoop(RenderWindow window)
        {
            IManager entityManager = new EntityManager();
            IManager debugManager = new DebugManager();
  
            EventMessagingManager.Instance().Subscribe(Events.EventType.ADD_ENTITY, entityManager);

            Entity entity = new Entity(x: 5, y: 5);
            entity.AddComponent(new MapRenderer());
            entity.AddComponent(new Camera());
            entity.AddComponent(new InputHandler());

            EventMessagingManager.Instance().Publish(new EventMessage(Events.EventType.ADD_ENTITY, entity));

            window.Closed += Window_Closed;

            float deltaTime;

            while (window.IsOpen)
            {
                deltaTime = clock.Restart().AsSeconds();
                
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

using SFMLRaycaster.Events;
using SFMLRaycaster.Managers;
using SFML.Window;
using SFML.System;
using SFMLRaycaster.Managers.Interfaces;
using SFML.Graphics;
using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Components;

namespace SFMLRaycaster
{
    class Game
    {
        Clock clock = new Clock();
        float deltaTime;

        RenderWindow window = new RenderWindow(new VideoMode((uint)Config.screenWidth, (uint)Config.screenHeight), "Test");

        public Game()
        {
            IManager EntityManager = new EntityManager();
            IManager WindowManager = new WindowManager(window);

            window.SetFramerateLimit(60);

            EventMessagingManager.Instance().Subscribe(Events.EventType.ADD_ENTITY, EntityManager);

            Entity entity = new Entity();
            entity.AddComponent(new Camera());

            EventMessagingManager.Instance().Publish(new EventMessage(Events.EventType.ADD_ENTITY, entity));

            while(window.IsOpen)
            {
                deltaTime = clock.Restart().AsSeconds();
                
                window.DispatchEvents();
                
                EntityManager.Update(deltaTime);
                WindowManager.Update(deltaTime);
            }
        }
    }
}

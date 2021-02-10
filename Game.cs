using SFMLRaycaster.Events;
using SFMLRaycaster.Managers;
using SFML.Window;
using SFML.System;
using SFMLRaycaster.Managers.Interfaces;
using SFML.Graphics;
using SFMLRaycaster.Entities.Interfaces;
using SFMLRaycaster.Components;
using System.Threading;

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

            EventMessagingManager.Instance().Subscribe(Events.EventType.ADD_ENTITY, EntityManager);

            Entity entity = new Entity();
            entity.AddComponent(new Camera());
            entity.AddComponent(new InputHandler());

            EventMessagingManager.Instance().Publish(new EventMessage(Events.EventType.ADD_ENTITY, entity));

            window.SetActive(false);

            Thread drawThread = new Thread(new ParameterizedThreadStart(GameRenderer.RenderThread));
            drawThread.Start(window);

            while (window.IsOpen)
            {
                deltaTime = clock.Restart().AsSeconds();
                window.DispatchEvents();
                
                EntityManager.Update(deltaTime);
            }
        }
    }
}

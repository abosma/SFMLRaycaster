using SFML.Graphics;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers.Interfaces;
using System.Collections.Generic;

namespace SFMLRaycaster.Managers
{
    class GameRenderer : IManager
    {
        private RenderWindow renderWindow;
        private List<Drawable> _drawables = new List<Drawable>();

        public override void Start()
        {
            EventMessagingManager.Instance().Subscribe(EventType.ADD_DRAWABLE, this);
        }

        public void RenderThread(object window)
        {
            renderWindow = (RenderWindow)window;

            renderWindow.SetActive(true);

            while(renderWindow.IsOpen)
            {
                renderWindow.Clear();
                DrawDrawables();
                renderWindow.Display();
            }
        }

        private void DrawDrawables()
        {
            for(var i = 0; i < _drawables.Count; i++)
            {
                _drawables[i].Draw(renderWindow, RenderStates.Default);
            }
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            if(eventMessage.eventType == EventType.ADD_DRAWABLE)
            {
                Drawable toAddDrawable = eventMessage.eventData;
                
                _drawables.Add(toAddDrawable);
            }
        }
    }
}

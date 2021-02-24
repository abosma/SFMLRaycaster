using System.Collections.Generic;
using SFML.Graphics;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.EventTypes;
using SFMLRaycaster.Managers.Interfaces;
using SFMLRaycaster.Textures;

namespace SFMLRaycaster
{
    class GameRenderer : Manager
    {
        private RenderWindow _renderWindow;
        private readonly List<Drawable> _drawables = new List<Drawable>();

        public override void Start()
        {
            EventMessagingManager.Instance().Subscribe(EventType.ADD_DRAWABLE, this);
            Manager textureManager = new TextureManager();
        }

        public void RenderThread(object window)
        {
            _renderWindow = (RenderWindow)window;

            _renderWindow.SetActive(true);

            while(_renderWindow.IsOpen)
            {
                _renderWindow.Clear();
                DrawDrawables();
                _renderWindow.Display();
            }
        }

        private void DrawDrawables()
        {
            for(var i = 0; i < _drawables.Count; i++)
            {
                _drawables[i].Draw(_renderWindow, RenderStates.Default);
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

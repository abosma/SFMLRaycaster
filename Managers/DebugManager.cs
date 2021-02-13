using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLRaycaster.Managers
{
    class DebugManager : IManager
    {
        private Text text = new Text();
        private int waitTime;
        private Font font;

        public override void Start()
        {
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, text));

            string fontFolderPath = $"{Environment.CurrentDirectory}\\Fonts\\";
            font = new Font(fontFolderPath + "SourceCodePro-Medium.ttf");
            
            text.Font = font;
            text.CharacterSize = 20;
            text.FillColor = new Color(255, 255, 255);
        }

        public override void Update(float deltaTime)
        {
            if(waitTime == 0)
            {
                float fps = 1f / deltaTime;

                text.DisplayedString = $"FPS: {Math.Floor(fps)}";

                waitTime = 1000;
            }

            waitTime -= 1;
        }
    }
}

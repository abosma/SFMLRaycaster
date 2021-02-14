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
        private Text fpsText = new Text();
        private static Text consoleText = new Text();

        private int waitTime;
        private Font font;

        private static StringBuilder consoleString = new StringBuilder(100);

        public override void Start()
        {
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, fpsText));
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, consoleText));

            string fontFolderPath = $"{Environment.CurrentDirectory}\\Fonts\\";
            font = new Font(fontFolderPath + "SourceCodePro-Medium.ttf");
            
            fpsText.Font = font;
            fpsText.CharacterSize = 20;
            fpsText.FillColor = new Color(255, 255, 255);

            consoleText.Font = font;
            consoleText.CharacterSize = 20;
            consoleText.FillColor = new Color(255, 255, 255);
            consoleText.Position = new Vector2f(0, 640);
        }

        public static void WriteConsoleText(string text)
        {
            consoleText.DisplayedString = consoleString.Append(text).ToString();
        }

        public override void Update(float deltaTime)
        {
            if(waitTime == 0)
            {
                float fps = 1f / deltaTime;

                fpsText.DisplayedString = $"FPS: {Math.Floor(fps)}";

                waitTime = 1000;
            }

            waitTime -= 1;
        }
    }
}

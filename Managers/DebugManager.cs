using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers.Interfaces;
using System;
using System.Text;
using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster.Managers
{
    class DebugManager : Manager
    {
        private readonly Text _fpsText = new Text();
        private static readonly Text ConsoleText = new Text();

        private int _waitTime;
        private Font _font;

        private static readonly StringBuilder ConsoleString = new StringBuilder(100);

        public override void Start()
        {
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, _fpsText));
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, ConsoleText));

            string fontFolderPath = $"{Environment.CurrentDirectory}\\Fonts\\";
            _font = new Font(fontFolderPath + "SourceCodePro-Medium.ttf");
            
            _fpsText.Font = _font;
            _fpsText.CharacterSize = 20;
            _fpsText.FillColor = new Color(255, 255, 255);

            ConsoleText.Font = _font;
            ConsoleText.CharacterSize = 20;
            ConsoleText.FillColor = new Color(255, 255, 255);
            ConsoleText.Position = new Vector2f(0, 640);
        }

        public static void WriteConsoleText(string text)
        {
            ConsoleText.DisplayedString = ConsoleString.Append(text).ToString();
        }

        public override void Update(float deltaTime)
        {
            if(_waitTime == 0)
            {
                float fps = 1f / deltaTime;

                _fpsText.DisplayedString = $"FPS: {Math.Floor(fps)}";

                _waitTime = 1000;
            }

            _waitTime -= 1;
        }
    }
}

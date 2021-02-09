using SFML.Graphics;
using SFMLRaycaster.Events;
using SFMLRaycaster.Managers.Interfaces;
using System;

namespace SFMLRaycaster.Managers
{
    class WindowManager : IManager
    {
        private RenderWindow _renderWindow;

        public WindowManager(RenderWindow renderWindow)
        {
            _renderWindow = renderWindow;

            _renderWindow.Closed += _renderWindow_Closed;
        }

        private void _renderWindow_Closed(object sender, EventArgs e)
        {
            _renderWindow.Close();
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            return;
        }

        public override void Update(float deltaTime)
        {
            _renderWindow.Clear();
            _renderWindow.Display();
        }
    }
}

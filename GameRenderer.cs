using SFML.Graphics;

namespace SFMLRaycaster.Managers
{
    class GameRenderer
    {
        public static void RenderThread(object window)
        {
            RenderWindow renderWindow = (RenderWindow)window;

            renderWindow.SetActive(true);

            while(renderWindow.IsOpen)
            {
                renderWindow.Clear();
                renderWindow.Display();
            }
        }
    }
}

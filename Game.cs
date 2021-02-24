using SFML.Window;
using SFML.Graphics;
using System.Threading;

namespace SFMLRaycaster
{
    class Game
    {
        private readonly RenderWindow _window = new RenderWindow(new VideoMode((uint)Config.screenWidth, (uint)Config.screenHeight), "Test");

        public Game()
        {
            _window.SetActive(false);

            GameRenderer gameRenderer = new GameRenderer();
            ParameterizedThreadStart threadDelegate = gameRenderer.RenderThread;
            Thread drawThread = new Thread(threadDelegate);
            drawThread.Start(_window);

            GameLoop gameLoop = new GameLoop(_window);
        }
    }
}

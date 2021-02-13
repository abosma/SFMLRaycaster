using SFMLRaycaster.Managers;
using SFML.Window;
using SFML.Graphics;
using System.Threading;

namespace SFMLRaycaster
{
    class Game
    {
        RenderWindow window = new RenderWindow(new VideoMode((uint)Config.screenWidth, (uint)Config.screenHeight), "Test");

        public Game()
        {
            window.SetActive(false);

            GameRenderer gameRenderer = new GameRenderer();
            ParameterizedThreadStart threadDelegate = new ParameterizedThreadStart(gameRenderer.RenderThread);
            Thread drawThread = new Thread(threadDelegate);
            drawThread.Start(window);

            GameLoop gameLoop = new GameLoop(window);
        }
    }
}

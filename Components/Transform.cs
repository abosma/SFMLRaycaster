using SFML.System;
using SFMLRaycaster.Components.Interfaces;

namespace SFMLRaycaster.Components
{
    public class Transform : Component
    {
        public Vector2f position = new Vector2f(0, 0);

        public Transform(float x, float y)
        {
            position = new Vector2f(x, y);
        }

        public Transform(int x, int y)
        {
            position = new Vector2f(x, y);
        }

        public Transform(Vector2f vector)
        {
            position = vector;
        }

        public Transform() { }
    }
}

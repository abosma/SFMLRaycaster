using SFML.System;
using SFML.Window;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using System;

namespace SFMLRaycaster.Components
{
    class InputHandler : IComponent
    {
        Transform transform;

        public override void Start()
        {
            transform = entity.GetComponent<Transform>();
        }

        public override void Update(float deltaTime)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                transform.position += new Vector2f(-1, 0) * deltaTime;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                transform.position += new Vector2f(1, 0) * deltaTime;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                transform.position += new Vector2f(0, 1) * deltaTime;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                transform.position += new Vector2f(0, -1) * deltaTime;
            }
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            throw new NotImplementedException();
        }
    }
}

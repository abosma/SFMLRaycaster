using SFML.System;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using System;

namespace SFMLRaycaster.Components
{
    public class Transform : IComponent
    {
        public Vector2f position = new Vector2f(0, 0);

        public override void Start()
        {
            return;
        }

        public override void Update(float deltaTime)
        {
            return;
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            return;
        }
    }
}

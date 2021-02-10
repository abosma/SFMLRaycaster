using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using System;

namespace SFMLRaycaster.Components
{
    class Camera : IComponent
    {
        private Transform transform;

        public override void Start()
        {
            transform = entity.transform;
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

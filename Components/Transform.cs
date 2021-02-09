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
            Console.WriteLine("Transform Started");
        }

        public override void Update(float deltaTime)
        {
            //Console.WriteLine("Transform printed through Entity");
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            throw new NotImplementedException();
        }
    }
}

using SFML.Graphics;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using System;

namespace SFMLRaycaster.Components
{
    class MapRenderer : IComponent, Drawable
    {
        private VertexArray mapVertexArray = new VertexArray(PrimitiveType.Lines);

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void HandleMessage(EventMessage eventMessage)
        {
            throw new NotImplementedException();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}

using SFML.Graphics;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Maps;
using SFMLRaycaster.Textures;
using SFMLRaycaster.Events.EventTypes;

namespace SFMLRaycaster.Components
{
    class MapRenderer : Component, Drawable
    {
        public Map map;
        public VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip);

        public override void Start()
        {
            map = MapManager.map;
            EventMessagingManager.Instance().Publish(new EventMessage(EventType.ADD_DRAWABLE, this));
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = TextureManager.wallTexture;

            target.Draw(vertexArray, states);
        }
    }
}

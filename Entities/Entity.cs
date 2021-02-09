using SFMLRaycaster.Components;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace SFMLRaycaster.Entities.Interfaces
{
    public class Entity : IEventMessageHandler
    {
        public Transform transform = new Transform();
        public List<IComponent> components = new List<IComponent>();

        public Entity()
        {
            this.AddComponent(transform);
        }

        public void Update(float deltaTime)
        {
            for(var i = 0; i < components.Count; i++)
            {
                components[i].Update(deltaTime);
            }
        }

        public void HandleMessage(EventMessage eventMessage)
        {
            for (var i = 0; i < components.Count; i++)
            {
                components[i].HandleMessage(eventMessage);
            }
        }

        public T GetComponent<T>()
        {
            Type toGetType = typeof(T);

            for (var i = 0; i < components.Count; i++)
            {
                var component = components[i];

                if (component.GetType() == toGetType)
                {
                    return (dynamic)component;
                }
            }

            return default;
        }

        public List<T> GetComponents<T>()
        {
            Type toGetType = typeof(T);
            List<T> toReturnComponents = new List<T>();

            for (var i = 0; i < components.Count; i++)
            {
                var component = components[i];

                if (component.GetType() == toGetType)
                {
                    toReturnComponents.Add((dynamic)component);
                }
            }

            return toReturnComponents;
        }

        public IComponent AddComponent(IComponent component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);

                component.entity = this;
                component.Start();

                return component;
            }

            return null;
        }

        public void RemoveComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
            }
        }
    }
}

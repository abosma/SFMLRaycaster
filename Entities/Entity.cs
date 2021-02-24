using System;
using System.Collections.Generic;
using SFMLRaycaster.Components;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Events.Interfaces;

namespace SFMLRaycaster.Entities
{
    public class Entity : IEventMessageHandler
    {
        public Transform transform;
        public string entityName;
        public List<Component> components = new List<Component>();

        public Entity(string entityName = "", float x = 0, float y = 0)
        {
            this.transform = new Transform(x, y);
            this.entityName = entityName;
            this.AddComponent(transform);
            this.Start();
        }

        public void Start()
        {
            for (var i = 0; i < components.Count; i++)
            {
                components[i].Start();
            }
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

        public Component AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);

                component.Entity = this;
                component.Start();

                return component;
            }

            return null;
        }

        public void RemoveComponent(Component component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
            }
        }
    }
}

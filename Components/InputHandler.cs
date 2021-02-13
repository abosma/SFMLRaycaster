﻿using SFML.System;
using SFML.Window;
using SFMLRaycaster.Components.Interfaces;
using SFMLRaycaster.Events;
using SFMLRaycaster.Maps;
using System;

namespace SFMLRaycaster.Components
{
    class InputHandler : IComponent
    {
        private Transform transform;
        private Camera camera;
        private double playerSpeed = 3;
        private double playerRotationSpeed = 1;

        public override void Start()
        {
            transform = entity.GetComponent<Transform>();
            camera = entity.GetComponent<Camera>();
        }

        public override void Update(float deltaTime)
        {
            double deltaSpeed = playerSpeed * deltaTime;
            double deltaRotationSpeed = playerRotationSpeed * deltaTime;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                transform.position.X += (float)(camera.dirX * deltaSpeed);
                transform.position.Y += (float)(camera.dirY * deltaSpeed);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                transform.position.X -= (float)(camera.dirX * deltaSpeed);
                transform.position.Y -= (float)(camera.dirY * deltaSpeed);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                double oldDirX = camera.dirX;
                double oldPlaneX = camera.cameraPlaneX;


                camera.dirX = camera.dirX * Math.Cos(deltaRotationSpeed) - camera.dirY * Math.Sin(deltaRotationSpeed);
                camera.dirY = oldDirX * Math.Sin(deltaRotationSpeed) + camera.dirY * Math.Cos(deltaRotationSpeed);

                camera.cameraPlaneX = camera.cameraPlaneX * Math.Cos(deltaRotationSpeed) - camera.cameraPlaneY * Math.Sin(deltaRotationSpeed);
                camera.cameraPlaneY = oldPlaneX * Math.Sin(deltaRotationSpeed) + camera.cameraPlaneY * Math.Cos(deltaRotationSpeed);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                double oldDirX = camera.dirX;
                double oldPlaneX = camera.cameraPlaneX;

                camera.dirX = camera.dirX * Math.Cos(-deltaRotationSpeed) - camera.dirY * Math.Sin(-deltaRotationSpeed);
                camera.dirY = oldDirX * Math.Sin(-deltaRotationSpeed) + camera.dirY * Math.Cos(-deltaRotationSpeed);

                camera.cameraPlaneX = camera.cameraPlaneX * Math.Cos(-deltaRotationSpeed) - camera.cameraPlaneY * Math.Sin(-deltaRotationSpeed);
                camera.cameraPlaneY = oldPlaneX * Math.Sin(-deltaRotationSpeed) + camera.cameraPlaneY * Math.Cos(-deltaRotationSpeed);
            }
        }

        private void RotateLeft()
        {

        }

        private void RotateRight()
        {

        }
    }
}
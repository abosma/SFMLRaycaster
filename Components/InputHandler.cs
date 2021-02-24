using SFML.Window;
using SFMLRaycaster.Components.Interfaces;
using System;
using SFMLRaycaster.Maps;

namespace SFMLRaycaster.Components
{
    class InputHandler : Component
    {
        private Transform _transform;
        private Camera _camera;
        private double _playerSpeed = 3;
        private double _playerRotationSpeed;

        private int[,] _mapArray;

        public override void Start()
        {
            _transform = Entity.GetComponent<Transform>();
            _camera = Entity.GetComponent<Camera>();

            _playerRotationSpeed = Config.mouseSensitivity;
            _mapArray = MapManager.map.mapArray;
        }

        public override void Update(float deltaTime)
        {
            double deltaSpeed = _playerSpeed * deltaTime;
            double deltaRotationSpeed = _playerRotationSpeed * deltaTime;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                if (_mapArray[(int)(_camera.posX + _camera.dirX * deltaSpeed), (int)_camera.posY] == 0)
                {
                    _transform.position.X += (float)(_camera.dirX * deltaSpeed);
                }

                if (_mapArray[(int)_camera.posX, (int)(_camera.posY + _camera.dirY * deltaSpeed)] == 0)
                {
                    _transform.position.Y += (float)(_camera.dirY * deltaSpeed);
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                if (_mapArray[(int)(_camera.posX - _camera.dirX * deltaSpeed), (int)_camera.posY] == 0)
                {
                    _transform.position.X -= (float)(_camera.dirX * deltaSpeed);
                }

                if (_mapArray[(int)_camera.posX, (int)(_camera.posY - _camera.dirY * deltaSpeed)] == 0)
                {
                    _transform.position.Y -= (float)(_camera.dirY * deltaSpeed);
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                RotateHorizontal(deltaRotationSpeed);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                RotateHorizontal(-deltaRotationSpeed);
            }
        }

        private void RotateHorizontal(double deltaRotationSpeed)
        {
            double oldDirX = _camera.dirX;
            double oldPlaneX = _camera.cameraPlaneX;

            _camera.dirX = _camera.dirX * Math.Cos(deltaRotationSpeed) - _camera.dirY * Math.Sin(deltaRotationSpeed);
            _camera.dirY = oldDirX * Math.Sin(deltaRotationSpeed) + _camera.dirY * Math.Cos(deltaRotationSpeed);

            _camera.cameraPlaneX = _camera.cameraPlaneX * Math.Cos(deltaRotationSpeed) - _camera.cameraPlaneY * Math.Sin(deltaRotationSpeed);
            _camera.cameraPlaneY = oldPlaneX * Math.Sin(deltaRotationSpeed) + _camera.cameraPlaneY * Math.Cos(deltaRotationSpeed);
        }

        private void RotateVertical(double deltaRotationSpeed)
        {
            
        }

        private bool CanMove(double deltaSpeed)
        {
           

            

            

            

            return false;
        }

    }
}

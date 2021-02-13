using SFMLRaycaster.Components.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Events;
using System;

namespace SFMLRaycaster.Components
{
    class Camera : IComponent
    {
        private Transform transform;
        private MapRenderer mapRenderer;

        private int mapX, mapY, stepX, stepY, side, hit = 0;
        public double posX, posY, cameraX, rayDirX, rayDirY, sideDistX, sideDistY, deltaDistX, deltaDistY, perpWallDist;
        public double dirX = -1, dirY = 0;
        public double cameraPlaneX = 0, cameraPlaneY = 0.66;

        public override void Start()
        {
            transform = entity.transform;
            mapRenderer = entity.GetComponent<MapRenderer>();
        }

        public override void Update(float deltaTime)
        {
            double screenHeight = Config.screenHeight;
            double screenWidth = Config.screenWidth;

            posX = transform.position.X;
            posY = transform.position.Y;

            VertexArray toDrawVertexArray = new VertexArray(PrimitiveType.Lines);

            for (var x = 0; x < screenWidth; x++)
            {
                hit = 0;
                mapX = (int)posX;
                mapY = (int)posY;
                cameraX = 2 * x / screenWidth - 1;

                CalculateRayDir(cameraX);
                CalculateDeltaDist();
                CalculateStepAndSideDist();
                CalculateDDA();
                CalculateDistanceProjection();

                Vertex[] vertices = GenerateVertices(screenHeight, x);

                toDrawVertexArray.Append(vertices[0]);
                toDrawVertexArray.Append(vertices[1]);
            }

            mapRenderer.vertexArray = new VertexArray(toDrawVertexArray);
            toDrawVertexArray.Clear();
        }

        private void CalculateRayDir(double cameraX)
        {
            rayDirX = dirX + cameraPlaneX * cameraX;
            rayDirY = dirY + cameraPlaneY * cameraX;
        }

        private void CalculateDeltaDist()
        {
            deltaDistX = (rayDirY == 0) ? 0 : ((rayDirX == 0) ? 1 : Math.Abs(1 / rayDirX));
            deltaDistY = (rayDirX == 0) ? 0 : ((rayDirY == 0) ? 1 : Math.Abs(1 / rayDirY));
        }

        private void CalculateStepAndSideDist()
        {
            if(rayDirX < 0)
            {
                stepX = -1;
                sideDistX = (posX - mapX) * deltaDistX;
            }
            else
            {
                stepX = 1;
                sideDistX = (mapX + 1.0 - posX) * deltaDistX;
            }

            if(rayDirY < 0)
            {
                stepY = -1;
                sideDistY = (posY - mapY) * deltaDistY;
            }
            else
            {
                stepY = 1;
                sideDistY = (mapY + 1.0 - posY) * deltaDistY;
            }
        }

        private void CalculateDDA()
        {
            while(hit == 0)
            {
                if(sideDistX < sideDistY)
                {
                    sideDistX += deltaDistX;
                    mapX += stepX;
                    side = 0;
                }
                else
                {
                    sideDistY += deltaDistY;
                    mapY += stepY;
                    side = 1;
                }

                if(mapRenderer.map.mapArray[mapX, mapY] > 0)
                {
                    hit = 1;
                }
            }
        }

        private void CalculateDistanceProjection()
        {
            if(side == 0)
            {
                perpWallDist = (mapX - posX + (1 - stepX) / 2) / rayDirX;
            }
            else
            {
                perpWallDist = (mapY - posY + (1 - stepY) / 2) / rayDirY;
            }
        }

        private Vertex[] GenerateVertices(double screenHeight, int screenX)
        {
            Color vertexColor = CalculateVertexColor();

            int lineHeight = (int)(screenHeight / perpWallDist);
            int lineStart = (int)(-lineHeight / 2 + screenHeight / 2);
            int lineEnd = (int)(lineHeight / 2 + screenHeight / 2);

            if(lineStart < 0)
            {
                lineStart = 0;
            }

            if(lineEnd >= screenHeight)
            {
                lineEnd = (int)(screenHeight - 1);
            }

            Vertex[] toReturnVertices = new Vertex[2];

            toReturnVertices[0] = new Vertex(new Vector2f(screenX, lineStart), vertexColor);
            toReturnVertices[1] = new Vertex(new Vector2f(screenX, lineEnd), vertexColor);

            return toReturnVertices;
        }

        private Color CalculateVertexColor()
        {
            Color toReturnColor;

            switch(mapRenderer.map.mapArray[mapX, mapY])
            {
                case 1:
                    toReturnColor = new Color(255, 0, 0);
                    break;
                case 2:
                    toReturnColor = new Color(0, 255, 0);
                    break;
                case 3:
                    toReturnColor = new Color(0, 0, 255);
                    break;
                default:
                    toReturnColor = new Color(0, 0, 0);
                    break;
            }

            if(side == 1)
            {
                toReturnColor = new Color((byte)(toReturnColor.R / 2), (byte)(toReturnColor.G / 2), (byte)(toReturnColor.B / 2));
            }

            return toReturnColor;
        }
    }
}

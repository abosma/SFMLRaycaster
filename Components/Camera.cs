using SFMLRaycaster.Components.Interfaces;
using SFML.Graphics;
using SFML.System;
using SFMLRaycaster.Events;
using System;
using SFMLRaycaster.Textures;
using SFMLRaycaster.Managers;

namespace SFMLRaycaster.Components
{
    class Camera : IComponent
    {
        private Transform transform;
        private MapRenderer mapRenderer;

        private int mapX, mapY, stepX, stepY, side, hit = 0;
        public double posX, posY, cameraX, rayDirX, rayDirY, sideDistX, sideDistY, deltaDistX, deltaDistY, perpWallDist, wallX;
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
                
                for(var i = 0; i < vertices.Length; i++)
                {
                    toDrawVertexArray.Append(vertices[i]);
                }
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
            deltaDistX = Math.Sqrt(1 + rayDirY * rayDirY / (rayDirX * rayDirX));
            deltaDistY = Math.Sqrt(1 + rayDirX * rayDirX / (rayDirY * rayDirY));
        }

        private void CalculateStepAndSideDist()
        {
            if (rayDirX < 0)
            {
                stepX = -1;
                sideDistX = (posX - mapX) * deltaDistX;
            }
            else
            {
                stepX = 1;
                sideDistX = (mapX + 1.0 - posX) * deltaDistX;
            }

            if (rayDirY < 0)
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
            while (hit == 0)
            {
                if (sideDistX < sideDistY)
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

                if (mapRenderer.map.mapArray[mapX, mapY] > 0)
                {
                    hit = 1;
                }
            }
        }

        private void CalculateDistanceProjection()
        {
            if (side == 0)
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
            Vertex[] toReturnVertices = new Vertex[6];

            Vertex[] wallVertices = CalculateWalls(screenHeight, screenX);
            Vertex[] floorVertices = CalculateFloor(screenHeight, screenX);
            Vertex[] ceilingVertices = CalculateCeiling(screenHeight, screenX);

            toReturnVertices[0] = wallVertices[0];
            toReturnVertices[1] = wallVertices[1];
            toReturnVertices[2] = floorVertices[0];
            toReturnVertices[3] = floorVertices[1];
            toReturnVertices[4] = ceilingVertices[0];
            toReturnVertices[5] = ceilingVertices[1];

            return toReturnVertices;
        }

        private Vertex[] CalculateWalls(double screenHeight, int screenX)
        {
            Vertex[] wallVertices = new Vertex[2];

            Vector2f[] texCoords = CalculateTextureCoords();
            Color vertexColor = CalculateVertexColor();

            int lineHeight = (int)(screenHeight / perpWallDist);
            int lineStart = (int)(-lineHeight / 2 + screenHeight / 2);
            int lineEnd = (int)(lineHeight / 2 + screenHeight / 2);

            if (lineStart < 0)
            {
                lineStart = 0;
            }

            if (lineEnd >= screenHeight)
            {
                lineEnd = (int)(screenHeight - 1);
            }

            wallVertices[0] = new Vertex(new Vector2f(screenX, lineStart), vertexColor, texCoords[0]);
            wallVertices[1] = new Vertex(new Vector2f(screenX, lineEnd), vertexColor, texCoords[1]);

            return wallVertices;
        }

        private Vertex[] CalculateFloor(double screenHeight, int screenX)
        {
            Vertex[] floorVertices = new Vertex[2];

            int groundPixel = (int)screenHeight;
            double wallHeight = screenHeight / perpWallDist;
            double cameraHeight = 0.5f;

            floorVertices[0] = new Vertex(new Vector2f(screenX, groundPixel), new Color(221, 234, 227));

            groundPixel = (int)(wallHeight * cameraHeight + screenHeight * 0.5f);

            floorVertices[1] = new Vertex(new Vector2f(screenX, groundPixel), new Color(221, 234, 227));

            return floorVertices;
        }

        private Vertex[] CalculateCeiling(double screenHeight, int screenX)
        {
            Vertex[] ceilingVertices = new Vertex[2];

            int ceilingPixel = 0;
            double wallHeight = screenHeight / perpWallDist;
            double cameraHeight = 0.525f;

            ceilingVertices[0] = new Vertex(new Vector2f(screenX, ceilingPixel), new Color(98, 115, 135));

            ceilingPixel = (int)(-wallHeight * (1.0f - cameraHeight) + screenHeight * 0.5f);

            ceilingVertices[1] = new Vertex(new Vector2f(screenX, ceilingPixel), new Color(98, 115, 135));

            return ceilingVertices;
        }

        private Vector2f[] CalculateTextureCoords()
        {
            Vector2f[] toReturnVectors = new Vector2f[2];

            int tileType = mapRenderer.map.mapArray[mapX, mapY] - 1;
            int texHeight = TextureManager.textureHeight;
            int texWidth = TextureManager.textureWidth;
            int wallTexSize = TextureManager.fullSize;

            Vector2f texCoords = new Vector2f(tileType * texWidth % wallTexSize, tileType * texWidth / wallTexSize * texWidth);

            double wallX;
            if (side == 0)
            {
                wallX = posY + perpWallDist * rayDirY;
            }
            else
            {
                wallX = posX + perpWallDist * rayDirX;
            }

            wallX -= Math.Floor(wallX);

            int texX = (int)(wallX * texWidth);
            if (side == 0 && rayDirX > 0)
            {
                texX = texWidth - texX - 1;
            }

            if (side == 1 && rayDirY < 0)
            {
                texX = texWidth - texX - 1;
            }

            texCoords.X += texX;

            toReturnVectors[0] = new Vector2f(texCoords.X + 0.5f, texCoords.Y - 0.5f);
            toReturnVectors[1] = new Vector2f(texCoords.X, texCoords.Y + texWidth);

            return toReturnVectors;
        }

        private Color CalculateVertexColor()
        {
            Color toReturnColor = new Color(255, 255, 255);

            if(side == 1)
            {
                toReturnColor = new Color((byte)(toReturnColor.R / 2), (byte)(toReturnColor.G / 2), (byte)(toReturnColor.B / 2));
            }

            return toReturnColor;
        }
    }
}

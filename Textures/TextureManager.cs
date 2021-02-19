using SFMLRaycaster.Managers.Interfaces;
using System;
using System.IO;
using SFML.Graphics;

namespace SFMLRaycaster.Textures
{
    class TextureManager : IManager
    {
        public static int textureHeight = 32;
        public static int textureWidth = 32;
        public static int fullSize = 96;
        public static Texture wallTexture;

        public override void Start()
        {
            string spriteFolderPath = $"{Environment.CurrentDirectory}\\Textures\\Sprites\\";

            wallTexture = GetWallTextures(spriteFolderPath);

            Console.WriteLine(wallTexture);
        }

        private Texture GetWallTextures(string spriteFolderPath)
        {
            string wallTexturePath = spriteFolderPath + "WallTextures.png";

            Texture wallTexture = new Texture(wallTexturePath);

            return wallTexture;
        }
    }
}

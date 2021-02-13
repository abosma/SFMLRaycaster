using SFMLRaycaster.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLRaycaster.Maps
{
    class MapManager : IManager
    {
        public static Map map;

        static MapManager()
        {
            var mapArray = new int[,] {
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 2, 2, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 2, 2, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            map = new Map(mapArray);
        }

        public static void LoadMap(string mapFile)
        {
            return;
        }
    }
}

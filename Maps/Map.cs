using System;
using System.Collections.Generic;
using System.Text;

namespace SFMLRaycaster.Maps
{
    class Map
    {
        public int[,] mapArray;

        public Map(int[,] mapArray)
        {
            this.mapArray = mapArray;
        }
    }
}

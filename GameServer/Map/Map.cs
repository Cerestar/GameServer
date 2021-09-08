//https://www.youtube.com/watch?v=pflVw1vihUs

using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Map {
    class Map {
        int id;
        int mapName;

        int width;
        int height;

        int type;
        //0 - normal
        //1 - arena
        //2 - pk

        bool canWarp;

        Coordinate defaultRespawn;
    }
}

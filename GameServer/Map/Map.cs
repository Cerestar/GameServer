//https://www.youtube.com/watch?v=pflVw1vihUs

using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Map {

    enum MAPTYPE { 
        NORMAL,
        ARENA,
        PK
    }

    class Map {
        int id;
        int mapName;

        int width;
        int height;

        MAPTYPE type;

        bool canWarp;

        Coordinate defaultRespawn; //if player is our of bounds respawn them here
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Map {
    class Tile {
        int id;
        int[] gfxId;
        int mapObjId;
        bool isAnimated;

        Coordinate mapCoord;

        int type;
        //0 - empty / walking space
        //1 - wall
        //2 - npcSpawn
        //3 - chest
        //4 - bank 
        //5 - npcWall
        //6 - fakeWall
        //7 - chair(direction)
        //8 - warp
        //9 - sign
        //10 - edge
        //11 - arena
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer.Map {
    class Coordinate {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    class Coordinate3D : Coordinate {
        int z { get; set; }

        public Coordinate3D(int x, int y, int z) : base(x, y){
            this.z = z;
        }
    }
}

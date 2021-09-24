﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer {
    class Constants {
        public const int TICKS_PER_SEC = 30;
        public const int MS_PER_TICK = 1000 / TICKS_PER_SEC;

        public const float StartingHealth = 100f;
        public const float StartingMana = 100f;
    }
}

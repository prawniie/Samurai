﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class BattleLog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Battle Battle { get; set; }
        public int BattleForeignKey { get; set; }

        public List<BattleEvent> BattleEvents { get; set; }
    }
}

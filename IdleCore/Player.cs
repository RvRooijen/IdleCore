using System;
using System.Collections.Generic;

namespace IdleCore
{
    public class Player
    {
        public Random LootRandomizer { get; }
        private Dictionary<Skill, int> _experience = new();
        
        public Player(Random lootRandomizer)
        {
            LootRandomizer = lootRandomizer;
        }
    }
}
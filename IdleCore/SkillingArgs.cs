using System;

namespace IdleCore
{
    public class SkillingArgs : EventArgs
    {
        public Player Player { get; }
        
        public SkillingArgs(Player player)
        {
            Player = player;
        }
    }
}
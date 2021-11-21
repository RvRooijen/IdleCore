using System;

namespace IdleCore
{
    public interface IRequirement
    {
        public bool HasRequirements(Player player);
    }
}
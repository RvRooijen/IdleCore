using System;

namespace IdleCore
{
    public interface IRequirement
    {
        public Type Type { get; set; }
        public int Value { get; set; }

        public bool HasRequirements();
    }
}
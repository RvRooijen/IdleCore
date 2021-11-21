using System;

namespace IdleCore
{
    public class SkillRequirement : IRequirement
    {
        private Type _type;
        private int _value;

        public SkillRequirement(Type type, int value)
        {
            _type = type;
            _value = value;
        }
        
        public bool HasRequirements(Player player)
        {
            return true;
        }
    }
}
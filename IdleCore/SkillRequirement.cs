using System;

namespace IdleCore
{
    public class SkillRequirement
    {
        private Type _type;
        private int _value;

        public Requirement(Type type, int value)
        {
            _type = type;
            _value = value;
        }
    }
}
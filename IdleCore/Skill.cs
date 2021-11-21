using System;

namespace IdleCore
{
    public class Skill : IStorable
    {
        public Guid Guid { get; }
        public string Name { get; }
        
        public Skill(string name)
        {
            Guid = new Guid();
            Name = name;
        }
    }
}
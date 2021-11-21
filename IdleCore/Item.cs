using System;

namespace IdleCore
{
    public class Item : IDroppable, IStorable
    {
        public Guid Guid { get; }
        public string Name { get; }
        
        public Item(string name)
        {
            Guid = new Guid();
            Name = name;
        }

        public IDroppable Roll(Random random)
        {
            return this;
        }
    }
}
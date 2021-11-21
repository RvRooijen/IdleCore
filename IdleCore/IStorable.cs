using System;

namespace IdleCore
{
    public interface IStorable
    {
        public Guid Guid { get; }
        public string Name { get; }
    }
}
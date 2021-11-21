using System;

namespace IdleCore
{
    public interface IDroppable
    {
        public IDroppable Roll(Random random);
    }
}
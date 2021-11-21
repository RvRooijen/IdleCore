using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleCore
{
    public class DropTable : IDroppable
    {
        public int TotalWeight => _drops.Sum(tuple => tuple.Item2);
        public float GetNormalizedWeight(IDroppable droppable) => _drops.FirstOrDefault(tuple => tuple.Item1 == droppable)?.Item2 / (float)TotalWeight ?? -1;
        
        private readonly List<Tuple<IDroppable, int>> _drops;
        public DropTable(List<Tuple<IDroppable, int>> drops)
        {
            _drops = drops;
        }

        public void AddDrop(IDroppable droppable, int weight)
        {
            _drops.Add(new Tuple<IDroppable, int>(droppable, weight));
        }

        public IDroppable Roll(Random random)
        {
            int pickedWeight = random.Next(0, TotalWeight);
            foreach (var possibleItem in _drops)
            {
                if (pickedWeight < possibleItem.Item2)
                {
                    var droppable = possibleItem.Item1;
                    while (droppable is not Item)
                    {
                        droppable = droppable.Roll(random);
                    }
                    return droppable;
                }

                pickedWeight -= possibleItem.Item2;
            }

            throw new NullReferenceException($"{nameof(Roll)} - no drops found");
        }
    }
}